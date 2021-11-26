using System;
using System.Collections.Generic;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/11/17 10:25:31                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.DeltaModbusAddress.Model
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/17 10:25:31</para>
    /// </summary>
    public class ModbusDeviceModel
    {
        public ModbusDeviceModel() { }
        public string SeriesName { get; set; }
        /// <summary>
        /// 装置名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 装置类型
        /// </summary>
        public DeviceType DeviceType { get; set; }

        /// <summary>
        /// 装置范围开始
        /// </summary>
        public double DeviceBegin { get; set; }

        /// <summary>
        /// 装置范围结束
        /// </summary>
        public double DeviceEnd { get; set; }

        /// <summary>
        /// 装置范围 备注
        /// </summary>
        public string DeviceRemark { get; set; }

        /// <summary>
        /// HEX范围开始
        /// </summary>
        public string HexBegin { get; set; }

        /// <summary>
        /// HEX范围结束
        /// </summary>
        public string HexEnd { get; set; }

        /// <summary>
        /// 十进制 开始
        /// </summary>
        public double DecBegin { get; set; }

        /// <summary>
        /// 十进制 结束
        /// </summary>
        public double DecEnd { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType { get; set; } = DataType.Decimal;
    }
}
