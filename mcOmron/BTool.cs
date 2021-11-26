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
*│　创建时间：2021/11/18 11:08:33                                          
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
	/// <para>时间：2021/11/18 11:08:33</para>
	/// </summary>
	[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
	public static class BTool
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] Uint16toBytes(ushort value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = new byte[2];
			array[1] = (byte)(value & 0xFFu);
			array[0] = (byte)((uint)(value >> 8) & 0xFFu);
			return array;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte[] Int16toBytes(short value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = new byte[2];
			array[1] = (byte)((uint)value & 0xFFu);
			array[0] = (byte)((uint)(value >> 8) & 0xFFu);
			return array;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ushort[] Uint32toUInt16(uint value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ushort[] array = new ushort[2];
			array[1] = (ushort)(value & 0xFFFFu);
			array[0] = (ushort)((value >> 16) & 0xFFFFu);
			return array;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static short[] Int32toInt16(int value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			short[] array = new short[2];
			array[1] = (short)(value & 0xFFFF);
			array[0] = (short)((value >> 16) & 0xFFFF);
			return array;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ushort BytesToUInt16(byte B1, byte B2)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ushort num = B1;
			num = (ushort)(num << 8);
			return (ushort)(num + Convert.ToUInt16(B2));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static short BytesToInt16(byte B1, byte B2)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			short num = B1;
			num = (short)(num << 8);
			return (short)(num + Convert.ToInt16(B2));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool IsBitSet(byte value, int position)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (position < 0 || position > 7)
			{
				throw new ArgumentOutOfRangeException(h6ptfFlEpeefrCDnHq.HRxMyvoA8(0), h6ptfFlEpeefrCDnHq.HRxMyvoA8(20));
			}
			return (value & (1 << position)) != 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte SetBit(byte value, int position)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (position < 0 || position > 7)
			{
				throw new ArgumentOutOfRangeException(h6ptfFlEpeefrCDnHq.HRxMyvoA8(0), h6ptfFlEpeefrCDnHq.HRxMyvoA8(20));
			}
			return (byte)(value | (1 << position));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte UnsetBit(byte value, int position)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (position < 0 || position > 7)
			{
				throw new ArgumentOutOfRangeException(h6ptfFlEpeefrCDnHq.HRxMyvoA8(0), h6ptfFlEpeefrCDnHq.HRxMyvoA8(20));
			}
			return (byte)(value & ~(1 << position));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static byte ToggleBit(byte value, int position)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (position < 0 || position > 7)
			{
				throw new ArgumentOutOfRangeException(h6ptfFlEpeefrCDnHq.HRxMyvoA8(0), h6ptfFlEpeefrCDnHq.HRxMyvoA8(20));
			}
			return (byte)(value ^ (1 << position));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string ToBinaryString(byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return Convert.ToString(value, 2).PadLeft(8, '0');
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static BTool()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LicenseManager.Validate(typeof(BTool));
		}
	}

}
