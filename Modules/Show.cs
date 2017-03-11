using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ligen.Modules
{
    public static class Show
    {
        public static void ping()
        {

            Form f = new Form();




            new System.Threading.Thread(() => f.ShowDialog()).Start();

        }
    }
}
