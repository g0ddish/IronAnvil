using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;

namespace SB_Item_Creator
{
    class Value
    {
        public static string directory = @"C:\";
        public static bool direcselected = false;
        public static string itemrarity="common",maxstack="1",recoiltime="2",firetime="2";
        public static bool guntwohanded = false, meleetwohanded = false;
        public static bool recoil = false, level = false;
        public static bool dirready = false;
        public static string blueprinttier = "tier1";
        public static string ita1 = "1", ita2 = "1", ita3 = "1", ita4 = "1", ita5 = "1", ita6 = "1",im="1";
        public static int[,] recipe = new int[6, 6];
        

        public static string GetAppDataPath()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = System.IO.Path.Combine(dir, "SB Item Creator");
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}
