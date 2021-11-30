
using System.Net.Sockets;
/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/16 16:59:16                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.Communication.Interfaces
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/16 16:59:16</para>
    /// </summary>
    public interface ITransport : IDisposable
    {
        bool Connected { get; }
        bool Connect();
        void Close();
        int Send(byte[] request);
        int Send(byte[] request, int length);
        int Send(byte[] request, int length, SocketFlags socketFlags);
        int Receive(ref byte[] response, int length);
        int Receive(ref byte[] response, int length, SocketFlags socketFlags);
    }
}
