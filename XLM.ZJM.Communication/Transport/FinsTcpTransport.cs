﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using XLM.ZJM.Communication.Interfaces;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/18 15:43:38                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.Communication.Transport
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/18 15:43:38</para>
    /// </summary>
    public class FinsTcpTransport : ITransport
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FinsTcpTransport()
        {

        }

        public bool Connected => throw new NotImplementedException();

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Connect(string ipAddress, int port)
        {
            throw new NotImplementedException();
        }

        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Receive(ref byte[] response, int length)
        {
            throw new NotImplementedException();
        }

        public int Receive(ref byte[] response, int length, SocketFlags socketFlags)
        {
            throw new NotImplementedException();
        }

        public int Send(byte[] request)
        {
            throw new NotImplementedException();
        }

        public int Send(byte[] request, int length)
        {
            throw new NotImplementedException();
        }

        public int Send(byte[] request, int length, SocketFlags socketFlags)
        {
            throw new NotImplementedException();
        }
    }
}
