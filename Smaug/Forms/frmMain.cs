using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Smaug.Data_Access;
using Smaug.Models;
using Smaug.Requests;
using Smaug.Utils;
using System.Threading;

namespace Smaug
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            GetHighlights();
            GetExtendedFixtures();
        }
        
        private void GetHighlights()
        {
            /*var c = new MyConsole();
            c.WriteLine("aa");*/
        }

        private void GetExtendedFixtures()
        {
            ThreadPool.SetMaxThreads(5, 5);
            foreach (var country in Elements.ExtendedFixturesCountries)
            {
                var doc = Feed.GetExtendedFixtures(country);

                var ef = Helper.FromXml<extended_fixtures>(doc.ToString());

                if (ef != null)
                    ef.SaveOrUpdate();
            }
        }

        public void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), new object[] { text });
                return;
            }
            txtConsole.Text += Environment.NewLine + text;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gdMain.ResetBindings();
        }
    }
}
