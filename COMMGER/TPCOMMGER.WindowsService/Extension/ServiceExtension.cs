using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
*│　创建时间：2021/11/24 11:03:52                                          
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
    /// <para>时间：2021/11/24 11:03:52</para>
    /// </summary>
    public static class ServiceExtension
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
            if (hexValue.Length % 2 != 0)
            {
                throw new FormatException("Hex string must have even number of string");
            }
            byte[] buffer = new byte[hexValue.Length / 2];
            for (int i = 0; i < hexValue.Length; i += 2)
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
        /// <summary>
        /// byte数组 转 HEX值
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHex(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToString(bytes.ToArray(), 0).Replace("-", string.Empty).ToUpper();
        }
        #endregion

        /// <summary>
        /// 转 Byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByte(this ushort value)
        {
            return new byte[] { (byte)(value >> 8 & 0xFFu), (byte)(value & 0xFFu) };
        }

        /// <summary>
        /// 转 Int  byte数组长度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this IEnumerable<byte> value)
        {
            if (value.Count() != ServiceHelper.ByteLen) return 0;
            var high = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(value.Take(2).ToArray(), 0));
            var low = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(value.TakeLast(2).ToArray(), 0));
            var arr = BitConverter.GetBytes(low).Concat(BitConverter.GetBytes(high)).ToArray();
            return BitConverter.ToInt32(arr, 0);
        }
        /// <summary>
        /// 转 Int  byte数组长度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this byte[] value)
        {
            if (value.Length != ServiceHelper.ByteLen) return 0;
            var high = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(value.Take(2).ToArray(), 0));
            var low = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(value.TakeLast(2).ToArray(), 0));
            var arr = BitConverter.GetBytes(low).Concat(BitConverter.GetBytes(high)).ToArray();
            return BitConverter.ToInt32(arr, 0);
        }

        /// <summary>
        /// Int 转 byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByte(this int value)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
        }

        /// <summary>
        /// 转
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToClientNode(this int value)
        {
            var a1 = (byte)(value >> 8 & 0xFFu);
            var a2 = (byte)(value & 0xFFu);
            return new byte[] { 0x00, 0x00, a1, a2 };
        }

        /// <summary>
        /// 转 Int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ClientNodeToPort(this byte[] value)
        {
            if (value.Length != ServiceHelper.ByteLen) return -1;
            return value.ToInt();
        }

        /// <summary>
        /// 转 命令
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToCommand(this byte[] value)
        {
            return value.TakeLast(1).First();
        }

        public static byte[] TakeLast(this byte[] value, int count)
        {
            int scount = 0;
            var temp = value.Length - count;
            if (temp > 0) scount = temp;
            return value.Skip(scount).Take(count).ToArray();
        }

        public static IEnumerable<byte> TakeLast(this IEnumerable<byte> value, int count)
        {
            int scount = 0;
            var temp = value.Count() - count;
            if (temp > 0) scount = temp;
            return value.Skip(scount).Take(count);
        }
    }
}
