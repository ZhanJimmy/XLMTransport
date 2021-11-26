using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/25 13:32:40                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.CusEnum
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/25 13:32:40</para>
    /// </summary>
    internal enum DefaultCoilType
    {
        [Description("投入")]
        In = 1,
        [Description("产出")]
        Out = 2,
        [Description("运行总时间")]
        Run = 3,
        [Description("停止总时间")]
        Stop = 4,
        [Description("故障总数")]
        Fault = 5,
        [Description("异常总时间")]
        Exception = 6,
        [Description("待料总时间")]
        WaitMat = 7,
        [Description("运行状态")]
        State = 8
    }
}
