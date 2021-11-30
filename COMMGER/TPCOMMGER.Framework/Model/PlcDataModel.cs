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
*│　创建时间：2021/11/30 16:27:29                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.Framework.Model
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/30 16:27:29</para>
    /// </summary>
    public sealed class PlcDataModel
    {
        public PlcDataModel() { }
        public string PName { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string Description { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string Label { get; set; }

        public string OutMark { get; set; }
    }
}
