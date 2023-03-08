using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Compression;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.Linq;


namespace lt.vinco
{
    class Fulltextpro
    {
        public static void unzip(String fileToUnzip)
        {
            try
            {
                Match match = Regex.Match(fileToUnzip, @"\.zip$", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string zipdir = Path.GetDirectoryName(fileToUnzip) + "\\" + Path.GetFileNameWithoutExtension(fileToUnzip);
                    ZipFile.ExtractToDirectory(fileToUnzip, zipdir);
                }//if match
            }
            catch (IOException)
            {
                MessageBox.Show("Nepavyko išzipuoti!");
            }
        }//unzip

        public static void pdf(string pdfdir)
        {
            string menesiodir = Path.GetDirectoryName(pdfdir);
            string dtdfailas = menesiodir + "\\" + "simple-patent-document-v1-9.dtd";
            string dtdname = Path.GetFileName(dtdfailas);
            foreach (string f in Directory.GetFiles(pdfdir))
            {
                string pdfname = Path.GetFileName(f);
                string newString = Regex.Replace(pdfname, "[^0-9]", "");

                foreach (string d in Directory.GetDirectories(menesiodir))
                {
                    if (d.Contains(newString))
                    {
                        //move pdf
                        System.IO.File.Copy(f, d + "\\" + pdfname, true);
                        System.IO.File.Copy(dtdfailas, d + "\\" + dtdname, true); // kopijuojame DTD
                    }
                }
            }
        }//pdf


        public static void ikelti(string[] dirai)
        {     //ikelti
            foreach (string aplankas in dirai)
            {
                string target = null;
                string source = null;

                string foldername = aplankas;
                foreach (string f in Directory.GetFiles(foldername))
                {
                    Match match = System.Text.RegularExpressions.Regex.Match(f, @"LT_\d\d\d\d\d\d\d\d_\d\d\d\d\.xml$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        target = f;
                        //           MessageBox.Show("target " + f);
                    }
                    match = Regex.Match(f, @"LT\d\d\d\dB\.xml$", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        source = f;
                        //          MessageBox.Show("source " + f);
                    }
                }//foreach 

                if ((source == null) || (target == null))
                {
                    MessageBox.Show("Nepavyko", "FULL TEXT");
                    return;
                }


                //              if (true)  return;


                XElement ebdLibrary = XElement.Load(@target);
               XElement descrLibrary = XElement.Load(@source);

   //------------------------------         

               XmlDocument doc = new XmlDocument();
               doc.Load(target);

               XmlDocument doc2 = new XmlDocument();
               doc2.Load(source);
         
               foreach (XmlNode node in doc2.DocumentElement.ChildNodes)
               {
                  XmlNode xnode = doc.ImportNode(node, true);
                  doc.DocumentElement.AppendChild(xnode);
           
               }

               System.IO.File.Delete(target);
               //http://stackoverflow.com/questions/284394/net-xmldocument-why-doctype-changes-after-save
           //    NullSubsetXmlTextWriter ntarget = new NullSubsetXmlTextWriter(target, System.Text.Encoding.UTF8); doc.Save(ntarget);
             doc.Save(target);
               
                

  //---------------------------------              
                //var descr = (from desc in descrLibrary.Elements("description")
                //             //                   where desc.Attribute("lang").Value == "lt"
                //             select desc);
                //foreach (XElement el in descr)
                //{
                   
                //    ebdLibrary.Add(el);
         
                //}

                //var cl = (from claims in descrLibrary.Elements("claims") select claims);
                //foreach (XElement el in cl)
                //{
                //    ebdLibrary.Add(el);
                //}
                //var dr = (from drw in descrLibrary.Elements("drawings") select drw);
                //foreach (XElement el in dr)
                //{
                //    ebdLibrary.Add(el);
                //}
                //ebdLibrary.Save(target);



                //  http://www.codeproject.com/Articles/381661/Creating-Zip-Files-Easily-in-NET-4-5

                string zp = Path.GetDirectoryName(Path.GetDirectoryName(source)) + "\\" + Path.GetFileNameWithoutExtension(source) + ".zip";
                string zipName = zp.Insert(zp.LastIndexOf("\\LT") + 3, "_");
                //       string zipName = Path.GetDirectoryName(Path.GetDirectoryName(target)) + "\\" + Path.GetFileNameWithoutExtension(target) + ".zip";
                //Creates a new, blank zip file to work with - the file will be
                //finalized when the using statement completes

                using (ZipArchive newFile = ZipFile.Open(zipName, ZipArchiveMode.Create))
                {

                    foreach (string f in Directory.GetFiles(foldername))
                    {
                        Match match = System.Text.RegularExpressions.Regex.Match(f, @"LT_\d\d\d\d\d\d\d\d_\d\d\d\d\.xml$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }
                        match = Regex.Match(f, @"LT\d\d\d\dB\.pdf$", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }
                        match = Regex.Match(f, @".tif$", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }
                        match = Regex.Match(f, @".dtd$", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }

                    }//foreach 

                }//using
                //dar reikia exception handling

            } //for each aplankas

        }//ikelti



        public static void Xslt(string[] aplankai, string stylesheet)
        {
            foreach (string aplankas in aplankai)
            {

                //  stylesheet = null;
                string fileToTransform = null;

                string foldername = aplankas;
                foreach (string f in Directory.GetFiles(foldername))
                {
                    Match match = Regex.Match(f, @"LT_\d\d\d\d\d\d\d\d_\d\d\d\d\.xml$",
             RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        fileToTransform = f;
                    }
                    //     match = Regex.Match(f, @"\.xsl$", RegexOptions.IgnoreCase);
                    //     if (match.Success)  {    stylesheet = f;  }

                }//foreach 

                if ((fileToTransform == null) || (stylesheet == null))
                {
                    MessageBox.Show("Nerastas transformuojamas failas arba stilių failas", "FULL TEXT");
                    return;
                }

                try
                {
                    string output = Path.GetDirectoryName(fileToTransform) + "\\" + Path.GetFileNameWithoutExtension(fileToTransform) + ".html";

                    XslTransform myXslTransform = new XslTransform();
                    myXslTransform.Load(stylesheet);
                    myXslTransform.Transform(fileToTransform, output);



                }
                catch (XmlException)
                {
                    MessageBox.Show("Transformacija nepavyko!");
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Nerastas failas. DTD?");
                }

            }//for each aplankas
        }


        public static void Zipbebibl(string[] aplankai)
        {
            foreach (string aplankas in aplankai)
            {



                string source = null;


                string foldername = aplankas;
                foreach (string f in Directory.GetFiles(foldername))
                {
                    Match match;


                    match = Regex.Match(f, @"LT\d\d\d\dB\.xml$", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        source = f;
                        //          MessageBox.Show("source " + f);
                    }
                }//foreach 

                if (source == null)
                {
                    MessageBox.Show("Nepavyko", "FULL TEXT");
                    return;
                }



                string zipName = Path.GetDirectoryName(Path.GetDirectoryName(source)) + "\\" + Path.GetFileNameWithoutExtension(source) + ".zip";
                //Creates a new, blank zip file to work with - the file will be
                //finalized when the using statement completes

                using (ZipArchive newFile = ZipFile.Open(zipName, ZipArchiveMode.Create))
                {

                    foreach (string f in Directory.GetFiles(foldername))
                    {
                        Match match = System.Text.RegularExpressions.Regex.Match(f, @"LT\d\d\d\dB\.xml$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }
                        match = Regex.Match(f, @"LT\d\d\d\dB\.pdf$", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }
                        match = Regex.Match(f, @".tif$", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            newFile.CreateEntryFromFile(f, Path.GetFileName(f));
                        }

                    }//foreach 

                }//using
                //dar reikia exception handling
            }//for each aplankas
        }







    }//class


    //http://stackoverflow.com/questions/284394/net-xmldocument-why-doctype-changes-after-save
     class NullSubsetXmlTextWriter : XmlTextWriter
    {
        public NullSubsetXmlTextWriter(String inputFileName, System.Text.Encoding encoding)
            : base(inputFileName, encoding)
        {
        }
        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            if (subset == String.Empty)
            {
                subset = null;
            }
            base.WriteDocType(name, pubid, sysid, subset);
        }
    }




}//ns
