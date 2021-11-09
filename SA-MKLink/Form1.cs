using System;
using System.IO;
using System.Windows.Forms;
using SA_MKLink.Modules;

namespace SA_MKLink
{
    public partial class SAMkLink : Form
    {

        GameConfig Game = new GameConfig();

        enum Error
        {
            FieldUncomplete,
            VSFolderNotFound,
            DLLModNotFound,
        }

        public SAMkLink()
        {
            InitializeComponent();
            Game.SetConfig();
            SetAndDisplayPath();
        }

        private void SavePathInformation()
        {
            Game.SetVSPath(textBoxVSPath.Text);
            Game.SetGamePath(textBoxGamePath.Text);

            Game.SetModName(textBox3.Text);
            Game.SetModPath();

            StreamWriter sw = new StreamWriter("config.ini");
            sw.WriteLine(textBoxVSPath.Text);
            sw.WriteLine(textBoxGamePath.Text);
            sw.Close();
        }

        private void SetAndDisplayPath()
        {
            if (Game.GetGamePath() != null)
            {
                textBoxGamePath.Text = Game.GetGamePath();
            }

            if (Game.GetVSPath() != null)
            {
                textBoxVSPath.Text = Game.GetVSPath();
            }
        }

        static private void ErrorHandler(Error error)
        {
            string errorMSG;

            switch (error)
            {
                case Error.FieldUncomplete:
                    errorMSG = "Please fill out all fields completely.";
                    MessageBox.Show(errorMSG, "Uncomplete");
                    return;
                case Error.VSFolderNotFound:
                     errorMSG = "Error when trying to access to the VS Project Folder, make sure the path is correct and the mod name match your VS Folder name.";
                    MessageBox.Show(errorMSG, "Visual Studio Project folder not found.");
                    return;
                case Error.DLLModNotFound:
                    errorMSG = "Error when trying to access to the DLL from your VS Project Folder, did you forget to build the DLL?";
                    MessageBox.Show(errorMSG, "DLL Mod not found");
                    return;

            }

            return;

        }

        static void RunMkLink(string modPath, string vsPath)
        {
            const string quote = "\"";
            string fullPath = "/K mklink " + quote + modPath + quote + " " + quote + vsPath + quote;
            System.Diagnostics.Process.Start("CMD.exe", fullPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Select_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GameLocation_Button(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowNewFolderButton = false;
            fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textBoxGamePath.Text = fbd.SelectedPath;

            }
        }

        private void VSLocation_Button(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowNewFolderButton = false;
            fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textBoxVSPath.Text = fbd.SelectedPath;
            }
        }

        private void CreateModFolder(string modPath, string modname)
        {
            string newModName = modname;
            newModName = newModName.Replace("-", " ");
            newModName = newModName.Replace("_", " ");

            StreamWriter sw = new StreamWriter(modPath + "\\mod.ini");
            sw.WriteLine("Name=" + newModName);
            sw.WriteLine("Author=" + Environment.UserName);
            sw.WriteLine("Version=0.1");
            sw.WriteLine("Description=" + "my epic mod!");
            sw.WriteLine("DLLFile=" + modname + ".dll");
            sw.Close();
            return;
        }

        private void MKLink_Button(object sender, EventArgs e)
        {

            SavePathInformation();

            var modname = Game.GetModName();
            var vspath = Game.GetVSPath();

            if (Game.GetGamePath() == null || vspath == null || modname == null)
            {
                ErrorHandler(Error.FieldUncomplete);
                return;
            }

            if (!Directory.Exists(vspath + "\\" + modname))
            {
                ErrorHandler(Error.VSFolderNotFound);
                return;
            }

            //try to get the DLL File from VS folder with bin, release and debug.
            string vsDLLPath = vspath + "\\" + modname;
            string fullVSDllPath = vsDLLPath + "\\bin\\" + modname + ".dll";
            bool isPathValid = false;

             if (File.Exists(fullVSDllPath))
             {
                 isPathValid = true;
             }
             else
             {
                 fullVSDllPath = vsDLLPath + "\\Release\\" + modname + ".dll";

                 if (File.Exists(fullVSDllPath))
                 {
                     isPathValid = true;
                 }
                 else
                 {
                     fullVSDllPath = vsDLLPath + "\\Debug\\" + modname + ".dll";

                     if (File.Exists(fullVSDllPath))
                     {
                         isPathValid = true;
                     }
                 }
             }

            if (!isPathValid)
            {
                ErrorHandler(Error.DLLModNotFound);
                return;
            }


            //try to get the mod folder where the game is installed.
            string modPath = Game.GetModPath();

            if (!Directory.Exists(modPath))
            {
                //if the mod name doesn't match, try to remove any underscore just in case the user didn't use them for the mod folder.
                string newModName = modname;
                newModName = newModName.Replace("-", " ");
                newModName = newModName.Replace("_", " ");

                string newModPath = Game.GetModFolder() + "\\" + newModName;

                //if everything above fail, ask the user to create the mod.
                if (!Directory.Exists(newModPath))
                {
                    string error = "Error when trying to access Mod Folder from the game, the mod doesn't seem to exist.\n" +
                    "Would you like the program to create and set the mod for you?";
                    DialogResult msg = MessageBox.Show(error,
                          "Mod not found", MessageBoxButtons.YesNo);

                    switch (msg)
                    {
                        case DialogResult.Yes:
                            Directory.CreateDirectory(modPath);
                            CreateModFolder(modPath, modname);
                            break;
                        case DialogResult.No:
                            return;
                    }
                }
                else
                {
                    modPath = newModPath;
                }
            }

            string fullModDll = modPath + "\\" + modname + ".dll";
            RunMkLink(fullModDll, fullVSDllPath);
        }

        private void textBoxModName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
