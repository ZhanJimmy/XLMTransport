﻿using System;
using System.Collections.Generic;
using System.Text;
using TPCOMMGER.Framework.CusEnum;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/12/7 8:50:14                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.Framework
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/12/7 8:50:14</para>
    /// </summary>
    public class SeriesDescriptionAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SeriesDescriptionAttribute()
        {

        }

        public DefaultSeries Default { get; set; }

        public string Remark { get; set; }
    }
}
