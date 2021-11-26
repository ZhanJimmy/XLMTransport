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
*│　创建时间：2021/11/18 11:10:40                                          
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
	/// <para>时间：2021/11/18 11:10:40</para>
	/// </summary>
	[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
	public class OmronPLC
	{
		[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
		public static class IniFile
		{
			[DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
			private static extern long t8LuM8k1F(string  , string  , string  , string  );

			[DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
			private static extern long RpVEnPGr0(string  , string  , string  , StringBuilder  , int  , string  );

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				if (File.Exists(iniFilePath))
				{
					StringBuilder stringBuilder = new StringBuilder(1024);
					RpVEnPGr0(Section, Key, NoText, stringBuilder, 1024, iniFilePath);
					return stringBuilder.ToString();
				}
				return string.Empty;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				if (File.Exists(iniFilePath))
				{
					long num = t8LuM8k1F(Section, Key, Value, iniFilePath);
					if (num == 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static IniFile()
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				LicenseManager.Validate(typeof(IniFile));
			}
		}

		private IFINSCommand lA0U3kR1l;

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
				return lA0U3kR1l.Connected;
			}
		}

		public string LastError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return lA0U3kR1l.LastError;
			}
		}

		public IFINSCommand FinsCommand
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				//Discarded unreachable code: IL_0002
				while (false)
				{
					_ = ((object[])null)[0];
				}
				return lA0U3kR1l;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OmronPLC(TransportType TType)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Mr7uTkdKIb9TFESDMR.psydQZ3zY4Hen();
			base..ctor();
			if (TType == TransportType.Tcp)
			{
				lA0U3kR1l = new tcpFINSCommand(1);
				return;
			}
			throw new Exception(h6ptfFlEpeefrCDnHq.HRxMyvoA8(566));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Connect()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lA0U3kR1l.Connect();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Close()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			lA0U3kR1l.Close();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool finsMemoryAreadRead(MemoryArea area, ushort address, byte bit_position, ushort count)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lA0U3kR1l.MemoryAreaRead(area, address, bit_position, count);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool finsMemoryAreadWrite(MemoryArea area, ushort address, byte bit_position, ushort count, byte[] data)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lA0U3kR1l.MemoryAreaWrite(area, address, bit_position, count, ref data);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool finsConnectionDataRead(byte area)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return lA0U3kR1l.ConnectionDataRead(area);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadDM(ushort position, ref ushort value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!finsMemoryAreadRead(MemoryArea.DM, position, 0, 1))
			{
				return false;
			}
			value = BTool.BytesToUInt16(lA0U3kR1l.Response[0], lA0U3kR1l.Response[1]);
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadDM(ushort position, ref short value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!finsMemoryAreadRead(MemoryArea.DM, position, 0, 1))
			{
				return false;
			}
			value = BTool.BytesToInt16(lA0U3kR1l.Response[0], lA0U3kR1l.Response[1]);
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public short ReadDM_Short(ushort start)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			short value = 0;
			ReadDM(start, ref value);
			return value;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ushort ReadDM_UShort(ushort start)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			ushort value = 0;
			ReadDM(start, ref value);
			return value;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadDMs(ushort position, ref ushort[] data, ushort count)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!finsMemoryAreadRead(MemoryArea.DM, position, 0, count))
			{
				return false;
			}
			for (int i = 0; i < count; i++)
			{
				data[i] = BTool.BytesToUInt16(lA0U3kR1l.Response[i * 2], lA0U3kR1l.Response[i * 2 + 1]);
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool WriteDM(ushort position, ushort value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] data = BTool.Uint16toBytes(value);
			return finsMemoryAreadWrite(MemoryArea.DM, position, 0, 1, data);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool WriteDM(ushort position, short value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] data = BTool.Int16toBytes(value);
			return finsMemoryAreadWrite(MemoryArea.DM, position, 0, 1, data);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ClearDMs(ushort position, ushort count)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte[] array = new byte[count * 2];
			int num = 0;
			while (num < count * 2)
			{
				array[num++] = 0;
			}
			return finsMemoryAreadWrite(MemoryArea.DM, position, 0, count, array);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadCIOBit(ushort position, byte bit_position, ref byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!finsMemoryAreadRead(MemoryArea.CIO_Bit, position, bit_position, 1))
			{
				return false;
			}
			value = lA0U3kR1l.Response[0];
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool WriteCIOBit(ushort position, byte bit_position, byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return finsMemoryAreadWrite(MemoryArea.CIO_Bit, position, bit_position, 1, new byte[1] { value });
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadWBit(ushort position, byte bit_position, ref byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!finsMemoryAreadRead(MemoryArea.WR_Bit, position, bit_position, 1))
			{
				return false;
			}
			value = lA0U3kR1l.Response[0];
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool WriteWBit(ushort position, byte bit_position, byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return finsMemoryAreadWrite(MemoryArea.WR_Bit, position, bit_position, 1, new byte[1] { value });
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool ReadHBit(ushort position, byte bit_position, ref byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (!finsMemoryAreadRead(MemoryArea.HR_Bit, position, bit_position, 1))
			{
				return false;
			}
			value = lA0U3kR1l.Response[0];
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool WriteHBit(ushort position, byte bit_position, byte value)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return finsMemoryAreadWrite(MemoryArea.HR_Bit, position, bit_position, 1, new byte[1] { value });
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int ReadBitCIO(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte value = 0;
			ReadCIOBit(start, bit, ref value);
			return lA0U3kR1l.Response[0];
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int SetBitCIO(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WriteCIOBit(start, bit, 1))
			{
				return 1;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int ReSetBitCIO(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WriteCIOBit(start, bit, 0))
			{
				return 1;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int ReadBitW(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte value = 0;
			ReadWBit(start, bit, ref value);
			return lA0U3kR1l.Response[0];
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int SetBitW(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WriteWBit(start, bit, 1))
			{
				return 1;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int ReSetBitW(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WriteWBit(start, bit, 0))
			{
				return 1;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int ReadBitH(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			byte value = 0;
			ReadHBit(start, bit, ref value);
			return lA0U3kR1l.Response[0];
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int SetBitH(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WriteHBit(start, bit, 1))
			{
				return 1;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int ReSetBitH(ushort start, byte bit)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			if (WriteHBit(start, bit, 0))
			{
				return 1;
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string LastDialog(string Caption)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			return FinsCommand.LastDialog(Caption);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static OmronPLC()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			LicenseManager.Validate(typeof(OmronPLC));
		}
	}
}
