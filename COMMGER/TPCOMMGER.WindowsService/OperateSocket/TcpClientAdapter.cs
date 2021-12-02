using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/12/2 17:03:46                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.WindowsService.OperateSocket
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/12/2 17:03:46</para>
    /// </summary>
    internal sealed class TcpClientAdapter
    {
        private string _ip;
        private int _port;
        /// <summary>
        /// 构造函数
        /// </summary>
        internal TcpClientAdapter(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        internal TcpClientAdapter(string ip, string port)
        {
            _ip = ip;
            _port = int.Parse(port);
        }

        internal void Run()
        {
            if (string.IsNullOrEmpty(_ip)) return;
            TcpClient client = new TcpClient();
            client.BeginConnect(IPAddress.Parse(_ip), _port, TcpConnect, client);
        }

        private void TcpConnect(IAsyncResult result)
        {
            try
            {
                TcpClient client = (TcpClient)result.AsyncState;
                if (!client.Connected)
                {
                    client.Close();
                    var tc = new TcpClient();
                    tc.BeginConnect(IPAddress.Parse(_ip), _port, TcpConnect, tc);
                    HandleDisconnect?.Invoke();
                }
                else
                {
                    client.EndConnect(result);
                    HandleSuccess?.Invoke(client.Client);
                }
            }
            catch { }
        }

        internal Action HandleDisconnect { get; set; }
        internal Action<Socket> HandleSuccess { get; set; }
    }
}
