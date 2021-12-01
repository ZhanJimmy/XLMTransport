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
*│　创建时间：2021/11/24 11:12:05                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.WindowsService
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/24 11:12:05</para>
    /// </summary>
    internal class ServerHelper
    {
        internal static string Header = "D0584C4D";
        internal static string CEHex = "0000000000000000";
        internal static string HSHex = "00000008";
        internal static string RHex = "0000000C";
        internal static string WHex = "00000010";
        internal static int ByteLen = 4;
    }
}
