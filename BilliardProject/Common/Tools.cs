using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BilliardProject.Common
{
    public static class Tools
    {
        public static string GetMACStr()
        {
            List<string> macs = new List<string>();
            var runCmd = ExecuteInCmd("chcp 437&&ipconfig/all");
            bool flag = false;
            foreach (var line in runCmd.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()))
            {
                if (line.StartsWith("Ethernet adapter"))
                {
                    flag = true;
                }
                if (!string.IsNullOrEmpty(line))
                {
                    if (line.StartsWith("Physical Address") && flag)
                    {
                        macs.Add(line.Substring(36));
                        return macs.Last().Replace("-", string.Empty);
                    }
                    else if (line.StartsWith("DNS Servers") && line.Length > 36 && line.Substring(36).Contains("::"))
                    {
                        macs.Clear();
                    }
                    else if (macs.Count > 0 && line.StartsWith("NetBIOS") && line.Contains("Enabled"))
                    {
                        return macs.Last();
                    }
                }
            }
            return macs.FirstOrDefault().Replace("-", string.Empty);
        }


        /// <summary>
		/// 执行内部命令（cmd.exe 中的命令）
		/// </summary>
		/// <param name="cmdline">命令行</param>
		/// <returns>执行结果</returns>
		public static string ExecuteInCmd(string cmdline)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmdline + "&exit");

                //获取cmd窗口的输出信息  
                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                process.Close();

                return output;
            }
        }
        /// <summary>  
        /// AES加密算法  
        /// </summary>  
        /// <param name="input">明文字符串</param>  
        /// <param name="key">密钥</param>  
        /// <returns>字符串</returns>  
        public static string EncryptByAES(string input)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.ECB;
            byte[] key = Encoding.Unicode.GetBytes("1234567890123456");
            aes.Key = key;

            byte[] data = Encoding.Unicode.GetBytes(input);
            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
            string res = Convert.ToBase64String(encryptedData);
            return res;
        }

        public static void ShutdownPC(bool isCancel, uint interval)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe"; // 启动命令行程序
            proc.StartInfo.UseShellExecute = false; // 不使用Shell来执行,用程序来执行
            proc.StartInfo.RedirectStandardError = true; // 重定向标准输入输出
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true; // 执行时不创建新窗口
            proc.Start();

            string commandLine;
            if (isCancel)
                commandLine = @"shutdown /a";
            else
                commandLine = @"shutdown /s /t " + interval.ToString();

            proc.StandardInput.WriteLine(commandLine);
        }
    }
}
