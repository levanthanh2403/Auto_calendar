using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.auto.Helper
{
    public class NetworkDriveMapper
    {
        public static void MapNetworkDrive(string driveLetter, string networkPath, string username, string password)
        {
            string arguments = $"use {driveLetter}: {networkPath} /user:{username} {password}";
            ProcessStartInfo processStartInfo = new ProcessStartInfo("net", arguments)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
            }
        }
    }
}
