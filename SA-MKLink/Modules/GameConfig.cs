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

        public void SetModName(string path)
        {
            if (path == null)
                return;

            modName = path;
            return;
        }

        public void SetModPath()
        {

            modPath = GetGamePath() + "\\mods\\" + GetModName();

        }
        public void SetGamePath(string path)
        {
            if (path == null)
                return;

            gamePath = path;
            return;
        }

        public void SetVSPath(string path)
        {
            if (path == null)
                return;

            VSPath = path;
            return;
        }

        public void SetConfig()
        {
            string txt = "config.ini";
            Console.WriteLine("Looking for config.ini...");

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
