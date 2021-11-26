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
*│　创建时间：2021/11/18 11:14:55                                          
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
	/// <para>时间：2021/11/18 11:14:55</para>
	/// </summary>
	internal class Hk4V7djHlCEoaA03kR
	{
		internal delegate void SFU4mbT3GMret7THonf(object o);

		internal static Module CN7L6nwku;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zNhdQZ33WQDj6(int typemdt)
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Type type = CN7L6nwku.ResolveType(33554432 + typemdt);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				MethodInfo method = (MethodInfo)CN7L6nwku.ResolveMethod(fieldInfo.MetadataToken + 100663296);
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Hk4V7djHlCEoaA03kR()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Mr7uTkdKIb9TFESDMR.psydQZ3zY4Hen();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Hk4V7djHlCEoaA03kR()
		{
			//Discarded unreachable code: IL_0002
			while (false)
			{
				_ = ((object[])null)[0];
			}
			Mr7uTkdKIb9TFESDMR.psydQZ3zY4Hen();
			CN7L6nwku = typeof(Hk4V7djHlCEoaA03kR).Assembly.ManifestModule;
		}
	}
}
