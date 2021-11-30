using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XLM.ZJM.DeltaModbusAddress.Model;
using XLM.ZJM.DeltaModbusAddress.Extension;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/22 10:43:40                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.DeltaModbusAddress.Helper
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/22 10:43:40</para>
    /// </summary>
    public class TransportAddressHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private TransportAddressHelper()
        {

        }
        private static class Nested
        {
            internal static readonly TransportAddressHelper instane = new TransportAddressHelper();
            static Nested() { }
        }

        /// <summary>
        /// 实例 入口
        /// </summary>
        public static TransportAddressHelper Instance => Nested.instane;

        /// <summary>
        /// 装置 集合
        /// </summary>
        public List<ModbusDeviceModel> DeviceCollection
        {
            get
            {
                List<ModbusDeviceModel> list = new List<ModbusDeviceModel>();
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "X", DeviceType = DeviceType.Bit, DeviceBegin = 0.0, DeviceEnd = 63.15, DecBegin = 124577, DecEnd = 125600, HexBegin = "6000", HexEnd = "63FF", DataType = DataType.Hexadecimal });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "X", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 63, DecBegin = 332769, DecEnd = 332832, HexBegin = "8000", HexEnd = "803F" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "Y", DeviceType = DeviceType.Bit, DeviceBegin = 0.0, DeviceEnd = 63.15, DecBegin = 040961, DecEnd = 041984, HexBegin = "A000", HexEnd = "A03F", DataType = DataType.Hexadecimal });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "Y", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 63, DecBegin = 440961, DecEnd = 441024, HexBegin = "A000", HexEnd = "A03F" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "M", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 8191, DecBegin = 000001, DecEnd = 008192, HexBegin = "0000", HexEnd = "1FFF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "SM", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 4095, DecBegin = 016385, DecEnd = 020480, HexBegin = "4000", HexEnd = "4FFF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "SR", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 2047, DecBegin = 449153, DecEnd = 461200, HexBegin = "C000", HexEnd = "C7FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "D", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 29999, DecBegin = 400001, DecEnd = 430000, HexBegin = "0000", HexEnd = "752F" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "S", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 2047, DecBegin = 020581, DecEnd = 022528, HexBegin = "5000", HexEnd = "57FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "T", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 057345, DecEnd = 057856, HexBegin = "E000", HexEnd = "E1FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "T", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 457345, DecEnd = 457856, HexBegin = "E000", HexEnd = "E1FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "C", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 061441, DecEnd = 061952, HexBegin = "F000", HexEnd = "F1FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "C", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 461441, DecEnd = 461952, HexBegin = "F000", HexEnd = "F1FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "HC", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 064513, DecEnd = 064758, HexBegin = "FC00", HexEnd = "FCFF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "HC", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 464513, DecEnd = 464758, HexBegin = "FC00", HexEnd = "FCFF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "AS", DeviceName = "E", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 9, DecBegin = 465025, DecEnd = 465039, HexBegin = "FE00", HexEnd = "FE09" });


                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "S", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 1023, DecBegin = 000001, DecEnd = 001024, HexBegin = "0000", HexEnd = "03FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "X", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 377, DecBegin = 101025, DecEnd = 101280, HexBegin = "0400", HexEnd = "04FF", DeviceRemark = "octal", DataType = DataType.Octal });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "Y", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 377, DecBegin = 001281, DecEnd = 001536, HexBegin = "0500", HexEnd = "05FF", DeviceRemark = "octal", DataType = DataType.Octal });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "T", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 001537, DecEnd = 001792, HexBegin = "0600", HexEnd = "06FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "T", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 401537, DecEnd = 401792, HexBegin = "0600", HexEnd = "06FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "M", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 1535, DecBegin = 002049, DecEnd = 003584, HexBegin = "0800", HexEnd = "0DFF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "M", DeviceType = DeviceType.Bit, DeviceBegin = 1536, DeviceEnd = 4095, DecBegin = 045057, DecEnd = 047616, HexBegin = "B000", HexEnd = "B9FF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "C", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 199, DecBegin = 003585, DecEnd = 003784, HexBegin = "0E00", HexEnd = "0EC7", DeviceRemark = "16bit" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "C", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 199, DecBegin = 403585, DecEnd = 403784, HexBegin = "0E00", HexEnd = "0EC7", DeviceRemark = "16bit" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "C", DeviceType = DeviceType.Bit, DeviceBegin = 200, DeviceEnd = 255, DecBegin = 003785, DecEnd = 003840, HexBegin = "0EC8", HexEnd = "0EFF", DeviceRemark = "32bit" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "C", DeviceType = DeviceType.DWord, DeviceBegin = 200, DeviceEnd = 255, DecBegin = 403785, DecEnd = 403840, HexBegin = "0700", HexEnd = "076F", DeviceRemark = "32bit" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "D", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 4095, DecBegin = 404097, DecEnd = 408192, HexBegin = "1000", HexEnd = "1FFF" });
                list.Add(new ModbusDeviceModel() { SeriesName = "DVP", DeviceName = "D", DeviceType = DeviceType.Word, DeviceBegin = 4096, DeviceEnd = 11999, DecBegin = 436865, DecEnd = 444750, HexBegin = "9000", HexEnd = "AEDF" });
                return list;
            }
        }

        /// <summary>
        /// 获取当前 所有 系列类型
        /// </summary>
        /// <returns></returns>
        public List<string> GetSeriesNames()
        {
            var list = DeviceCollection;
            return list.Select(t => t.SeriesName).Distinct().ToList();
        }

        /// <summary>
        /// 获取 系列下 装置集合
        /// </summary>
        /// <param name="seriesName"></param>
        /// <returns></returns>
        public List<ModbusDeviceModel> GetSeriesDevice(string seriesName)
        {
            var whereResult = DeviceCollection.Where(t => t.SeriesName.Equals(seriesName, StringComparison.OrdinalIgnoreCase));
            if (whereResult == null || whereResult.Any() == false) return null;
            return whereResult.ToList();
        }

        /// <summary>
        /// 获取 系列下 装置下装置名称
        /// </summary>
        /// <param name="seriesName"></param>
        /// <returns></returns>
        public List<string> GetSeriesDeviceNames(string seriesName)
        {
            var whereResult = GetSeriesDevice(seriesName);
            if (whereResult == null || whereResult.Count == 0) return null;
            return whereResult.Select(t => t.DeviceName).Distinct().ToList();
        }

        /// <summary>
        /// 获取 系列下 装置下装置类型
        /// </summary>
        /// <param name="seriesName"></param>
        /// <returns></returns>
        public List<DeviceType> GetSeriesDeviceType(string seriesName)
        {
            var whereResult = GetSeriesDevice(seriesName);
            if (whereResult == null || whereResult.Count == 0) return null;
            return whereResult.Select(t => t.DeviceType).Distinct().ToList();
        }

        /// <summary>
        /// 获取通讯 16进制
        /// </summary>
        /// <param name="seriesName"></param>
        /// <param name="addr"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public Tuple<bool, string> GetTransportHex(string seriesName, string addr, DeviceType deviceType = DeviceType.Default)
        {
            var whereResult = GetSeriesDevice(seriesName);
            if (whereResult == null || whereResult.Count == 0) return Tuple.Create(false, $"The [{seriesName}] find not device collection");
            var tempDeviceName = Regex.Replace(addr, "[0-9]", "");
            var temp = Regex.Replace(addr, "[a-zA-Z]", "");
            double.TryParse(temp, out double result);
            var tempResult = whereResult.Where(t => t.DeviceName.Equals(tempDeviceName, StringComparison.OrdinalIgnoreCase))?.ToList();
            if (tempResult == null || tempResult.Any() == false) return Tuple.Create(false, $"The [{addr}] find not device");
            ModbusDeviceModel entity = null;
            if(tempResult.Count == 1)
            {
                entity = tempResult.FirstOrDefault();
            }
            else
            {
                var tempType = tempResult.Select(t => t.DeviceType).Distinct().ToList();
                if(tempType.Count > 1)
                {
                    if (deviceType == DeviceType.Default) return Tuple.Create(false, $"The [{addr}] need device type({string.Join(",", tempType)})");
                    tempResult = tempResult.Where(t => t.DeviceType == deviceType)?.OrderBy(t => t.DeviceBegin)?.ToList();
                    if (tempResult == null || tempResult.Any() == false) return Tuple.Create(false, $"The [{addr}] find not device");
                }
                foreach (var item in tempResult)
                {
                    if (item.DeviceBegin <= result && result <= item.DeviceEnd)
                    {
                        entity = item;
                        break;
                    }
                }
            }
            if (entity == null) return Tuple.Create(false,$"The [{addr}] fint not device");
            var hexValue = GetHex(entity, result);
            if (string.IsNullOrEmpty(hexValue)) return Tuple.Create(false, $"The [{addr}] trans hex is error");
            return Tuple.Create(true, hexValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetHex(ModbusDeviceModel entity, double value)
        {
            ushort valueInterval = 0;
            string hexValue = string.Empty;
            var tempHexBegin = entity.HexBegin.HexToUShort();
            switch (entity.DataType)
            {
                case DataType.Octal:
                    {
                        if (value.IsOctal())
                        {
                            valueInterval = (ushort)(value.ToByte() - entity.DeviceBegin.ToByte());
                            var tempHexEnd = tempHexBegin + valueInterval;
                            hexValue = tempHexEnd.ToString("X2").PadLeft(4,'0');
                        }
                    }
                    break;
                case DataType.Decimal:
                    {
                        valueInterval = (ushort)(value - entity.DeviceBegin);
                        var tempHexEnd = tempHexBegin + valueInterval;
                        hexValue = tempHexEnd.ToString("X2").PadLeft(4, '0');
                    }
                    break;
                case DataType.Hexadecimal:
                    {
                        var tempDeviceBegin = entity.DeviceBegin.ToUshort();
                        var tempValue = value.ToUshort();
                        valueInterval = (ushort)((tempValue.Item1 - tempDeviceBegin.Item1) * 16 + tempValue.Item2); 
                        var tempHexEnd = tempHexBegin + valueInterval;
                        hexValue = tempHexEnd.ToString("X2").PadLeft(4, '0');
                    }
                    break;
            }
            return hexValue;
        }

        #region 废弃
        private void AS()
        {
            List<ModbusDeviceModel> list = new List<ModbusDeviceModel>();
            list.Add(new ModbusDeviceModel() { DeviceName = "X", DeviceType = DeviceType.Bit, DeviceBegin = 0.0, DeviceEnd = 63.15, DecBegin = 124577, DecEnd = 125600, HexBegin = "6000", HexEnd = "63FF", DataType = DataType.Hexadecimal });
            list.Add(new ModbusDeviceModel() { DeviceName = "X", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 63, DecBegin = 332769, DecEnd = 332832, HexBegin = "8000", HexEnd = "803F" });
            list.Add(new ModbusDeviceModel() { DeviceName = "Y", DeviceType = DeviceType.Bit, DeviceBegin = 0.0, DeviceEnd = 63.15, DecBegin = 040961, DecEnd = 041984, HexBegin = "A000", HexEnd = "A03F", DataType = DataType.Hexadecimal });
            list.Add(new ModbusDeviceModel() { DeviceName = "Y", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 63, DecBegin = 440961, DecEnd = 441024, HexBegin = "A000", HexEnd = "A03F" });
            list.Add(new ModbusDeviceModel() { DeviceName = "M", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 8191, DecBegin = 000001, DecEnd = 008192, HexBegin = "0000", HexEnd = "1FFF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "SM", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 4095, DecBegin = 016385, DecEnd = 020480, HexBegin = "4000", HexEnd = "4FFF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "SR", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 2047, DecBegin = 449153, DecEnd = 461200, HexBegin = "C000", HexEnd = "C7FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "D", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 29999, DecBegin = 400001, DecEnd = 430000, HexBegin = "0000", HexEnd = "752F" });
            list.Add(new ModbusDeviceModel() { DeviceName = "S", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 2047, DecBegin = 020581, DecEnd = 022528, HexBegin = "5000", HexEnd = "57FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "T", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 057345, DecEnd = 057856, HexBegin = "E000", HexEnd = "E1FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "T", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 457345, DecEnd = 457856, HexBegin = "E000", HexEnd = "E1FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "C", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 061441, DecEnd = 061952, HexBegin = "F000", HexEnd = "F1FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "C", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 511, DecBegin = 461441, DecEnd = 461952, HexBegin = "F000", HexEnd = "F1FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "HC", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 064513, DecEnd = 064758, HexBegin = "FC00", HexEnd = "FCFF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "HC", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 464513, DecEnd = 464758, HexBegin = "FC00", HexEnd = "FCFF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "E", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 9, DecBegin = 465025, DecEnd = 465039, HexBegin = "FE00", HexEnd = "FE09" });
        }

        private void DVP()
        {
            List<ModbusDeviceModel> list = new List<ModbusDeviceModel>();
            list.Add(new ModbusDeviceModel() { DeviceName = "S", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 1023, DecBegin = 000001, DecEnd = 001024, HexBegin = "0000", HexEnd = "03FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "X", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 377, DecBegin = 101025, DecEnd = 101280, HexBegin = "0400", HexEnd = "04FF", DeviceRemark = "octal", DataType = DataType.Octal });
            list.Add(new ModbusDeviceModel() { DeviceName = "Y", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 377, DecBegin = 001281, DecEnd = 001536, HexBegin = "0500", HexEnd = "05FF", DeviceRemark = "octal", DataType = DataType.Octal });
            list.Add(new ModbusDeviceModel() { DeviceName = "T", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 001537, DecEnd = 001792, HexBegin = "0600", HexEnd = "06FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "T", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 255, DecBegin = 401537, DecEnd = 401792, HexBegin = "0600", HexEnd = "06FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "M", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 1535, DecBegin = 002049, DecEnd = 003584, HexBegin = "0800", HexEnd = "0DFF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "M", DeviceType = DeviceType.Bit, DeviceBegin = 1536, DeviceEnd = 4095, DecBegin = 045057, DecEnd = 047616, HexBegin = "B000", HexEnd = "B9FF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "C", DeviceType = DeviceType.Bit, DeviceBegin = 0, DeviceEnd = 199, DecBegin = 003585, DecEnd = 003784, HexBegin = "OEOO", HexEnd = "OEC7", DeviceRemark = "16bit" });
            list.Add(new ModbusDeviceModel() { DeviceName = "C", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 199, DecBegin = 403585, DecEnd = 403784, HexBegin = "OE00", HexEnd = "OEC7", DeviceRemark = "16bit" });
            list.Add(new ModbusDeviceModel() { DeviceName = "C", DeviceType = DeviceType.Bit, DeviceBegin = 200, DeviceEnd = 255, DecBegin = 003785, DecEnd = 003840, HexBegin = "OEC8", HexEnd = "0EFF", DeviceRemark = "32bit" });
            list.Add(new ModbusDeviceModel() { DeviceName = "C", DeviceType = DeviceType.DWord, DeviceBegin = 200, DeviceEnd = 255, DecBegin = 403785, DecEnd = 403840, HexBegin = "0700", HexEnd = "076F", DeviceRemark = "32bit" });
            list.Add(new ModbusDeviceModel() { DeviceName = "D", DeviceType = DeviceType.Word, DeviceBegin = 0, DeviceEnd = 4095, DecBegin = 404097, DecEnd = 408192, HexBegin = "1000", HexEnd = "1FFF" });
            list.Add(new ModbusDeviceModel() { DeviceName = "D", DeviceType = DeviceType.Word, DeviceBegin = 4096, DeviceEnd = 11999, DecBegin = 436865, DecEnd = 444750, HexBegin = "9000", HexEnd = "AEDF" });
        }
        #endregion
    }
}
