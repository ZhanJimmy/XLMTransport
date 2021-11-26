using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/18 10:33:01                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.Communication.CusEnum
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/18 10:33:01</para>
    /// </summary>
    public enum FinsTcpArea
    {
		CIO_Bit = 0x30,
		WR_Bit = 0x31,
		HR_Bit = 0x32,
		AR_Bit = 0x33,
		CIO_Bit_FS = 0x70,
		WR_Bit_FS = 0x71,
		HR_Bit_FS = 0x72,
		CIO = 0xB0,
		WR = 0xB1,
		HR = 0xB2,
		AR = 0xB3,
		CIO_FS = 0xF0,
		WR_FS = 0xF1,
		HR_FS = 0xF2,
		TIM = 0x09,
		CNT = 0x09,
		TIM_FS = 0x49,
		CNT_FS = 0x49,
		TIM_PV = 0x89,
		CNT_PV = 0x89,
		DM_Bit = 0x02,
		DM = 0x82,
		TK_Bit = 0x06,
		TK = 0x46
	}
}
