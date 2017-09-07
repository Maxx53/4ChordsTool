using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _4ChordsTool
{
    public static class Utils
    {
        public static void StartCmdLine(string process, string param, bool wait)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(process, param);
            p.Start();
            if (wait)
            {
                p.WaitForExit();
            }
        }

        public static string NamingDLC(string input)
        {
            //TODO: Remove forbidden symbols
            return input.Replace(" ", "").Trim().ToLower();
        }

        public static List<string> GetUniqChords(string input)
        {
            Regex reg_exp = new Regex("[^a-zA-Z0-9]");
            input = reg_exp.Replace(input, " ");

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var word_query = (from string word in words orderby word select word).Distinct();

            return word_query.ToList<string>();
        }

        public static void RemoveFiles(string path)
        {
            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }
        }

        public static void CopyFiles(string sourcePath, string targetPath)
        {
            if (Directory.Exists(sourcePath))
            {
                string fileName = string.Empty;
                string destFile = string.Empty;

                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                    File.SetAttributes(destFile, FileAttributes.Normal);
                }
            }
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            var attr = enumValue.GetType().GetMember(enumValue.ToString())
                   .First()
                   .GetCustomAttribute<DisplayAttribute>();

            if (attr != null)
                return attr.Name;
            else
                return enumValue.ToString();

        }

        public static int getRandomId()
        {
            var random = new Random();
            return random.Next(1000000, 9999999);
        }

        //Not used yet (
        public static string ComputeMD4(string input)
        {
            byte[] unicodeBytes = Encoding.ASCII.GetBytes(input);

            using (HashAlgorithm hash = new MD4())
            {
                var res = hash.ComputeHash(unicodeBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < res.Length; i++)
                {
                    sb.Append(res[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
