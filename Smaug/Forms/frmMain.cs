using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Smaug.Requests;
using Smaug.Utils;

namespace Smaug
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            GetHighlights();

        }
        
        private void GetHighlights()
        {
            var c = new MyConsole();
            c.WriteLine("aa");
        }

        private void GetExtendedFixtures()
        {
            var doc = Feed.GetExtendedFixtures();
            foreach (var element in doc.Descendants("league"))
            {
                
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
