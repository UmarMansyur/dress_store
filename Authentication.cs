using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication9
{
    class Authentication
    {
        public static string Id { set; get; }
        public static string Level { get; set; }

        public static bool cekLogin()
        {
            if (Id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
