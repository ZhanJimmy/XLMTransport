using System;
using System.Collections.Generic;
using System.Text;

/**************************************************************************
*
*   CLR 版本    ：4.0.30319.42000
*   系统版本    ：V1.0.0
*   创 建 者    ：詹建妹 (JameZhan@aliyun.com)
*   功能描述    ：
*  
***************************************************************************/
namespace TPCOMMGER.Framework
{
    /// <summary>
    /// 委托实体
    /// </summary>
    internal sealed class DelegateObj
    {
        private MyDelegate _delegate;

        public MyDelegate CallMethod
        {
            get { return _delegate; }
        }
        private DelegateObj(MyDelegate D)
        {
            _delegate = D;
        }
        /// <summary>
        /// 构造委托对象，让它看起来有点javascript定义的味道.
        /// </summary>
        /// <param name="D"></param>
        /// <returns></returns>
        public static DelegateObj Function(MyDelegate D)
        {
            return new DelegateObj(D);
        }
    }
    /// <summary>
    /// 自定义委托
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="PMs"></param>
    /// <returns></returns>
    internal delegate object MyDelegate(dynamic Sender, params object[] PMs);
}
