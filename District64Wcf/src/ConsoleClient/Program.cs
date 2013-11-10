using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.Domain.Enums;
using log4net;
using log4net.Config;
using District64.District64Wcf.ConsoleClient.DirectoryInfo;
using District64.District64Wcf.ConsoleClient.Archive;



namespace ConsoleClient
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));



        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                while (true)
                {
                    Console.WriteLine("Please select from the following:");
                    Console.WriteLine("1. Upload single file");
                    Console.WriteLine("2. Download single file");
                    Console.WriteLine("3. Upload Directory");
                    Console.WriteLine("4. Criterion Search");
                    Console.WriteLine("5. Archive Repository ID Search");
                    Console.WriteLine("6. AppUser Id Search:");
                    Console.WriteLine("7. Upload single file as io path:");
                    Console.WriteLine("8. Upload Directory as io path:");
                    Console.WriteLine("9. Display Path Adapter:");
                    Console.WriteLine("10. Clean-up non-pdf files:");

                    string response = Console.ReadLine();


                    if (response.Trim() == "1")
                        ProcessFile();
                    else if (response.Trim() == "2")
                        ReteiveFile();
                    else if (response.Trim() == "3")
                        ProcessDir();
                    else if (response.Trim() == "4")
                        ProcessSearch();
                    else if (response.Trim() == "5")
                        ProcessRead();
                    else if (response.Trim() == "6")
                        ProcessHasAccess();
                    else if (response.Trim() == "7")
                        ProcessFileIoPath();
                    else if (response.Trim() == "8")
                        ProcessDirIoPath();
                    else if (response.Trim() == "9")
                        DisplayPathAdapter();
                    else if (response.Trim() == "10")
                        DeleteWithPathAdapter();
                }

            }
            catch (Exception ex)
            {
                _log.Error("", ex);
                Console.ReadLine();
            }
        }

        private static void DeleteWithPathAdapter()
        {
            Console.WriteLine("Enter Parent Directory: ");
            string path = Console.ReadLine();

            PdfFinder pdf = new PdfFinder();
            pdf.findAllPdf(path, true);
        }

        private static void DisplayPathAdapter()
        {
            Console.WriteLine("Enter Parent Directory: ");
            string path = Console.ReadLine();
            _log.Info(">>>> " + FilePathAdapter.adapt(path));
        }

        private static void ProcessDirIoPath()
        {
            Console.WriteLine("Enter Parent Directory: ");
            string path = Console.ReadLine();

            try
            {
                if (!Directory.Exists(path))
                    throw new System.Exception("Path Does not Exist");

                CompileArchiveItems(path, false);

            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private static void ProcessFileIoPath()
        {
            Console.WriteLine("Enter File Path and Name: ");
            string path = Console.ReadLine();

            Console.WriteLine("Enter Short Desc: ");
            string shortDesc = Console.ReadLine();

            Console.WriteLine("Enter Long Desc: ");
            string longDesc = Console.ReadLine();

            Console.WriteLine("Enter Archive Year: ");
            string year = Console.ReadLine();

            Console.WriteLine("Enter District Number: ");
            string districtNum = Console.ReadLine();

            Console.WriteLine("Enter Repository Type (S,L,M,F,P,O): ");
            string type = Console.ReadLine();

            ArchiveItem item = new ArchiveItem()
            {
                ArchiveReposLongDesc = longDesc.Trim(),
                ArchiveReposShortDesc = shortDesc.Trim(),
                IsFeaturedItem = false,
                IsValidStatus = true,
                User = 1,
                Year = Int32.Parse(year.Trim()),
                DistrictNumber = districtNum.Trim().Length > 0 ? new int?(Int32.Parse(districtNum.Trim())) : null,
                ArchiveType = GetArchiveItemType(type.Trim().ToUpper()),
                FilePath = path

            };

            DistrictServiceClient client = new DistrictServiceClient();
            client.AddArchiveFile(item);
        }

        private static void ProcessHasAccess()
        {
            Console.WriteLine("Enter To User Id: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Page or Route to Access:");
            string pageOrRoute = Console.ReadLine();

            DistrictServiceClient client = new DistrictServiceClient();
            bool hasAccess = client.HasPageOrRouteAccess(Int64.Parse(id.Trim()), pageOrRoute.Trim());

            Console.Write(String.Format("Has Access => {0}", hasAccess.ToString()));
            Console.ReadLine();

        }

        private static void ProcessRead()
        {
            Console.WriteLine("Enter To Id: ");
            string id = Console.ReadLine();

            DistrictServiceClient client = new DistrictServiceClient();
            ArchiveItem item = client.GetArchiveItem(Int32.Parse(id));

            Console.WriteLine("ID: " + item.ArchiveReposId.ToString());
            Console.ReadLine();
        }

        private static void ProcessSearch()
        {
            Console.WriteLine("Enter From Archive Year: ");
            string fromYear = Console.ReadLine();

            Console.WriteLine("Enter To Archive Year: ");
            string toYear = Console.ReadLine();

            Console.WriteLine("Enter District Number: ");
            string districtNum = Console.ReadLine();

            Console.WriteLine("Enter Repository Type (S,L,M,F,P,O): ");
            string type = Console.ReadLine();

            Console.WriteLine("Description: ");
            string desc = Console.ReadLine();

            DistrictServiceClient client = new DistrictServiceClient();
            ArchiveItem[] items = client.SearchArchiveItems(Int32.Parse(fromYear), Int32.Parse(toYear), null, Int32.Parse(districtNum), desc, false);
 
            foreach(ArchiveItem item in items)
            {
                Console.WriteLine("ID: " + item.ArchiveReposId.ToString());
            }

            Console.WriteLine("--------- Total: " + items.Count().ToString());
            Console.ReadLine();
        }

        private static void ProcessDir()
        {
            Console.WriteLine("Enter Parent Directory: ");
            string path = Console.ReadLine();

            try
            {
                if (!Directory.Exists(path))
                    throw new System.Exception("Path Does not Exist");

                CompileArchiveItems(path, true);

            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private static void CompileArchiveItems(string parentDirectoryPath, bool blob)
        {

            
            IDirectoryInfoFactory factory = new JerryAndJohnDirectoryInfoFactory();

            foreach (string rootDirectoryPath in Directory.GetDirectories(parentDirectoryPath))
            {
                _log.Debug(string.Format("Processing Path: {0}" , rootDirectoryPath));

                List<ArchiveDirectoryInfo> directoryInfoList = new List<ArchiveDirectoryInfo>();
                directoryInfoList.Add(factory.CreateInfo(rootDirectoryPath));
                List<ArchiveItem> list = ArchiveItemFactory.Instance.CreateArchiveItems(directoryInfoList, blob);

                foreach (ArchiveItem item in list)
                {
                    DistrictServiceClient client = new DistrictServiceClient();
                    client.Open();
                    client.AddArchiveFile(item);
                    client.Close();
                }

                list = null;
                GC.Collect();                
            }            

        }

        private static void ReteiveFile()
        {
            Console.WriteLine("Please enter archive id: ");
            string id = Console.ReadLine();

            DistrictServiceClient client = new DistrictServiceClient();
            ArchiveItem item = client.GetArchiveItem(long.Parse(id));

            FileStream fs = new FileStream(item.File.FileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(item.File.ByteArray);
            bw.Close(); 

            Console.WriteLine("FileName: " + item.File.FileName);
        }

        private static void ProcessFile()
        {
            Console.WriteLine("Enter File Path and Name: ");
            string path = Console.ReadLine();

            Console.WriteLine("Enter Short Desc: ");
            string shortDesc = Console.ReadLine();

            Console.WriteLine("Enter Long Desc: ");
            string longDesc = Console.ReadLine();

            Console.WriteLine("Enter Archive Year: ");
            string year = Console.ReadLine();

            Console.WriteLine("Enter District Number: ");
            string districtNum = Console.ReadLine();

            Console.WriteLine("Enter Repository Type (S,L,M,F,P,O): ");
            string type = Console.ReadLine();

            ArchiveItem item = new ArchiveItem()
            {
                ArchiveReposLongDesc = longDesc.Trim(),
                ArchiveReposShortDesc = shortDesc.Trim(),
                IsFeaturedItem = false,
                IsValidStatus = true,
                User = 1,
                Year = Int32.Parse(year.Trim()),
                DistrictNumber = districtNum.Trim().Length > 0 ? new int?(Int32.Parse(districtNum.Trim())) : null,
                ArchiveType = GetArchiveItemType(type.Trim().ToUpper()),
                File = FileCreator.CreateArchiveFile(path.Trim())
            };

            DistrictServiceClient client = new DistrictServiceClient();
            client.AddArchiveFile(item);

        }

        private static ArchiveTypeEnumArchiveType GetArchiveItemType(string type)
        {
             switch (type)
            {
                case "S":
                    return ArchiveTypeEnumArchiveType.Schedule;
                case "L":
                    return ArchiveTypeEnumArchiveType.Letter;
                case "M":
                    return ArchiveTypeEnumArchiveType.Minutes;
                case "F":
                    return ArchiveTypeEnumArchiveType.Flyers;
                case "P":
                    return ArchiveTypeEnumArchiveType.PassItOn;
                case "O":
                    return ArchiveTypeEnumArchiveType.Misc;
                default:
                    throw new Exception(String.Format("Archive type code of '{0}' not valid", type));
            }

        }

    }
}
