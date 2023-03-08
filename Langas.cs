using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO.Compression;
using System.Xml;
using System.Xml.Xsl;

using FolderSelect;

namespace WindowsFormsApplication1
{
    public partial class Langas : Form
    {
        private string initdir = @"c:\";
        private FolderSelectDialog fs;
        string wrkdir = null;
        public Langas(string[] args)
        {
            InitializeComponent();
            initdir = @"c:\";
            fs = new FolderSelectDialog();

            if (args.Length > 0)
            {
                wrkdir = args[0];

            }

        }


        private void btnIkelti_Click(object sender, EventArgs e)
        {
            FolderSelectDialog fs = new FolderSelectDialog();
            fs.Title = "Pasirinkite aplankus patentų aprašymams įkelti";
            fs.InitialDirectory = initdir;
            string[] aplankai = null;
            if (fs.ShowDialog(IntPtr.Zero))
            {
                aplankai = fs.FileNames;
            }
            else return;

            lt.vinco.Fulltextpro.ikelti(aplankai);
            pbIkelti.Visible = true;
            MessageBox.Show("Baigta", "FULL TEXT");

        }



        private void btnXslt_Click(object sender, EventArgs e)
        {
            string stylesheet = null;
            chooser.Title = "Pasirinkite stilių failą (full.xsl)";
            chooser.Multiselect = false;
            DialogResult result = chooser.ShowDialog(); // Show the dialog.
            //  FolderSelectDialog fs = new FolderSelectDialog();
            fs.Title = "Pasirinkite aplankus XSLT transformacijai";
            if (result == DialogResult.OK) // Test result.
            {
                stylesheet = chooser.FileName;
                initdir = Path.GetDirectoryName(stylesheet);
                chooser.InitialDirectory = initdir;
                fs.InitialDirectory = initdir; // @"c:\"; 
                //   folderChooser.RootFolder = initdir;
            }
            else return;



            string[] aplankai = null;
            if (fs.ShowDialog(IntPtr.Zero))
            {
                aplankai = fs.FileNames;
            }
            else return;

            lt.vinco.Fulltextpro.Xslt(aplankai, stylesheet);
            pbXslt.Visible = true;
            MessageBox.Show("Transformacija baigta", "FULL TEXT");
        }//click

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            int i = 0;
            chooser.Title = "Pasirinkite išzipuojamus failus";
            chooser.Multiselect = true;
            DialogResult result = chooser.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                foreach (String fileToUnzip in chooser.FileNames)
                {
                    lt.vinco.Fulltextpro.unzip(fileToUnzip);
                    i++;
                }
                MessageBox.Show("Išzipuota " + i + " failai (-ų)");
                pbUnzip.Visible = true;
            }// if ok

        }//unzip click



        private void btnPdf_Click(object sender, EventArgs e)
        {
            folderChooser.ShowNewFolderButton = false;
            folderChooser.Description = "Pasirinkite patentų PDFų aplanką:";
            folderChooser.RootFolder = System.Environment.SpecialFolder.Desktop;

            DialogResult res = this.folderChooser.ShowDialog();
            if (res == DialogResult.OK)
            {
                // the code here will be executed if the user presses Open in
                // the dialog.
            }
            else return;
            string pdfdir = this.folderChooser.SelectedPath;
            lt.vinco.Fulltextpro.pdf(pdfdir);
            MessageBox.Show("Baigta", "FULL TEXT");
            pbPdf.Visible = true;
        }



        private void btnEbd_Click(object sender, EventArgs e)
        {
            string[] ebdfiles = null;
            chooser.Title = "Pasirinkite EBD failus, pvz., LT_20130625_1212.xml,...";
            chooser.Multiselect = true;
            DialogResult result = chooser.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                try
                {
                    ebdfiles = chooser.FileNames;
                    string menesiodir = Path.GetDirectoryName(ebdfiles[0]);
                    foreach (string ebdfile in ebdfiles)
                    {
                        string ebdnumber = Path.GetFileName(ebdfile).Substring(12, 4);
                        string ebdname = Path.GetFileName(ebdfile);
                        foreach (string d in Directory.GetDirectories(menesiodir))
                        {
                            if (d.Contains(ebdnumber))
                            {
                                //copy ebd
                                System.IO.File.Copy(ebdfile, d + "\\" + ebdname, true);
                            }
                        }//for
                    }//for

                    MessageBox.Show("Baigta", "FULL TEXT");
                    pbEbd.Visible = true;
                }
                catch (IOException)
                {
                    MessageBox.Show("Nepavyko nukopijuoti EBD!", "FULL TEXT");
                    pbEbd.Visible = false;
                }
            }//if OK
            else return;
        }


        private void TicksVisible()
        {
            pbEbd.Visible = true;
            pbPdf.Visible = true;
            pbUnzip.Visible = true;
            pbIkelti.Visible = true;
            pbXslt.Visible = true;
            pbZipbebiblio.Visible = true;

        }

        private void TicksUnvisible()
        {
            pbEbd.Visible = false;
            pbPdf.Visible = false;
            pbUnzip.Visible = false;
            pbIkelti.Visible = false;
            pbXslt.Visible = false;
            pbZipbebiblio.Visible = false;

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked) TicksVisible();
            else
                TicksUnvisible();
        }

        private void Langas_Load(object sender, EventArgs e)
        {
            TicksUnvisible();
            if (wrkdir != null)
            {
                try
                {
                    vienuVeiksmu(wrkdir);
                    this.Close();
                    Environment.Exit(0);
                }
                catch (DirectoryNotFoundException die)
                {
                    MessageBox.Show("Nerastas patentų aplankas: " + die.Message, "FULL TEXT");
                }
                finally
                {
                    Environment.Exit(0);
                }
            }//if
        }

        private void btnZipbebiblio_Click(object sender, EventArgs e)
        {
            FolderSelectDialog fs = new FolderSelectDialog();
            fs.Title = "Pasirinkite aplankus zip failams be bibliografijos sudaryti";
            fs.InitialDirectory = initdir;
            string[] aplankai = null;
            if (fs.ShowDialog(IntPtr.Zero))
            {
                aplankai = fs.FileNames;
            }
            else return;

            lt.vinco.Fulltextpro.Zipbebibl(aplankai);
            pbZipbebiblio.Visible = true;
            MessageBox.Show("Baigta", "FULL TEXT");
        }

        private void btnVveiksmu_Click(object sender, EventArgs e)
        {
           
            folderChooser.ShowNewFolderButton = false;
            folderChooser.Description = "Pasirinkite aplanką su patentų FULLTEXT, EBD (xml), pdf.zip, simple-patent-document-v1-9.dtd ir full.xsl failais:";
            folderChooser.RootFolder = System.Environment.SpecialFolder.Desktop;

            DialogResult res = this.folderChooser.ShowDialog();
            if (res == DialogResult.OK)
            {
                // the code here will be executed if the user presses Open in
                // the dialog.
            }
            else return;

           string workingdir = this.folderChooser.SelectedPath;
            
           vienuVeiksmu(workingdir);
          
        }//btn vienu veiksmu



        private void vienuVeiksmu(string workingdir)
        {
           
            foreach (string f in Directory.GetFiles(workingdir))  //išzipavimas
            {
                lt.vinco.Fulltextpro.unzip(f);
            }
            pbUnzip.Visible = true;

            //end išzipavimas 


            //pdf:
            string pdfdir = workingdir + "\\" + "pdf";
            if (!Directory.Exists(pdfdir))
            {
                MessageBox.Show("Nerastas PDFų aplankas");
                return;
            }
            lt.vinco.Fulltextpro.pdf(pdfdir);
            //   MessageBox.Show("PDFai perkelti");
            pbPdf.Visible = true;

            //----------------
            string[] ebdfiles = System.IO.Directory.GetFiles(workingdir, "*.xml");
            try
            {
                foreach (string ebdfile in ebdfiles)
                {
                    string ebdnumber = Path.GetFileName(ebdfile).Substring(12, 4);
                    string ebdname = Path.GetFileName(ebdfile);
                    foreach (string d in Directory.GetDirectories(workingdir))
                    {
                        if (d.Contains(ebdnumber))
                        {
                            //copy ebd
                            System.IO.File.Copy(ebdfile, d + "\\" + ebdname, true);
                        }
                    }//for
                }//for

                //      MessageBox.Show("EBD perkelti");
                pbEbd.Visible = true;
            }
            catch (IOException)
            {
                MessageBox.Show("Nepavyko nukopijuoti EBD!");
                pbEbd.Visible = false;
            }




            //ikelti    -------------
            string[] dirs = System.IO.Directory.GetDirectories(workingdir);


            System.Collections.ArrayList aplankai = new System.Collections.ArrayList();
            foreach (string dir in dirs)
            {
                Match match = Regex.Match(dir, @".*\d\d\d\d$", RegexOptions.IgnoreCase);
                if (match.Success) { aplankai.Add(dir); }
            }



            if (aplankai.Count < 1)
            {
                MessageBox.Show("Nėra patentų aplankų!", "FULL TEXT");
                return;
            }

            lt.vinco.Fulltextpro.ikelti((string[])aplankai.ToArray(typeof(string)));
            pbIkelti.Visible = true;
            //end ikelti


            //xslt------

            string stylesheet = workingdir + "\\full.xsl";
            lt.vinco.Fulltextpro.Xslt((string[])aplankai.ToArray(typeof(string)), stylesheet);
            pbXslt.Visible = true;
            //    MessageBox.Show("Baigta transformacija", "FULL TEXT");
            //end xslt




            //zip be biblio
            lt.vinco.Fulltextpro.Zipbebibl((string[])aplankai.ToArray(typeof(string)));
            pbZipbebiblio.Visible = true;
            //end zip be biblio
           
            if (wrkdir != null)
                System.Console.WriteLine("Visi darbai baigti!"); //neveikia
            else
                MessageBox.Show("Visi darbai baigti!", "FULL TEXT");
        }//vienuVeiksmu


     }//class

}//ns
//  backgroundWorker1.RunWorkerAsync();