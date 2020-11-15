using System;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;
using System.Xml;
using System.IO.Compression;

namespace WorkingWithFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystem();
            //WorkingWithDrive();
            // WorkingWithDirextoris();
            //WorkingWithFile();
            //workingWithText();
            //workingWithXml();
            WorkingWithCompressing();
        }
        static void OutputFileSystem()
        {
            WriteLine("{0, -33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0, -33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
            WriteLine("{0, -33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
            WriteLine("{0, -33} {1}", "Enviroment.CurrentDirectory", CurrentDirectory);
            WriteLine("{0, -33} {1}", "Enviroment.SystemDirectory", SystemDirectory);
            WriteLine("{0, -33} {1}", "Path.GetTempPath()", GetTempPath());

            WriteLine("=====GetFolderPath(SpecialFolder=====");
            WriteLine("{0, -33} {1}", ".system", GetFolderPath(SpecialFolder.System));
            WriteLine("{0, -33} {1}", "ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0, -33} {1}", "MyDocumentd", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0, -33} {1}", ".Presonal", GetFolderPath(SpecialFolder.Personal));
            WriteLine("{0, -33} {1}", ".Presonal", GetFolderPath(SpecialFolder.Programs));
            WriteLine("{0, -33} {1}", ".Presonal", GetFolderPath(SpecialFolder.MyComputer));
        }
        static void WorkingWithDrive()
        {
            WriteLine("{0, -30} | {1, -10} | {2, -7} | {3, -18} | {4, 24} |", "Name", "Type", "Formet", "Size(Bytes)", "FreeSpace");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine("{0, -30} | {1, -10} | {2, -7} | {3, -18} | {4, 24} |", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }
        static void WorkingWithDirextoris()
        {
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "New folder", "code", "newFolder");
            WriteLine($"Working with: {newFolder}");
            WriteLine($"Dose it Exist? {Exists(newFolder)}");

            WriteLine("Directory creating...");
            CreateDirectory(newFolder);
            WriteLine($"Dose it Exist? {Exists(newFolder)}");

            Write("Confirm the directory exists, and then press enter");
            ReadLine();

            WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Dose it Exist? {Exists(newFolder)}");

        }
        static void WorkingWithFile()
        {
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "New folder", "code", "OutputFile");
            WriteLine($"Workong with :{dir}");

            CreateDirectory(dir);

            string textfile = Combine(dir, "Dummy.txt");
            string backUpFile = Combine(dir, "Dummy.bak");
            WriteLine($"Workong with :{textfile}");
            WriteLine($"Workong with :{backUpFile}");

            StreamWriter textWriter = File.CreateText(textfile);
            textWriter.WriteLine("Hello World!!");
            textWriter.Close();

            WriteLine($"TextFile Exists :{File.Exists(textfile)}");

            File.Copy(sourceFileName: textfile, destFileName: backUpFile, overwrite: true);
            WriteLine($"BackUp File exists :{File.Exists(backUpFile)}");

            Write("Confirm and Enter:");
            ReadLine();

            File.Delete(textfile);

            WriteLine($"Read Content from {backUpFile}");
            StreamReader textReader = File.OpenText(backUpFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();
        }
        static string[] callSign = new string[] { "Husker", "Strabuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
        static void workingWithText()
        {
            string textFile = Combine(CurrentDirectory, "stream.txt");

            StreamWriter text = File.CreateText(textFile);
            foreach(var item in callSign)
            {
                text.WriteLine(item);
            }
            text.Close();

            WriteLine($"{textFile} Containt: {new FileInfo(textFile).Length:N0} bytes");
            WriteLine(File.ReadAllText(textFile));

        }
        static void workingWithXml(bool call = true)
        {
            string xmlFile = Combine(CurrentDirectory, "streams.xml");

            FileStream xmlFileStream = File.Create(xmlFile);

            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
            xml.WriteStartDocument();

            xml.WriteStartElement("CallSign");
            foreach (string item in callSign)
                xml.WriteElementString("CallSign", item);
            xml.WriteEndElement();

            xml.Close();
            xmlFileStream.Close();

            WriteLine($"{xmlFile} Containt: {new FileInfo(xmlFile).Length:N0} bytes");

            WriteLine(File.ReadAllText(xmlFile));
        }
        static void workingWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try
            {
                string xmlFile = Combine(CurrentDirectory, "Stream.xml");

                xmlFileStream = File.Create(xmlFile);

                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
                xml.WriteStartDocument();
                xml.WriteStartElement("Callsign");

                foreach(string item in callSign)
                {
                    xml.WriteElementString("CallSign", item);
                }
                xml.WriteEndElement();
                xml.Close();
                xmlFileStream.Close();

                WriteLine($"{xmlFile} Containt: {new FileInfo(xmlFile).Length:N0} bytes");

                WriteLine(File.ReadAllText(xmlFile));
            }
            catch(Exception ex)
            {
                WriteLine($"{ex.GetType()} say {ex.Message}");

            }
            finally
            {
                if(xml != null)
                {
                    xml.Dispose();
                    WriteLine("The xml write unmanaged file resurce have been disputed");
                }
                if(xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The xml file stream unmanage file resources havebeen dispoe");
                }
            }
        }
        
        static void WorkingWithCompressing()
        {
            //Compress with GZIP
            string gzipFilepath = Combine(CurrentDirectory, "stream.gzip");

            FileStream zipFile = File.Create(gzipFilepath);
            using(GZipStream coppress = new GZipStream(zipFile, CompressionMode.Compress))
            {
                using(XmlWriter xmlGZip = XmlWriter.Create(coppress))
                {
                    xmlGZip.WriteStartDocument();
                    xmlGZip.WriteStartElement("callSign");
                    foreach (var item in callSign)
                    {
                        xmlGZip.WriteElementString("CallSign", item);
                    }
                }
            }
            WriteLine($"{gzipFilepath} Containt: {new FileInfo(gzipFilepath).Length:N0} bytes");

            zipFile = File.Open(gzipFilepath, FileMode.Open);
            using(GZipStream decompress = new GZipStream(zipFile, CompressionMode.Decompress))
            {
                using(XmlReader reader = XmlReader.Create(decompress))
                {
                    while(reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callSign"))
                        {
                            //reader.Read();
                            WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
                        
        }

    }
}
