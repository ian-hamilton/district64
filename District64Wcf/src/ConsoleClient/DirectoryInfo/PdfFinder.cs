using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net;

namespace District64.District64Wcf.ConsoleClient.DirectoryInfo
{
    public class PdfFinder
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PdfFinder));
        IList<String> _list;

        public PdfFinder()
        {
            _list = new List<String>();
        }

        public IList<String> findAllPdf(String rootDirectory, bool doDelete)
        {            
            this.search(rootDirectory, doDelete);
            return _list;
        }

        protected void search(String directory, bool doDelete)
        {
            //_log.Info("Directory: " + directory);
            foreach(String file in Directory.GetFiles(directory))
            {
                //_log.Info("File: " + file);
                if (Path.GetExtension(file).Trim().ToLower() == ".pdf")
                {
                    _log.Info("PDF File: " + file);
                    _list.Add(file);
                }
                else
                {
                    _log.Info("deleting file >>>>>" + file + "<<<<<<");
                    File.Delete(file);
                }
            }

            foreach(String dir in Directory.GetDirectories(directory))
            {
                this.search(dir, doDelete);
            }
        }
    }
}
