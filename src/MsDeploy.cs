using System;
using System.Diagnostics;
using System.IO;

namespace MsDeployFuncs
{
    public class MsDeploy
    {
        public static int RunRemoteCommandNetwork(string msdeployPath, string computerName, string username,
            string password, string command, TimeSpan timeout)
        {
             var args = string.Format(
                @"-verb:sync -source:runCommand=""{0}"",waitInterval={1} -dest:auto,computerName=""{2}"",username=""{3}"",password=""{4}""",
                command, timeout.TotalMilliseconds, computerName, username, password);

            var psi = new ProcessStartInfo
            {
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                FileName = msdeployPath,
                Arguments = args,
                UseShellExecute = false
            };

            var process = Process.Start(psi);
            if (process == null) return -1;

            process.WaitForExit((int)timeout.TotalMilliseconds);
            try
            {
                if (!process.HasExited)
                {
                    return -1;
                }
                if (process.ExitCode != 0)
                {
                    Console.WriteLine(process.StandardError.ReadToEnd());
                }
                return process.ExitCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

            return -1;
        }
        public static int RunRemoteCommand(string msdeployPath, string server, string username, string password,
            string command, TimeSpan timeout)
        {
            var args = string.Format(
                @"-verb:sync -source:runCommand=""{0}"",waitInterval={1} -dest:auto,wmsvc=""{2}"",authtype=basic,username=""{3}"",password=""{4}"" -allowUntrusted",
                command, timeout.TotalMilliseconds, server, username, password);

            var psi = new ProcessStartInfo
            {
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                FileName = msdeployPath,
                Arguments = args,
                UseShellExecute = false
            };

            var process = Process.Start(psi);
            if (process == null) return -1;

            process.WaitForExit((int)timeout.TotalMilliseconds);
            try
            {
                if (!process.HasExited)
                {
                    return -1;
                }
                if (process.ExitCode != 0)
                {
                    Console.WriteLine(process.StandardError.ReadToEnd());
                }
                return process.ExitCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

            return -1;
        }

        public static int SyncFileNetwork(string msdeployPath, string computerName, string username, string password,
            FileInfo sourceFile, FileInfo destFile, TimeSpan timeout)
        {
             if (!File.Exists(sourceFile.FullName))
            {
                Console.WriteLine("Couldn't find source file at {0}", sourceFile.FullName);
                return -1;
            }
            var src = sourceFile.FullName;
            var dest = destFile.FullName;

            var args = string.Format(
                @"-verb:sync -source:filepath=""{0}"" -dest:filePath=""{1}"",computerName=""{2}"",username=""{3}"",password=""{4}""",
                src, dest, computerName, username, password);

            var psi = new ProcessStartInfo
            {
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                FileName = msdeployPath,
                Arguments = args,
                UseShellExecute = false
            };

            var process = Process.Start(psi);
            if (process == null) return -1;

            process.WaitForExit((int)timeout.TotalMilliseconds);
            try
            {
                if (!process.HasExited)
                {
                    return -1;
                }
                if (process.ExitCode != 0)
                {
                    Console.WriteLine(process.StandardError.ReadToEnd());
                }
                return process.ExitCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public static int SyncFile(string msdeployPath, string server, string username, string password,
            FileInfo sourceFile, FileInfo destinationFile, TimeSpan timeout)
        {
            if (!File.Exists(sourceFile.FullName))
            {
                Console.WriteLine("Couldn't find source file at {0}", sourceFile.FullName);
                return -1;
            }
            var src = sourceFile.FullName;
            var dest = destinationFile.FullName;

            var args = string.Format(
                @"-verb:sync -source:filepath=""{0}"" -dest:filePath=""{1}"",wmsvc=""{2}"",authtype=basic,username=""{3}"",password=""{4}"" -allowUntrusted",
                src, dest, server, username, password);

            var psi = new ProcessStartInfo
            {
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                FileName = msdeployPath,
                Arguments = args,
                UseShellExecute = false
            };

            var process = Process.Start(psi);
            if (process == null) return -1;

            process.WaitForExit((int)timeout.TotalMilliseconds);
            try
            {
                if (!process.HasExited)
                {
                    return -1;
                }
                if (process.ExitCode != 0)
                {
                    Console.WriteLine(process.StandardError.ReadToEnd());
                }
                return process.ExitCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

    }
}
