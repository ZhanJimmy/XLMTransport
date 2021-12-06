using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/12/2 9:23:06                                          
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
    /// <para>时间：2021/12/2 9:23:06</para>
    /// </summary>
    internal sealed class WindowsServiceHelper
    {
        private const string logName = "D0584C4D";
        private EventLog logHelper;
        /// <summary>
        /// 构造函数
        /// </summary>
        internal WindowsServiceHelper(ServiceBase service)
        {
            var sourceName = service.ServiceName.Replace("Service", "");
            logHelper = new EventLog();
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }
            logHelper.Source = sourceName;
            logHelper.Log = logName;
        }
        internal WindowsServiceHelper(string sourceName)
        {
            logHelper = new EventLog();
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }
            logHelper.Source = sourceName;
            logHelper.Log = logName;
        }

        internal void WriteLog(string msg)
        {
            logHelper.WriteEntry(msg);
        }

        internal void WriteError(string msg)
        {
            logHelper.WriteEntry(msg, EventLogEntryType.Error);
        }

        internal void WriteWarning(string msg)
        {
            logHelper.WriteEntry(msg, EventLogEntryType.Warning);
        }

        internal void WriteInfo(string msg)
        {
            logHelper.WriteEntry(msg, EventLogEntryType.Information);
        }

        internal void WriteSuccess(string msg)
        {
            logHelper.WriteEntry(msg, EventLogEntryType.SuccessAudit);
        }

        internal void WriteFail(string msg)
        {
            logHelper.WriteEntry(msg, EventLogEntryType.FailureAudit);
        }
    }
}
