using System;
using DSSEM.View;
using System.Windows.Forms;

namespace DSSEM
{
    public static class Program
    {

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreenView());
        }

    }
}
