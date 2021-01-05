using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ADZFlash.ADB
{
    public static class ADBManager
    {
        static object obj = new object();
        public static List<string> GetListDevices()
        {
            try
            {
                List<string> devices = ExcuteCommandResult(ADBCommands.DEVICES);
                List<string> result = new List<string>();
                if (devices != null && devices.Count > 0)
                {
                    for (int i = 0; i < devices.Count; i++)
                    {
                        string[] array = devices[i].Split('\t');
                        if (array.Length >= 2)
                        {
                            if (array[1].Equals("fastboot"))
                                result.Add(array[0].Trim());
                        }
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static void ExcuteCommand(string command, int milisecondsTimeout = 10000)
        {
            try
            {
                //Logger.print(command);
                string batfile = Guid.NewGuid() + ".bat";
                string tempPath = Path.GetTempPath();
                string fileName = $"{tempPath}{batfile}";

                using (StreamWriter stw = new StreamWriter(fileName))
                {
                    stw.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "tools\\" + command);
                    stw.WriteLine("DEL \"%~f0\" & EXIT");
                    stw.Flush();
                    stw.Close();
                }

                var processInfo = new ProcessStartInfo("cmd.exe", "/c " + fileName);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;

                var process = Process.Start(processInfo);

                process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => Debug.WriteLine("output>>" + e.Data);
                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) => Debug.WriteLine("error>>" + e.Data);
                process.BeginErrorReadLine();

                process.WaitForExit();

                //Console.WriteLine("ExitCode: {0}", process.ExitCode);
                process.Close();

            }
            catch (Exception e)
            {

            }
        }

        public static List<string> ExcuteCommandResult(string command)
        {
            //lock (obj)
            {
                try
                {
                    List<string> result = new List<string>();
                    string[] arrays = Regex.Split(RunCMD(command), "\r\n", RegexOptions.IgnoreCase);
                    for (int i = 4; i < (arrays.Length - 1); i++)
                    {
                        if (!string.IsNullOrEmpty(arrays[i]))
                        {
                            result.Add(arrays[i]);
                        }
                    }

                    return result;
                }
                catch
                {
                    return new List<string>();
                }
            }
        }

        private static string RunCMD(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"tools",
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process process = Process.Start(processInfo);

                lock (obj)
                {
                    //UtilsHelper.UpdateLog(command);
                    process.StandardInput.WriteLine(command);
                }
                process.StandardInput.Flush();
                process.StandardInput.Close();

                string outputResult = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();

                return outputResult;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}