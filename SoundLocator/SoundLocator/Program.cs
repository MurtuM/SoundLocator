using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundLocator
{
    class TransparentForm : Form1
    {
        public TransparentForm()
        {
            m_pure_overlay = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new Form1();
            Application.Run(f);
            
            if (f.m_pure_overlay)
                Application.Run(new TransparentForm());
        }
    }
}
