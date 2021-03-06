﻿using System;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Configuration;

namespace Wexflow.Clients.Manager
{
    public static class Program
    {
        public static string WexflowServiceName = ConfigurationManager.AppSettings["WexflowServiceName"];
        public static bool DebugMode = false;

        [STAThread]
        static void Main(string[] args)
        {
            if (Environment.UserInteractive && System.Diagnostics.Debugger.IsAttached)
            {
                DebugMode = true;
            }

            RunForm();
        }

        static void RunForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool IsWexflowWindowsServiceRunning()
        {
            var sc = new ServiceController(WexflowServiceName);
            return sc.Status == ServiceControllerStatus.Running;
        }
    }
}
