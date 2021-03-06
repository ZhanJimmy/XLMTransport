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
    internal class ServiceHelper
    {
        internal const string Header = "D0584C4D";
        internal const string CEHex = "0000000000000000";
        internal const string HSHex = "00000008";
        internal const string RHex = "0000000C";
        internal const string WHex = "00000010";
        internal const int ByteLen = 4;
        internal const string SocketName = "TPCommger Socket服务";
        internal const int SocketPort = 816;
    }
}
