using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/30 17:03:15                                          
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
    /// <para>时间：2021/11/30 17:03:15</para>
    /// </summary>
    public sealed class SocketServerControl
    {
        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        private SocketServerControl()
        {

        }
        public static SocketServerControl Instance => Nested.instance;
        private class Nested
        {
            static Nested() { }
            internal static readonly SocketServerControl instance = new SocketServerControl();
        }
        #endregion

        #region
        private Socket ServerSocket;
        private ObservableCollection<Socket> ClientList = null;
        #endregion

        /// <summary>
        /// 开启服务
        /// </summary>
        public void BeginServer()
        {
            ClientList = new ObservableCollection<Socket>();
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 816));
            ServerSocket.Listen(1000);
            Console.WriteLine("start server succeed");
            ListenAccept();
            ListenShutdown();
        }

        #region listen
        /// <summary>
        /// 监听 接收
        /// </summary>
        private void ListenAccept()
        {
            try
            {
                ServerSocket.BeginAccept(result =>
                {
                    try
                    {
                        var newSocket = ServerSocket.EndAccept(result);
                        IPEndPoint point = newSocket.RemoteEndPoint as IPEndPoint;//将远端节点转为ip和端口
                        Console.WriteLine("IP {0}:{1} connect succeed", point.Address, point.Port);//显示接入信息
                        ClientList.Add(newSocket);
                        byte[] buffer = new byte[1024];
                        newSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((rs) =>
                        {
                            Socket ts = (Socket)rs.AsyncState;
                            ts.EndReceive(rs);
                            Console.WriteLine($"接收数据-->>{Encoding.UTF8.GetString(buffer, 0, buffer.Length)}");

                        }), newSocket);
                    }
                    catch { }
                }, null);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 监听 断开
        /// </summary>
        private void ListenShutdown()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    for (var index = 0; index < ClientList.Count; index++)
                    {
                        var client = ClientList[index];
                        if (client.Poll(1000, SelectMode.SelectRead) && client.Available == 0)
                        {
                            IPEndPoint point = client.RemoteEndPoint as IPEndPoint;//将远端节点转为ip和端口
                            Console.WriteLine("IP {0}:{1} connect fail", point.Address, point.Port);//显示接入信息
                            client.Close();
                            ClientList.RemoveAt(index);
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        #endregion
    }
}
