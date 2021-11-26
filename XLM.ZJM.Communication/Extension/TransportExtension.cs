using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLM.ZJM.Communication.CusEnum;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/16 16:45:51                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.Communication.Extension
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/16 16:45:51</para>
    /// </summary>
    public static class TransportExtension
    {
        #region Hex  Byte[]
        /// <summary>
        /// HEX值转 byte数组
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static byte[] HexToByte(this string hexValue)
        {
            hexValue = hexValue.Replace(" ", "");
            if (string.IsNullOrEmpty(hexValue))
            {
                throw new ArgumentNullException(nameof(hexValue));
            }
            if(hexValue.Length % 2 != 0)
            {
                throw new FormatException(Resource.HexStringCountNotEven);
            }
            byte[] buffer = new byte[hexValue.Length / 2];
            for(int i = 0; i < hexValue.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(hexValue.Substring(i, 2), 16);
            }
            return buffer;
        }

        /// <summary>
        /// byte数组 转 HEX值
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHex(this byte[] bytes)
        {
            return BitConverter.ToString(bytes, 0).Replace("-", string.Empty).ToUpper();
        }
        #endregion

        /// <summary>
        /// 转 byte
        /// </summary>
        /// <param name="finsTcpArea"></param>
        /// <returns></returns>
        public static byte ToByte(this FinsTcpArea finsTcpArea)
        {
            return (byte)finsTcpArea;
        }
        /// <summary>
        /// 转 Byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByte(this ushort value)
        {
            return new byte[] { (byte)(value >> 8 & 0xFFu), (byte)(value & 0xFFu) };
        }
    }
}
