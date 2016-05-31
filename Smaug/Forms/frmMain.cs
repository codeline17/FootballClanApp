using System;
using System.Windows.Forms;
using Smaug.Data_Access;
using Smaug.Models;
using Smaug.Requests;
using Smaug.Utils;
using System.Threading;
using System.Linq;
using Smaug.Controller;

namespace Smaug
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            
            foreach (var c in Elements.ExtendedFixturesCountries)
            {
                Elements.EFList.Add(new EFCountries { State = c, Checked = false });
            }

            InitializeComponent();
            GetHighlights();
            GetExtendedFixtures();
        }
        
        private void GetHighlights()
        {
            ProcessHL();
        }

        private void GetExtendedFixtures()
        {
            ThreadPool.SetMaxThreads(5, 5);

            foreach (var e in Elements.EFList)
            {
                if (e.State == "international")
                {

                }
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessEFByCountry), e);
                Console.WriteLine($"Started a task");  
            }
        }

        public static void ProcessHL()
        {
            try
            {
                var doc = Feed.GetHighlights("today");
                var hl = Helper.FromXml<highlights>(doc.ToString());
                hl.SaveOrUpdate();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                
            }
        }

        public static void ProcessEFByCountry(object o)
        {
            try
            {
                var e = (EFCountries)o;

                if (e.State == "international")
                {

                }
                var doc = Feed.GetExtendedFixtures(e.State);

                FeedController.GeneralParse(doc);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                Console.WriteLine($"{ex.Message}");
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

        private void tmrEFixtures_Tick(object sender, EventArgs e)
        {
            GetExtendedFixtures();
        }

        private void tmrHighlights_Tick(object sender, EventArgs e)
        {
            GetHighlights();
        }
    }
}
