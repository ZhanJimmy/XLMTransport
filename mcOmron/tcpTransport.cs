using System;
using System.Collections.Generic;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/18 11:11:25                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace mcOmron
{
	///  功能描述：
	/// <para>作者：jianmei.zhan</para>
	/// <para>邮箱：jianmei.zhan@yankon.com</para>
	/// <para>时间：2021/11/18 11:11:25</para>
	/// </summary>
	[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
	public class tcpTransport : ITransport
	{
		private IPEndPoint W8KCS96pt;

		private Socket XBww5ccCo;

		private int cRTVkuFCY;

		private Ping vSKYTkFCO;

		private PingReply pTg01wxVD;

		public bool Connected
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return XBww5ccCo != null && XBww5ccCo.Connected;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public tcpTransport()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Mr7uTkdKIb9TFESDMR.psydQZ3zY4Hen();
			W8KCS96pt = null;
			XBww5ccCo = null;
			cRTVkuFCY = 2000;
			vSKYTkFCO = null;
			pTg01wxVD = null;
			base..ctor();
			vSKYTkFCO = new Ping();
			W8KCS96pt = new IPEndPoint(0L, 0);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetTCPParams(IPAddress ip, int port)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			W8KCS96pt.Address = ip;
			W8KCS96pt.Port = port;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Connect()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			XBww5ccCo = new Socket(W8KCS96pt.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			XBww5ccCo.SendTimeout = cRTVkuFCY;
			XBww5ccCo.ReceiveTimeout = cRTVkuFCY;
			XBww5ccCo.Connect(W8KCS96pt);
			return Connected;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Close()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (XBww5ccCo != null)
			{
				if (Connected)
				{
					XBww5ccCo.Disconnect(reuseSocket: false);
					XBww5ccCo.Close();
				}
				XBww5ccCo.Dispose();
				XBww5ccCo = null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Send(ref byte[] command, int cmdLen)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!Connected)
			{
				throw new Exception(h6ptfFlEpeefrCDnHq.HRxMyvoA8(624));
			}
			int num = XBww5ccCo.Send(command, cmdLen, SocketFlags.None);
			if (num != cmdLen)
			{
				string message = string.Format(h6ptfFlEpeefrCDnHq.HRxMyvoA8(676), cmdLen, num);
				throw new Exception(message);
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Receive(ref byte[] response, int respLen)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!Connected)
			{
				throw new Exception(h6ptfFlEpeefrCDnHq.HRxMyvoA8(624));
			}
			int num = XBww5ccCo.Receive(response, respLen, SocketFlags.None);
			if (num != respLen)
			{
				string message = string.Format(h6ptfFlEpeefrCDnHq.HRxMyvoA8(774), respLen, num);
				throw new Exception(message);
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Ping()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (W8KCS96pt.Address == null)
			{
				return false;
			}
			pTg01wxVD = vSKYTkFCO.Send(W8KCS96pt.Address, cRTVkuFCY);
			return (pTg01wxVD.Status == IPStatus.Success) ? true : false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static tcpTransport()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LicenseManager.Validate(typeof(tcpTransport));
		}
	}
}
