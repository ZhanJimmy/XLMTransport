using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TPCOMMGER.Framework.CusEnum;
using TPCOMMGER.Framework.Model;
using TPCOMMGER.WindowsService.Helper;

/**
*┌────────────────────────────┐
*│　CLR 版本：4.0.30319.42000                                          
*│　机    器：E490A-009                                              
*│　作    者：jianmei.zhan
*│　邮    箱：jianmei.zhan@yankon.com 
*│　公    司：厦门阳光恩耐照明有限公司      
*│　部    门：数字化研发部                           
*│　创建时间：2021/12/6 13:48:01                                          
*│　版    本：V1.0.0      
*│　功能描述：                           
*└────────────────────────────┘
*┌────────────────────────────┐
*│　Copyright @ Yankon 2021. All rights reserved                                                                
*└────────────────────────────┘
*/
namespace TPCOMMGER.WindowsService.Extension
{
    ///  功能描述：
    /// <para>作者：jianmei.zhan</para>
    /// <para>邮箱：jianmei.zhan@yankon.com</para>
    /// <para>时间：2021/12/6 13:48:01</para>
    /// </summary>
    internal static class TcpClientExtension
    {

        #region Fins
        internal static Tuple<bool, byte[]> FinsHandShake(this Socket client)
        {
            if (client.Connected == false) return null;
            var header = new byte[20] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] response = new byte[24];
            try
            {
                client.Send(header);
                client.Receive(response);
                var Code = response[15];
                var DA1 = response[23];
                var SA1 = response[19];
                if (Code != 0) return Tuple.Create(false, new byte[0]);
                var buffer = new byte[12] { 0x80, 0x00, 0x00, 0x00, DA1, 0x00, 0x00, SA1, 0x00, 0x01, 0x01, 0x01 };
                return Tuple.Create(true, buffer);
            }
            catch { return null; }
        }

        internal static ushort ReadFinsUSort(this Socket client, byte[] list, uint address)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            List<byte> buffer = new List<byte>(list);
            buffer.Add(0x82);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(0x00);
            buffer.Add(0x00);
            buffer.Add(0x01);
            try
            {
                var response = new byte[32];
                client.Send(header, header.Length, SocketFlags.None);
                client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
                client.Receive(response, response.Length, SocketFlags.None);
                return (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { response[30], response[31] }, 0));
            }
            catch { return 0; }
        }

        internal static uint ReadFinsUInt(this Socket client, byte[] list, uint address)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            List<byte> buffer = new List<byte>(list);
            buffer.Add(0x82);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(0x00);
            buffer.Add(0x00);
            buffer.Add(0x02);
            try
            {
                var response = new byte[34];
                client.Send(header, header.Length, SocketFlags.None);
                client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
                client.Receive(response, response.Length, SocketFlags.None);
                var low = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { response[30], response[31] }, 0));
                var high = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { response[32], response[33] }, 0));
                var re = BitConverter.GetBytes(low).Concat(BitConverter.GetBytes(high)).ToArray();
                return BitConverter.ToUInt32(re, 0);
            }
            catch { return 0; }
        }

        internal static bool ReadFinsBool(this Socket client, byte[] list, double bitAddress)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            var arr = bitAddress.ToString().Split('.');
            uint address = uint.Parse(arr[0].ToString());
            byte bitPos = 0x00;
            if (arr.Length == 2) bitPos = byte.Parse(arr[1].ToString());
            List<byte> buffer = new List<byte>(list);
            buffer.Add(0x31);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(bitPos);
            buffer.Add(0x00);
            buffer.Add(0x01);
            try
            {
                var response = new byte[32];
                client.Send(header, header.Length, SocketFlags.None);
                client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
                client.Receive(response, response.Length, SocketFlags.None);
                if (response[30] == 0) return false;
                else return true;
            }
            catch { return false; }
        }

        internal static void WriteFinsBool(this Socket client, byte[] list, double bitAddress, bool data)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1B, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            var arr = bitAddress.ToString().Split('.');
            uint address = uint.Parse(arr[0].ToString());
            byte bitPos = 0x00;
            if (arr.Length == 2) bitPos = byte.Parse(arr[1].ToString());
            List<byte> buffer = new List<byte>(list);
            buffer[11] = 0x02;
            buffer.Add(0x31);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(bitPos);
            buffer.Add(0x00);
            buffer.Add(0x01);
            try
            {
                client.Send(header, header.Length, SocketFlags.None);
                client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
                byte byteData = 0x00;
                if (data) byteData = 0x01;
                client.Send(new byte[] { byteData }, 1, SocketFlags.None);
            }
            catch { }
        }

        internal static void WriteFinsUShort(this Socket client, byte[] list, uint address, ushort data)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1C, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            List<byte> buffer = new List<byte>(list);
            buffer[11] = 0x02;
            buffer.Add(0x82);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(0x00);
            buffer.Add(0x00);
            buffer.Add(0x01);
            try
            {
                client.Send(header, header.Length, SocketFlags.None);
                client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
                client.Send(new byte[] { ((byte)((uint)data >> 8 & 0xFFu)), ((byte)((uint)(data & 0xFFu))) }, 2, SocketFlags.None);
            }
            catch { }
        }

        internal static void WriteFinsInt(this Socket client, byte[] list, uint address, int data)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1E, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            List<byte> buffer = new List<byte>(list);
            buffer[11] = 0x02;
            buffer.Add(0x82);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(0x00);
            buffer.Add(0x00);
            buffer.Add(0x02);
            try
            {
                client.Send(header, header.Length, SocketFlags.None);
                client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
                var tempData = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data));
                byte[] byteData = new byte[4] { tempData[2], tempData[3], tempData[0], tempData[1] };
                client.Send(byteData, 4, SocketFlags.None);
            }
            catch { }
        }

        #endregion

        #region Modbus

        internal static ushort ReadModbusUShort(this Socket client, ushort address, byte slave = 0x01)
        {
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var buffer = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, slave, 0x03, tempAddr[0], tempAddr[1], 0x00, 0x01 };
            client.Send(buffer, buffer.Length, SocketFlags.None);
            byte[] response = new byte[11];
            client.Receive(response, response.Length, SocketFlags.None);
            byte[] temp = new byte[] { response[9], response[10] };
            short[] data = new short[1];
            return (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp, 0));
        }

        internal static uint ReadModbusUInt(this Socket client, ushort address, byte slave = 0x01)
        {
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var buffer = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, slave, 0x03, tempAddr[0], tempAddr[1], 0x00, 0x02 };
            client.Send(buffer, buffer.Length, SocketFlags.None);
            byte[] response = new byte[13];
            client.Receive(response, response.Length, SocketFlags.None);
            byte[] temp = new byte[] { response[9], response[10], response[11], response[12] };
            short[] data = new short[2];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp, i * 2));
            }
            var re = BitConverter.GetBytes(data[0]).Concat(BitConverter.GetBytes(data[1])).ToArray();
            return BitConverter.ToUInt32(re, 0);
        }

        internal static ushort ReadModbusUShort(this Socket client, short address, byte slave = 0x01)
        {
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var buffer = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, slave, 0x03, tempAddr[0], tempAddr[1], 0x00, 0x01 };
            client.Send(buffer, buffer.Length, SocketFlags.None);
            byte[] response = new byte[11];
            client.Receive(response, response.Length, SocketFlags.None);
            byte[] temp = new byte[] { response[9], response[10] };
            short[] data = new short[1];
            return (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp, 0));
        }

        internal static uint ReadModbusUInt(this Socket client, short address, byte slave = 0x01)
        {
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var buffer = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, slave, 0x03, tempAddr[0], tempAddr[1], 0x00, 0x02 };
            client.Send(buffer, buffer.Length, SocketFlags.None);
            byte[] response = new byte[13];
            client.Receive(response, response.Length, SocketFlags.None);
            byte[] temp = new byte[] { response[9], response[10], response[11], response[12] };
            short[] data = new short[2];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp, i * 2));
            }
            var re = BitConverter.GetBytes(data[0]).Concat(BitConverter.GetBytes(data[1])).ToArray();
            return BitConverter.ToUInt32(re, 0);
        }

        internal static bool ReadModbusBool(this Socket client, short address, byte slave = 0x01)
        {
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var buffer = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, slave, 0x001, tempAddr[0], tempAddr[1], 0x00, 0x01 };
            client.Send(buffer, buffer.Length, SocketFlags.None);
            byte[] response = new byte[10];
            client.Receive(response, response.Length, SocketFlags.None);
            byte temp = response[9];
            if (temp == 1) return true;
            else return false;
        }

        internal static void WriteModbusBool(this Socket client, short address, bool value, byte slave = 0x01)
        {
            byte temp = 0x00;
            if (value) temp = 0xFF;
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var buffer = new byte[]
                     {
                        0x00, 0x01,
                        0x00, 0x00,
                        0x00, 0x06,
                        slave,
                        0x05,
                        tempAddr[0], tempAddr[1],
                        temp, 0x00,
                     };
            client.Send(buffer, buffer.Length, SocketFlags.None);
        }

        internal static void WriteModbusUshort(this Socket client, short address, short value, byte slave = 0x01)
        {
            var tempAddr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(address));
            var tempValue = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
            var buffer = new byte[]
            {
                0x00, 0x01,
                0x00, 0x00,
                0x00, 0x09,
                slave,
                0x10,
                tempAddr[0], tempAddr[1],
                0x00, 0x01,
                0x02,
                tempValue[0], tempValue[1]
            };
            client.Send(buffer, buffer.Length, SocketFlags.None);
        }
        #endregion

        #region
        internal static ushort ReadUShort(this SocketEx client, string address)
        {
            ushort value = 0;
            switch (client.SeriesType)
            {
                case DefaultSeries.Delta:
                    var addr1 = ushort.Parse(Regex.Replace(address, "[a-zA-Z]", ""));
                    value = client.Client.ReadModbusUShort(addr1);
                    break;
                case DefaultSeries.Omron:
                    var addr2 = uint.Parse(Regex.Replace(address, "[a-zA-Z]", ""));
                    var byteShake = (byte[])MemoryCacheHelper.GetCache(CacheKeyHelper.HandShake);
                    value = client.Client.ReadFinsUSort(byteShake, addr2);
                    break;
            }
            return value;
        }
        internal static uint ReadUInt(this SocketEx client, string address)
        {
            uint value = 0;
            switch (client.SeriesType)
            {
                case DefaultSeries.Delta:
                    var addr1 = ushort.Parse(Regex.Replace(address, "[a-zA-Z]", ""));
                    value = client.Client.ReadModbusUInt(addr1);
                    break;
                case DefaultSeries.Omron:
                    var addr2 = uint.Parse(Regex.Replace(address, "[a-zA-Z]", ""));
                    var byteShake = (byte[])MemoryCacheHelper.GetCache(CacheKeyHelper.HandShake);
                    value = client.Client.ReadFinsUInt(byteShake, addr2);
                    break;
            }
            return value;
        }
        internal static bool ReadBool(this SocketEx client, string address)
        {
            bool value = false;
            switch (client.SeriesType)
            {
                case DefaultSeries.Delta:
                    var addr1 = short.Parse(Regex.Replace(address, "[a-zA-Z]", ""));
                    value = client.Client.ReadModbusBool(addr1);
                    break;
                case DefaultSeries.Omron:
                    var addr2 = uint.Parse(Regex.Replace(address, "[a-zA-Z]", ""));
                    var byteShake = (byte[])MemoryCacheHelper.GetCache(CacheKeyHelper.HandShake);
                    value = client.Client.ReadFinsBool(byteShake, addr2);
                    break;
            }
            return value;
        }
        internal static void WriteUShort(this SocketEx client, string address, ushort data)
        {

        }
        internal static void WriteUInt(this SocketEx client, string address, uint data)
        {

        }
        internal static void WriteBool(this SocketEx client, string address, bool data)
        {

        }
        internal static void ReadData(this SocketEx client, PlcDetailDataModel model)
        {

        }
        internal static void WriteData(this SocketEx client, PlcDetailDataModel model, object data)
        {

        }
        #endregion
    }
}
