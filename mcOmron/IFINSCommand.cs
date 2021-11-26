﻿using System;
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
*│　创建时间：2021/11/18 11:09:27                                          
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
	/// <para>时间：2021/11/18 11:09:27</para>
	/// </summary>
	[LicenseProvider(typeof(E4VhgTpmI0OExW7jOPa))]
	public interface IFINSCommand
	{
		bool Connected { get; }

		string LastError { get; }

		ITransport Transport { get; }

		byte[] Response { get; }

		bool Connect();

		void Close();

		bool MemoryAreaRead(MemoryArea area, ushort address, byte bit_position, ushort count);

		bool MemoryAreaWrite(MemoryArea area, ushort address, byte bit_position, ushort count, ref byte[] data);

		bool ConnectionDataRead(byte area);

		string LastDialog(string Caption);
	}
}
