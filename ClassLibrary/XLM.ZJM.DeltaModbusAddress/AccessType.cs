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
*│　创建时间：2021/11/22 10:08:42                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace XLM.ZJM.DeltaModbusAddress
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/11/22 10:08:42</para>
    /// </summary>
    public enum AccessType
    {
        [Description("读线圈状态")]
        ReadCoil = 0x01,

        [Description("读输入离散量")]
        ReadDiscreteInputs = 0x02,

        [Description("读多个寄存器")]
        ReadHoldingRegisters = 0x03,

        [Description("读输入寄存器")]
        ReadInputRegisters = 0x04,

        [Description("写单个线圈")]
        ReadSingleCoil = 0x05,

        [Description("写单个保持寄存器")]
        WriteSingleRegister = 0x06,

        [Description("写多个线圈")]
        WriteMultipleCoils = 0x0F,

        [Description("写多个保持寄存器")]
        WriteMultipleRegisters = 0x10,

        [Description("读写多个保持寄存器")]
        ReadWriteMultipleRegisters = 0x17,
    }
}
