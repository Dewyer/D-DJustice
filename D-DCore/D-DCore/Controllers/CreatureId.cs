using System;
using System.Collections.Generic;
using System.Text;

namespace DCore.Controllers
{
    class CreatureId
    {
        public static string IdFromName(string name)
        {
            var b6 = Convert.ToBase64String(Encoding.UTF8.GetBytes(name));
            return b6;
        }
    }
}
