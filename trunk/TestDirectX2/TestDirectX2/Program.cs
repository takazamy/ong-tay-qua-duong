using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestDirectX2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (Form1 frm = new Form1())
            //{
            //    // Show our form and initialize our graphics engine
            //    frm.Show();

            //    Application.Run(frm);
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Form1 mainForm = new Form1();

            Application.Exit();
        }
    }
}
