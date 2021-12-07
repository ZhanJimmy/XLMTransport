using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/12/7 8:42:54                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.Framework.CusEnum
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/12/7 8:42:54</para>
    /// </summary>
    public enum DefaultFunType
    {
        #region 台达
        [SeriesDescription(Default = DefaultSeries.Delta)]
        ReadCoil = 0x01,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        ReadDiscreteInputs = 0x02,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        ReadHoldingRegisters = 0x03,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        ReadInputRegisters = 0x04,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        ReadSingleCoil = 0x05,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        WriteSingleRegister = 0x06,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        WriteMultipleCoils = 0x0F,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        WriteMultipleRegisters = 0x10,
        [SeriesDescription(Default = DefaultSeries.Delta)]
        ReadWriteMultipleRegisters = 0x17,
        #endregion
    }
}
