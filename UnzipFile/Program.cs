using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ionic.Zip;

namespace UnzipFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=args[0];
            string file = args[1];
            if (path != null && path.Length>0)
            {
                if ((path + @"\" + file).Contains(".zip") || (path + @"\" + file).Contains(".rar"))
                {
                    if (File.Exists((path + @"\" + file)))
                    {
                        using (ZipFile zip1 = ZipFile.Read(file))
                        {
                            ZipFile zip = ZipFile.Read(file);
                            Directory.CreateDirectory(path);
                            foreach (ZipEntry e in zip)
                            {

                                e.Extract(path, ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                    }
                }
            }
        }
    }
}
