using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SA_MKLink.Modules;

namespace SA_MKLink
{
    public partial class SAMkLink : Form
    {

        GameConfig Game = new GameConfig();

        public SAMkLink()
        {
            InitializeComponent();
            Game.SetConfig();
            SetAndDisplayPath();
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
            StreamWriter sw = new StreamWriter(modPath + "\\mod.ini");
            sw.WriteLine("Name=" + Game.GetModName());
            sw.WriteLine("Author=" + Environment.UserName);
            sw.WriteLine("Version=0.1");
            sw.WriteLine("Description=" + "my epic mod");
            sw.WriteLine("DLLFile=" + modname + ".dll");
            sw.Close();
        }

        private void MKLink_Button(object sender, EventArgs e)
        {
            var modname = Game.GetModName();
            var vspath = Game.GetVSPath();


            if (Game.GetGamePath() == null || vspath == null || modname == null)
            {
                string error = "Please fill out all fields completely.";
                MessageBox.Show(error, "Uncomplete");
                return;
            }

            if (!Directory.Exists(vspath + "\\" + modname))
            {
                string error = "Error when trying to access to the VS Project Folder, make sure the path is correct and the mod name match your VS Folder name.";
                MessageBox.Show(error, "Visual Studio Project folder not found");
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
                string error = "Error when trying to access to the DLL from your VS Project Folder, did you forget to build the DLL?";
                MessageBox.Show(error, "DLL Mod not found");
                return;
            }


            string modPath = Game.GetModPath();

            if (!Directory.Exists(modPath))
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

            string fullModDll = modPath + "\\" + modname + ".dll";
            RunMkLink(fullModDll, fullVSDllPath);
        }

        private void textBoxModName_TextChanged(object sender, EventArgs e)
        {
            Game.SetModName(textBox3.Text);
            Game.SetModPath();
            return;
        }
    }
}
