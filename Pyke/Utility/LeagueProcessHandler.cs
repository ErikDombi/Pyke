using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Pyke.Utility
{
    /// <summary>
    /// Manages the operations relating to the league client's process.
    /// </summary>
    internal class LeagueProcessHandler
    {
        private string ProcessName => IsLinux ? "LeagueClientUx.exe" : "LeagueClientUx";

        private bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        private bool IsMac => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// Triggers when the league client is exited.
        /// </summary>
        public event EventHandler Exited;

        /// <summary>
        /// The league client's process.
        /// </summary>
        public Process Process { get; private set; }

        /// <summary>
        /// The league client's executable path.
        /// </summary>
        public string ExecutablePath { get; private set; }

        /// <summary>
        /// Waits for the league client's process to start.
        /// </summary>
        /// <returns>True if the process was found successfully, otherwise false.</returns>
        public bool WaitForProcess()
        {
            if (IsLinux)
                return WaitForProcessLinux();
            else if (IsMac)
                return WaitForProcessMac();
            else
                return WaitForProcessWindows();
        }

        private bool WaitForProcessLinux(){
            while (true)
            {
                var processes = Process.GetProcessesByName(ProcessName);
                if (processes.Length > 0)
                {
                    if (Process != null)
                        Process.Exited -= OnProcessExited;

                    Process = processes[0];
                    Process.EnableRaisingEvents = true;
                    Process.Exited += OnProcessExited;

                    ExecutablePath = Path.GetDirectoryName($"/home/{Environment.UserName}/snap/leagueoflegends/common/.wine/drive_c/Riot Games/League of Legends/");
                    break;
                }

                Thread.Sleep(100);
            }

            return true;
        }

        private bool WaitForProcessMac()
        {
            while (true)
            {
                var processes = Process.GetProcessesByName(ProcessName);
                if (processes.Length > 0)
                {
                    if (Process != null)
                        Process.Exited -= OnProcessExited;

                    Process = processes[0];
                    Process.EnableRaisingEvents = true;
                    Process.Exited += OnProcessExited;

                    ExecutablePath = Path.GetDirectoryName($"/Applications/League of Legends.app/Contents/LoL/");
                    break;
                }

                Thread.Sleep(100);
            }

            return true;
        }

        private bool WaitForProcessWindows(){
            while (true)
            {
                var processes = Process.GetProcessesByName(ProcessName);
                if (processes.Length > 0)
                {
                    if (Process != null)
                        Process.Exited -= OnProcessExited;

                    Process = processes[0];
                    Process.EnableRaisingEvents = true;
                    Process.Exited += OnProcessExited;

                    ExecutablePath = Path.GetDirectoryName(Process.MainModule.FileName);
                    break;
                }

                Thread.Sleep(100);
            }

            return true;
        }

        /// <summary>
        /// Called when the league client is exited.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnProcessExited(object sender, EventArgs e)
        {
            Exited?.Invoke(sender, e);
        }
    }
}
