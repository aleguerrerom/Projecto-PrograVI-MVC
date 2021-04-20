using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using WindowsService;
using System.Configuration;

namespace WindowsService
{
    partial class WSMail : ServiceBase
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        public WSMail()
        {
            InitializeComponent();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BW_SW.RunWorkerAsync();
        }

        public void Iniciar()
        {
            timer.Interval = new TimeSpan(0, Convert.ToInt32(ConfigurationManager.AppSettings["Minutos_SW"]), 0).TotalMilliseconds;
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        protected override void OnStart(string[] args)
        {
            Iniciar();
        }

        protected override void OnStop()
        {
            T_SW.Stop();
        }

        

        private void T_SW_Tick(object sender, EventArgs e)
        {

        }

        private void BW_SW_DoWork(object sender, DoWorkEventArgs e)
        {
            timer.Stop();
            BLiniciador vloinicar = new BLiniciador();
            vloinicar.ObtenerCorreos();
        }

        private void BW_SW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Stop();
        }

        private void BW_SW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
