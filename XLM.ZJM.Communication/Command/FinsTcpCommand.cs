using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLM.ZJM.Communication.Interfaces;
using XLM.ZJM.Communication.CusEnum;
using XLM.ZJM.Communication.Extension;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/18 11:43:07                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.Communication.Command
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/18 11:43:07</para>
    /// </summary>
    public class FinsTcpCommand : IFinsTcpCommand
    {
        #region byte
        public byte[] FinsHandShake => new byte[20] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        public byte ICF => 0x80;
        public byte RSC => 0x00;
        public byte GTC => 0x02;
        public byte DNA => 0x00;
        public byte DA1 { get; set; }
        public byte DA2 => 0x00;
        public byte SNA => 0x00;
        public byte SA1 { get; set; }
        public byte SA2 => 0x00;
        public byte SID { get; set; }
        public byte MRC => 0x01;
        public byte SRC => 0x01;
        //public FinsTcpArea Area { get; set; }
        //public byte[] Address { get; set; }
        //public byte[] NumberOfPoints { get; set; }
        //public byte[] FixedBytes => new byte[13] { ICF, RSC, GTC, DNA, DA1, DA2, SNA, SA1, SA2, SID, MRC, SRC, Area.ToByte() };
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FinsTcpCommand(byte serviceID = 1)
        {
            SID = serviceID;
        }

        public ITransport Transport => throw new NotImplementedException();

        public byte[] Response => throw new NotImplementedException();

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            Transport.Close();
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            return false;
        }
    }
}
