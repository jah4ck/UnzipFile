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
            string pathFile=args[0];
            string pathDest = args[1];
            if (pathFile != null && pathFile.Length > 0)
            {
                if (pathFile.Contains(".zip"))
                {
                    if (File.Exists(pathFile))
                    {
                        try
                        {
                            using (ZipFile zip1 = ZipFile.Read(pathFile))
                            {
                                ZipFile zip = ZipFile.Read(pathFile);
                                Directory.CreateDirectory(pathDest);
                                foreach (ZipEntry e in zip)
                                {
                                    e.Extract(pathDest, ExtractExistingFileAction.OverwriteSilently);
                                }
                            }
                        }//test modification sur srv//modification 2//modification 3 
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                            Console.WriteLine(err.StackTrace);
                            Console.WriteLine(pathFile);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le fichier n'existe pas :" + pathFile);
                    }
                }
                else
                {
                    Console.WriteLine("Le fichier doit être un .zip ou .rar");
                }
            }
            else
            {
                Console.WriteLine("le path est inccorect");
            }
        }
    }
}
