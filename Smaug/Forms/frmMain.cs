using System;
using System.Windows.Forms;
using Smaug.Requests;
using Smaug.Utils;
using System.Threading;
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
            GetExtendedFixtures();
            tmrEFixtures.Start();
        }

        private void GetExtendedFixtures()
        {
            ThreadPool.SetMaxThreads(5, 5);

            foreach (var e in Elements.EFList)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessEFByCountry), e);
                Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} Started a task");
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessHLCountry), e);
                Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} Started result task");
            }
        }

        public static void ProcessEFByCountry(object o)
        {
            try
            {
                var e = (EFCountries)o;                
                var doc = Feed.GetExtendedFixtures(e.State);
                FeedController.GeneralParse(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void ProcessHLCountry(object o)
        {
            try
            {
                var e = (EFCountries)o;
                var doc = Feed.GetResults(e.State);
                FeedController.HighlightParse(doc);
            }
            catch (Exception ex)
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
            
        }
    }
}
