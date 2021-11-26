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
namespace TPCOMMGER.Helper
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/25 14:41:08</para>
    /// </summary>
    internal static class PathHelper
    {
        internal static string PathBase
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

        internal static string PTCoil => $"{PathBase}/{PathNameHelper.PNCoil}.ini";
        internal static string PTCoilData => $"{PathBase}/{PathNameHelper.PNCoilData}.ini";
        internal static string PTLabel => $"{PathBase}/{PathNameHelper.PNLabel}.ini";
        internal static string PTLabelData => $"{PathBase}/{PathNameHelper.PNLabelData}.ini";
        internal static string PTPlcData => $"{PathBase}/{PathNameHelper.PNPlcData}.ini";
        internal static string PTPlcDetailData => $"{PathBase}/{PathNameHelper.PNPlcDetailData}.ini";
    }
}
