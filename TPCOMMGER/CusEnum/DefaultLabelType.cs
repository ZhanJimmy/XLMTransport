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
*│　创建时间：2021/11/25 14:52:58                                          
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
    /// <para>时间：2021/11/25 14:52:58</para>
    /// </summary>
    public enum DefaultLabelType
    {
        [Description("区域")]
        Area = 0,
        [Description("楼栋")]
        Building = 1,
        [Description("楼层")]
        Floor = 2,
        [Description("车间")]
        WorkShop = 3,
        [Description("部门")]
        Department = 4,
        [Description("课")]
        Class = 5,
        [Description("线别")]
        LineNum = 6,
        [Description("线别名称")]
        Line = 7,
        [Description("线体类型")]
        BoardFlag = 8,
    }
}
