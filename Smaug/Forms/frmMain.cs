using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Smaug.Requests;
using Smaug.Utils;
using System.Threading;
using Smaug.Controller;

namespace Smaug
{
    public partial class frmMain : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public frmMain()
        {            
            foreach (var c in Elements.ExtendedFixturesCountries)
            {
                Elements.EFList.Add(new EFCountries { State = c, Checked = false });
            }

            InitializeComponent();
            AllocConsole();
            GetExtendedFixtures();
            tmrEFixtures.Start();
        }

        private void GetExtendedFixtures()
        {
            ThreadPool.SetMaxThreads(5, 5);

            foreach (var e in Elements.EFList)
            {
                //ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessEFByCountry), e);
                //Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} Started a task");
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessHLCountry),"o");
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} Started result task");
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
                var doc = Feed.GetResults();
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
