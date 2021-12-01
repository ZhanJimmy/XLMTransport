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
    public sealed class ServerControl
    {
        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        private ServerControl()
        {

        }
        public static ServerControl Instance => Nested.instance;
        private class Nested
        {
            static Nested() { }
            internal static readonly ServerControl instance = new ServerControl();
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
                        Socket newSocket = ServerSocket.EndAccept(result);
                        var entity = new ReceiveEntity()
                        {
                            Client = newSocket,
                            Data = new byte[8]
                        };
                        newSocket.BeginReceive(entity.Data, 0, entity.Data.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), entity);
                    }
                    catch { }
                }, null);
            }
            catch
            {

            }
        }
        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                var entity = (ReceiveEntity)result.AsyncState;
                Socket ts = entity.Client;
                IPEndPoint remotePoint = (IPEndPoint)ts.RemoteEndPoint;
                if (entity.Data.Take(ServerHelper.ByteLen).ByteToHex() != ServerHelper.Header)
                {
                    List<byte> byteBack = new List<byte>();
                    byteBack.AddRange(entity.Data);
                    byteBack.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 });
                    ts.Send(byteBack.ToArray(), 0, byteBack.Count, SocketFlags.None);
                    ts.EndReceive(result);
                    return;
                }
                var byteLength = entity.Data.TakeLast(ServerHelper.ByteLen).ToArray();
                var length = byteLength.ToInt();
                byte[] buffer = new byte[length];
                ts.Receive(buffer, 0, length, SocketFlags.None);
                ts.EndReceive(result);
                {
                    if (byteLength.ByteToHex() == ServerHelper.HSHex && buffer.ByteToHex() == ServerHelper.CEHex)
                    {
                        // hand shake
                        List<byte> byteBack = new List<byte>();
                        byteBack.AddRange(entity.Data.Take(ServerHelper.ByteLen).ToArray());
                        byteBack.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                        byteBack.AddRange(remotePoint.Port.ToClientNode());
                        ts.Send(byteBack.ToArray(), 0, byteBack.Count, SocketFlags.None);
                        if (ClientList.IndexOf(ts) == -1)
                            ClientList.Add(ts);
                    }
                    if (byteLength.ByteToHex() == ServerHelper.RHex && remotePoint.Port == buffer.TakeLast(ServerHelper.ByteLen).ToArray().ClientNodeToPort())
                    {
                        var byteCommand = buffer.Take(ServerHelper.ByteLen).ToArray().ToCommand();
                        switch (byteCommand)
                        {
                            case 0x01:
                                {
                                    var sign = "380916794729FA52A023DAC6880D4FFB9D9DEA945C46D16F1EDDF057A560FEEE";
                                    var byteSign = Encoding.ASCII.GetBytes(sign);
                                    List<byte> byteBack = new List<byte>();
                                    byteBack.AddRange(entity.Data);
                                    byteBack.AddRange(buffer);
                                    byteBack.AddRange(byteSign.Length.ToByte());
                                    byteBack.AddRange(byteSign);
                                    ts.Send(byteBack.ToArray(), 0, byteBack.Count, SocketFlags.None);
                                }
                                break;
                            case 0x02:
                                {

                                }
                                break;
                            case 0x06:
                                {

                                }
                                break;
                            case 0x07:
                                {

                                }
                                break;
                            case 0x08:
                                {

                                }
                                break;
                        }
                    }
                    if (byteLength.ByteToHex() == ServerHelper.WHex && remotePoint.Port == buffer.TakeLast(ServerHelper.ByteLen).ToArray().ClientNodeToPort())
                    {
                        var byteCommand = buffer.Take(ServerHelper.ByteLen).ToArray().ToCommand();
                        switch (byteCommand)
                        {
                            case 0x03:
                                {

                                }
                                break;
                            case 0x04:
                                {

                                }
                                break;
                            case 0x05:
                                {

                                }
                                break;
                        }
                    }
                }

                var newEntity = new ReceiveEntity()
                {
                    Client = ts,
                    Data = new byte[entity.Data.Length]
                };
                ts.BeginReceive(newEntity.Data, 0, newEntity.Data.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), newEntity);
            }
            catch { }
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
                        Socket client = ClientList[index];
                        if (client.Poll(1000, SelectMode.SelectRead) && client.Available == 0)
                        {
                            IPEndPoint point = (IPEndPoint)client.RemoteEndPoint;//将远端节点转为ip和端口
                            Console.WriteLine("IP {0}:{1} connect fail", point.Address, point.Port);//显示接入信息
                            client.Close();
                            ClientList.RemoveAt(index);
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        /// <summary>
        /// 接收实体
        /// </summary>
        private class ReceiveEntity
        {
            public Socket Client { get; set; }

            public byte[] Data { get; set; }
        }
        #endregion
    }
}
