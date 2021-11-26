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
*│　创建时间：2021/11/18 11:12:06                                          
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
	/// <para>时间：2021/11/18 11:12:06</para>
	/// </summary>
	[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
	public class udpTransport : ITransport
	{
		private IPEndPoint KHDakTku3;

		private Socket xbkXhgJib;

		private int DptefFEpe;

		private Ping nfriCDnHq;

		private PingReply bntdeYMIi;

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
				return xbkXhgJib != null && xbkXhgJib.Connected;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public udpTransport()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Mr7uTkdKIb9TFESDMR.psydQZ3zY4Hen();
			KHDakTku3 = null;
			xbkXhgJib = null;
			DptefFEpe = 2000;
			nfriCDnHq = null;
			bntdeYMIi = null;
			base..ctor();
			nfriCDnHq = new Ping();
			KHDakTku3 = new IPEndPoint(0L, 0);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetTCPParams(IPAddress ip, int port)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			KHDakTku3.Address = ip;
			KHDakTku3.Port = port;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Connect()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			xbkXhgJib = new Socket(KHDakTku3.AddressFamily, SocketType.Stream, ProtocolType.Udp);
			xbkXhgJib.SendTimeout = DptefFEpe;
			xbkXhgJib.Connect(KHDakTku3);
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
			if (xbkXhgJib != null)
			{
				if (Connected)
				{
					xbkXhgJib.Disconnect(reuseSocket: false);
					xbkXhgJib.Close();
				}
				xbkXhgJib.Dispose();
				xbkXhgJib = null;
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
			int num = xbkXhgJib.Send(command, cmdLen, SocketFlags.None);
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
			int num = xbkXhgJib.Receive(response, respLen, SocketFlags.None);
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
			if (KHDakTku3.Address == null)
			{
				return false;
			}
			bntdeYMIi = nfriCDnHq.Send(KHDakTku3.Address, DptefFEpe);
			return (bntdeYMIi.Status == IPStatus.Success) ? true : false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static udpTransport()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LicenseManager.Validate(typeof(udpTransport));
		}
	}
}
