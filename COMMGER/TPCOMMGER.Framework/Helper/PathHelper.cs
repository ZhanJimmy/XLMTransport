using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/25 14:41:08                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.Framework.Helper
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/25 14:41:08</para>
    /// </summary>
    public static class PathHelper
    {
        public static string PathBase
        {
            get
            {
                var temp = $"{AppDomain.CurrentDomain.BaseDirectory}/data/";
                if (!Directory.Exists(temp)){
                    Directory.CreateDirectory(temp);
                    File.SetAttributes(temp, FileAttributes.Hidden);
                }
                return temp;
            }
        }

        public static string PTCoil => $"{PathBase}/{PathNameHelper.PNCoil}.ini";
        public static string PTCoilData => $"{PathBase}/{PathNameHelper.PNCoilData}.ini";
        public static string PTLabel => $"{PathBase}/{PathNameHelper.PNLabel}.ini";
        public static string PTLabelData => $"{PathBase}/{PathNameHelper.PNLabelData}.ini";
        public static string PTPlcData => $"{PathBase}/{PathNameHelper.PNPlcData}.ini";
        public static string PTPlcDetailData => $"{PathBase}/{PathNameHelper.PNPlcDetailData}.ini";
        public static string PTSeries => $"{PathBase}/{PathNameHelper.PNSeries}.ini";
        public static string PTModel => $"{PathBase}/{PathNameHelper.PNModel}.ini";
    }
}
