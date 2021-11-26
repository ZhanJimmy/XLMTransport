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
*│　创建时间：2021/11/18 11:08:58                                          
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
	/// <para>时间：2021/11/18 11:08:58</para>
	/// </summary>
	[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
	public class DDM
	{
		private uint jRlppHwJb;

		private int ilZ4kYWDt;

		public uint Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return jRlppHwJb;
			}
		}

		public int SValue
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return ilZ4kYWDt;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DDM()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Mr7uTkdKIb9TFESDMR.psydQZ3zY4Hen();
			base..ctor();
			jRlppHwJb = 0u;
			ilZ4kYWDt = 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public uint Set(ushort word1, ushort word2)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			jRlppHwJb = (uint)(word1 + (word2 << 16));
			return jRlppHwJb;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Set(short word1, short word2)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ilZ4kYWDt = word1 + (word2 << 16);
			return ilZ4kYWDt;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string ToString(string format = "")
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Value.ToString(format);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static DDM()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LicenseManager.Validate(typeof(DDM));
		}
	}
}
