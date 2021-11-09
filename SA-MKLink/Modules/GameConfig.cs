using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SA_MKLink.Modules
{
    class GameConfig
    {
        private static string VSPath;
        private static string modPath;
        private static string modName;
        private static string gamePath;

        public string GetGamePath()
        {
            return gamePath;
        }

        public string GetModPath()
        {
            return modPath;
        }

        public string GetVSPath()
        {
            return VSPath;
        }

        public string GetModName()
        {
            return modName;
        }

        public void SetModName(string name)
        {
            if (name == null || name == "")
                return;

            modName = name;
            return;
        }

        public void SetModPath()
        {

            modPath = GetGamePath() + "\\mods\\" + GetModName();

        }

        public string GetModFolder()
        {    
            return GetGamePath() + "\\mods\\";
        }

        public void SetGamePath(string path)
        {
            if (path == null || path == "")
                return;

            gamePath = path;
            return;
        }

        public void SetVSPath(string path)
        {
            if (path == null || path == "")
                return;

            VSPath = path;
            return;
        }

        public void SetConfig()
        {
            string txt = "config.ini";
            Console.WriteLine("Searching for config.ini...");

            try
            {
                using (var sr = new StreamReader(txt))
                {
                    string[] lines = File.ReadAllLines(txt);
                    SetVSPath(lines[0]);
                    SetGamePath(lines[1]);
                    Console.WriteLine("Found config.ini, setting paths.");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("No config.ini found.");
                return;
            }
        }




    }
}
