using System;
using System.Diagnostics;
using System.Threading;

namespace QuickConnectPlugin.Commons {

    public static class ProcessUtils {

        public static void StartDetached(String processCommand, TimeSpan delay) {
            ThreadStart threadStart = delegate() {
                Thread.Sleep(delay);
                StartDetached(processCommand);
            };
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        public static void StartDetached(String processCommand) {
            using (Process process = new Process()) {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine(processCommand);
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }

        public static void Start(String path, String processCommand) {
            using (Process process = new Process()) {
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = processCommand;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
            }
        }
    }
}
