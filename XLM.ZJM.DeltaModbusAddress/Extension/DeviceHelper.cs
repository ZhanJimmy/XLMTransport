using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using XLM.ZJM.DeltaModbusAddress.Model;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/17 10:52:15                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.DeltaModbusAddress.Extension
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/17 10:52:15</para>
    /// </summary>
    public static class DeviceHelper
    {
        public static string DeltaHexString(ModbusDeviceModel model, double value)
        {
            if (value < model.DeviceBegin || model.DeviceEnd < value) return string.Empty;
            var digit = ProcessDecimalDigits(model.DeviceEnd);
            var digit1 = ProcessDecimalDigits(value);
            double deviceInterval = 0;
            if (digit == 0)
            {
                if (digit1 > 0) return string.Empty;
                deviceInterval = value - model.DeviceBegin;
            }
            else if(digit > 0)
            {
                if (digit1 > 0 && digit1 > digit) return string.Empty;
            }
            var hexBegin = HexToUShort(model.HexBegin);
            var hexEnd = HexToUShort(model.HexEnd);
            var hexInterval = hexEnd - hexBegin;

            return "";
        }

        #region Hex  Byte[]

        /// <summary>
        /// HEX值转 ushor值
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static ushort HexToUShort(this string hexValue)
        {
            var bytes = HexToByte(hexValue);
            return (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(bytes, 0));
        }

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
            byte[] buffer = new byte[hexValue.Length / 2];
            for (int i = 0; i < hexValue.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(hexValue.Substring(i, 2), 16);
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
        /// 处理 double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Tuple<double, double> ProcessDouble(this double value)
        {
            var arr = value.ToString().Split('.');
            if (arr.Length == 0) return Tuple.Create(Convert.ToDouble(arr[0]), 0d);
            return Tuple.Create(Convert.ToDouble(arr[0]), Convert.ToDouble(arr[1]));
        }

        public static Tuple<ushort, ushort> ToUshort(this double value)
        {
            var arr = value.ToString().Split('.');
            if (arr.Length == 0) return Tuple.Create(Convert.ToUInt16(arr[0]), (ushort)0);
            return Tuple.Create(Convert.ToUInt16(arr[0]), Convert.ToUInt16(arr[1]));
        }

        /// <summary>
        /// 处理小数位
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ProcessDecimalDigits(this double value)
        {
            var arr = value.ToString().Split('.');
            if (arr.Length == 1) return 0;
            return Convert.ToDouble(arr[1]);
        }

        /// <summary>
        /// 转 byte 值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte ToByte(this AccessType type)
        {
            return (byte)type;
        }

        /// <summary>
        /// 转 HEX
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHex(this ushort value)
        {
            return value.ToString("X2");
        }

        /// <summary>
        /// 是否 8进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsOctal(this double value)
        {
            string temp = @"[0-7]+$";
            return Regex.IsMatch(value.ToString(), temp);
        }

        /// <summary>
        /// 转8 进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this double value)
        {
            return Convert.ToByte(value.ToString(), 8);
        }
    }
}
