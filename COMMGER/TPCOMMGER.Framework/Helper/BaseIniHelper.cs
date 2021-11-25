using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/25 14:49:37                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.Framework.Helper
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/25 14:49:37</para>
    /// </summary>
    public static class BaseIniHelper
    {
        private static readonly object obj = new object();

        #region WIN 32 API
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        public static extern uint GetPrivateProfileStringA(string section, string key, string def, byte[] retVal, int size, string filePath);
        #endregion

        /// <summary>
        /// 写入单个值
        /// </summary>
        /// <param name="section">配置区域</param>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public static bool Write(string path, string section, string key, string value)
        {
            lock (obj)
            {
                WritePrivateProfileString(section, key, value, path);
                var result = Read(path, section, key);
                if (string.IsNullOrEmpty(result)) return false;
                else return true;
            }
        }
        /// <summary>
        /// 读取单个值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Read(string path, string section, string key, int capacity = 102400)
        {
            lock (obj)
            {
                StringBuilder temp = new StringBuilder(capacity);
                GetPrivateProfileString(section, key, "", temp, capacity, path);
                return temp.ToString();
            }
        }
        /// <summary>
        /// 读取所有 区域
        /// </summary>
        /// <param name="iniFilename"></param>
        /// <returns></returns>
        public static List<string> ReadSections(string path)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, path);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.UTF8.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }
        /// <summary>
        /// 读取当前区域下 所有 Key
        /// </summary>
        /// <param name="SectionName"></param>
        /// <param name="iniFilename"></param>
        /// <returns></returns>
        public static List<string> ReadKeys(string path, string section)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileStringA(section, null, null, buf, buf.Length, path);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.UTF8.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }
        /// <summary>
        /// 清除所有 键
        /// </summary>
        /// <param name="section"></param>
        /// <param name="lsKey"></param>
        public static void ClearKeys(string path, string section, params string[] lsKey)
        {
            foreach (var key in lsKey)
            {
                Write(path, section, key, null);
            }
        }
        /// <summary>
        /// 清除 整个文件
        /// </summary>
        public static void ClearKeys(string path)
        {
            var allSection = ReadSections(path);
            foreach (var section in allSection)
            {
                var allKey = ReadKeys(path, section);
                ClearKeys(path, section, allKey.ToArray());
            }
        }
    }
}
