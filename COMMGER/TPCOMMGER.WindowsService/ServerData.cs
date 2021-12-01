using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/12/1 11:13:51                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.WindowsService
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/12/1 11:13:51</para>
    /// </summary>
    internal sealed class ServerData
    {
        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        private ServerData()
        {

        }
        private class Nested
        {
            static Nested() { }
            internal static readonly ServerData instance = new ServerData();
        }
        public static ServerData Instance => Nested.instance;
        private static readonly object locker = new object();
        #endregion

        /// <summary>
        /// 正在运行的数据
        /// </summary>
        internal ConcurrentDictionary<string, ConcurrentDictionary<string, object>> AllRunningData = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();

        /// <summary>
        /// 获取 指定 IP 数据
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        internal ConcurrentDictionary<string, object> GetIpData(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress)) return null;
            if (!AllRunningData.ContainsKey(ipAddress)) return null;
            return AllRunningData[ipAddress];
        }

        /// <summary>
        /// 获取 指定 IP 地址 数据
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        internal object GetIpAddressData(string ipAddress, string address)
        {
            if (string.IsNullOrEmpty(address)) return null;
            var data = GetIpData(ipAddress);
            if (data == null) return null;
            if (!data.ContainsKey(address)) return null;
            return data[address];
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="address"></param>
        /// <param name="data"></param>
        internal void AddIpAddressData(string ipAddress, string address, object data)
        {
            lock (locker)
            {
                if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(address) || data == null) return;
                if (AllRunningData.ContainsKey(ipAddress) == false)
                {
                    ConcurrentDictionary<string, object> dic = new ConcurrentDictionary<string, object>();
                    dic.TryAdd(address, data);
                    AllRunningData.TryAdd(ipAddress, dic);
                }
                else
                {
                    if (AllRunningData.TryGetValue(ipAddress, out ConcurrentDictionary<string, object> dic) == false) return;
                    if (dic.ContainsKey(address) == false) dic.TryAdd(address, data);
                    else dic[address] = data;
                }
            }
        }
    }
}
