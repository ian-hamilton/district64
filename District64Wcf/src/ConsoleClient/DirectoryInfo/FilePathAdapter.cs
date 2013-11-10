using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace District64.District64Wcf.ConsoleClient.DirectoryInfo
{
    public class FilePathAdapter
    {
        public static String adapt(String initialPath)
        {
            return initialPath.Substring(initialPath.IndexOf(':') + 1, initialPath.Length - (initialPath.IndexOf(':') + 1));
        }
    }
}
