using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;
using Newtonsoft.Json;

namespace TestModbusTcp
{
    class TestEntity
    {
        public string Name { get; set; }
    }
    internal class Program
    {
        static TcpClient client;
        static byte[] HexToByte(string value)
        {
            value = value.Replace(" ", "");
            byte[] buffer = new byte[value.Length / 2];
            for (int i = 0; i < value.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(value.Substring(i, 2), 16);
            }
            return buffer;
        }
        public static bool IsOctal(double str)
        {
            const string PATTERN = @"[0-7]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(str.ToString(), PATTERN);
        }
        public static bool IsHexadecimal(double str)
        {
            const string PATTERN = @"[A-Fa-f0-9]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(str.ToString(), PATTERN);
        }
        static byte[] Address;
        static byte[] AddressBit;
        private static byte GetType(string TypeInt, int SizeofInt)
        {
            byte ms = 0x00;
            if (TypeInt.IndexOf("D") == 0 | TypeInt.IndexOf("d") == 0)
            {
                if (SizeofInt == 0)
                {
                    ms = 0x82;
                    if (TypeInt.IndexOf(".") == -1)
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.Length - 1)));
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
                else
                {
                    ms = 0x02;
                    if (TypeInt.IndexOf(".") > 1)
                    {
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.IndexOf(".") - 1)));
                        AddressBit = BitConverter.GetBytes(int.Parse(TypeInt.Substring(TypeInt.IndexOf(".") + 1, TypeInt.Length - TypeInt.IndexOf(".") - 1)));
                    }
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
            }
            else if (TypeInt.IndexOf("CIO") == 0 | TypeInt.IndexOf("cio") == 0)
            {
                if (SizeofInt == 0)
                {
                    ms = 0xB0;
                    if (TypeInt.IndexOf(".") == -1)
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(3, TypeInt.Length - 3)));
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
                else
                {
                    ms = 0x30;
                    if (TypeInt.IndexOf(".") > 3)
                    {
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(3, TypeInt.IndexOf(".") - 3)));
                        AddressBit = BitConverter.GetBytes(int.Parse(TypeInt.Substring(TypeInt.IndexOf(".") + 1, TypeInt.Length - TypeInt.IndexOf(".") - 1)));
                    }
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
            }
            else if (TypeInt.IndexOf("W") == 0 | TypeInt.IndexOf("w") == 0)
            {
                if (SizeofInt == 0)
                {
                    ms = 0xB1;
                    if (TypeInt.IndexOf(".") == -1)
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.Length - 1)));
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
                else
                {
                    ms = 0x31;
                    if (TypeInt.IndexOf(".") > 1)
                    {
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.IndexOf(".") - 1)));
                        AddressBit = BitConverter.GetBytes(int.Parse(TypeInt.Substring(TypeInt.IndexOf(".") + 1, TypeInt.Length - TypeInt.IndexOf(".") - 1)));
                    }
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
            }
            else if (TypeInt.IndexOf("H") == 0 | TypeInt.IndexOf("h") == 0)
            {
                if (SizeofInt == 0)
                {
                    ms = 0xB2;
                    if (TypeInt.IndexOf(".") == -1)
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.Length - 1)));
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
                else
                {
                    ms = 0x32;
                    if (TypeInt.IndexOf(".") > 1)
                    {
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.IndexOf(".") - 1)));
                        AddressBit = BitConverter.GetBytes(int.Parse(TypeInt.Substring(TypeInt.IndexOf(".") + 1, TypeInt.Length - TypeInt.IndexOf(".") - 1)));
                    }
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
            }
            else if (TypeInt.IndexOf("A") == 0 | TypeInt.IndexOf("a") == 0)
            {
                if (SizeofInt == 0)
                {
                    ms = 0xB3;
                    if (TypeInt.IndexOf(".") == -1)
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.Length - 1)));
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
                else
                {
                    ms = 0x33;
                    if (TypeInt.IndexOf(".") > 1)
                    {
                        Address = BitConverter.GetBytes(int.Parse(TypeInt.Substring(1, TypeInt.IndexOf(".") - 1)));
                        AddressBit = BitConverter.GetBytes(int.Parse(TypeInt.Substring(TypeInt.IndexOf(".") + 1, TypeInt.Length - TypeInt.IndexOf(".") - 1)));
                    }
                    else
                    {
                        Address = new Byte[1];
                        AddressBit = new Byte[1];
                    }
                }
            }
            return ms;
        }

        static void Main(string[] args)
        {
            {
                var asdds = 12.ToString("X2");
                //var hex = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }.ByteToHex();
                var bytes = new byte[] { 0xD0, 0x58, 0x4C, 0x4D };
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 816);
                Console.ReadLine();
            }
            {
                TestEntity entity = new TestEntity() { Name = "测试" };
                var json = JsonConvert.SerializeObject(entity);
                var arr = Encoding.ASCII.GetBytes(json);
                var a3 = BitConverter.ToString(new byte[] { 12 }, 0).Replace("-", " ").ToUpper();
                client = new TcpClient();
                client.Connect(IPAddress.Parse("10.1.62.102"), 502);
                var tupe = client.Client.HandShake();
                Console.ReadLine();
            }
            {
                var array = new string[] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m" };
                foreach(var item in array)
                {
                    var arr1 = Encoding.ASCII.GetBytes(item);
                    var a1 = BitConverter.ToString(arr1, 0).Replace("-", " ").ToUpper();

                    var arr2 = Encoding.ASCII.GetBytes(item.ToUpper());
                    var a2 = BitConverter.ToString(arr2, 0).Replace("-", " ").ToUpper();

                    Console.WriteLine($"{item}:{a1} <--> {item.ToUpper()}:{a2}");
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            {
                var a12 = HexToByte("4E");
                ASCIIEncoding aSCII = new ASCIIEncoding();
                var arr= Encoding.ASCII.GetBytes("a");
                var a4= Convert.ToString(97);
                var a= 520.ToString("X2");
                var a3 = BitConverter.ToString(new byte[] { 08 }, 0).Replace("-", " ").ToUpper();
                var a2 = HexToByte("D0");
                //var tuple = TransportAddressHelper.Instance.GetTransportHex("DVP","c210");
                //var a1= HexToByte(tuple.Item2);
                Console.ReadLine();
            }
            {
                var b5 = Convert.ToByte("270", 8);
                var str = 45891.ToString("X2");
                var b4 = Regex.Replace(str, "[a-zA-Z]", "");
                var b1 = (byte)(9999999 >> 8 & 0xFFu);
                var b2 = (byte)(9999999 & 0xFFu); 
                var b3 = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[] { b1, b2 }, 0));

                var a1 = HexToByte("AEDF");
                var dt1 = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(a1, 0));
                var a2 = HexToByte("0EC7");
                var dt2 = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(a2, 0));
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 502);
                //var data1 = client.Client.ReadModbusBool(0);
                //client.Client.WriteModbusBool(3, true);
                //client.Client.WriteModbusUshort(0, 2000);
                {
                    // write
                    //var buffer = new byte[]
                    //{
                    //    0x00, 0x01, // tid
                    //    0x00, 0x00,
                    //    0x00, 0x09, //len
                    //    0x01, // slave id
                    //    0x10, // funtion
                    //    0x00, 0x00, // address
                    //    0x00, 0x01, // nums
                    //    0x02, // byte num
                    //    0x00, 0x02 // value
                    //}; 
                    //var buffer = new byte[]
                    // {
                    //    0x00, 0x01, // tid
                    //    0x00, 0x00,
                    //    0x00, 0x06, //len
                    //    0x01, // slave id
                    //    0x05, // funtion
                    //    0x00, 0x00, // address
                    //    0xFF, 0x00, // true
                    //    //0x00, 0x00 // false
                    // };
                    //client.Client.Send(buffer, buffer.Length, SocketFlags.None);
                    //byte[] response = new byte[12];
                    //client.Client.Receive(response, response.Length, SocketFlags.None);
                    //Console.WriteLine(BitConverter.ToString(response, 0).Replace("-", " ").ToUpper());
                }
                //Console.ReadLine();
                while (true)
                {
                    // Read
                    var buffer0 = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x00, 0x00, 0x02 };
                    var buffer2 = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x02, 0x00, 0x02 };
                    var buffer4 = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x04, 0x00, 0x02 };
                    var buffer6 = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x06, 0x00, 0x02 };
                    var buffer8 = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x08, 0x00, 0x02 };
                    client.Client.Send(buffer0, buffer0.Length, SocketFlags.None);
                    client.Client.Send(buffer2, buffer2.Length, SocketFlags.None);
                    client.Client.Send(buffer4, buffer4.Length, SocketFlags.None);
                    client.Client.Send(buffer6, buffer6.Length, SocketFlags.None);
                    client.Client.Send(buffer8, buffer8.Length, SocketFlags.None);

                    byte[] response0 = new byte[13];
                    byte[] response2 = new byte[13];
                    byte[] response4 = new byte[13];
                    byte[] response6 = new byte[13];
                    byte[] response8 = new byte[13];

                    client.Client.Receive(response0, response0.Length, SocketFlags.None);
                    client.Client.Receive(response2, response2.Length, SocketFlags.None);
                    client.Client.Receive(response4, response4.Length, SocketFlags.None);
                    client.Client.Receive(response6, response6.Length, SocketFlags.None);
                    client.Client.Receive(response8, response8.Length, SocketFlags.None);

                    byte[] temp0 = new byte[] { response0[9], response0[10], response0[11], response0[12] };
                    short[] data0 = new short[2];
                    for (int i = 0; i < data0.Length; i++)
                    {
                        data0[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp0, i * 2));
                    }
                    byte[] temp2 = new byte[] { response2[9], response2[10], response2[11], response2[12] };
                    short[] data2 = new short[2];
                    for (int i = 0; i < data2.Length; i++)
                    {
                        data2[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp2, i * 2));
                    }
                    byte[] temp4 = new byte[] { response4[9], response4[10], response4[11], response4[12] };
                    short[] data4 = new short[2];
                    for (int i = 0; i < data4.Length; i++)
                    {
                        data4[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp4, i * 2));
                    }
                    byte[] temp6 = new byte[] { response6[9], response6[10], response6[11], response6[12] };
                    short[] data6 = new short[2];
                    for (int i = 0; i < data6.Length; i++)
                    {
                        data6[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp6, i * 2));
                    }
                    byte[] temp8 = new byte[] { response8[9], response8[10], response8[11], response8[12] };
                    short[] data8 = new short[2];
                    for (int i = 0; i < data8.Length; i++)
                    {
                        data8[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(temp8, i * 2));
                    }

                    //Console.WriteLine(BitConverter.ToString(response, 0).Replace("-", " ").ToUpper());
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}-->>data0:{string.Join(",", data0[0])}");
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}-->>data2:{string.Join(",", data2[0])}");
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}-->>data4:{string.Join(",", data4[0])}");
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}-->>data6:{string.Join(",", data6[0])}");
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}-->>data8:{string.Join(",", data8[0])}");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                Console.ReadLine();
                BuildMessageFrame();
                var result = ReadData();
                Console.WriteLine(string.Join(",", result));
                Console.ReadLine();;
                Console.ReadLine();
            }
            {
                var buffer = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x07, 0xDA, 0x00, 0x02 };
                client.Client.Send(buffer, buffer.Length, SocketFlags.None);
                byte[] response = new byte[13];
                client.Client.Receive(response, response.Length, SocketFlags.None);
                Console.ReadLine();
            }
            {
                //var re = BitConverter.GetBytes((ushort)7257).Concat(BitConverter.GetBytes((ushort)2)).ToArray();
                //var sdsda = BitConverter.ToUInt32(re, 0);

                client = new TcpClient();
                client.Connect(IPAddress.Parse("10.1.62.102"), 502);
                var tupe = client.Client.HandShake();
                //client.Client.WriteUShort(tupe.Item2, 2000, 1);
                //client.Client.WriteBool(tupe.Item2, 45.01, true);
                //client.Client.WriteInt(tupe.Item2, 2000, 9999999);
                var result1 = client.Client.ReadUInt(tupe.Item2, 2000);
                //var result2 = client.Client.ReadBool(tupe.Item2, 45.01);
                //Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} result1->{result1}  result2->{result2}");
                Console.ReadLine();
            }
            {
                //46 49 4E 53 header
                //00 00 00 18 length
                //00 00 00 02 command
                //00 00 00 00 error code
                //C0 ICF
                //00 RSV
                //07 GCT
                //00 DNA
                //DD DA1
                //00 DA2
                //00 SNA
                //66 SA1
                //00 SA2
                //52 SID
                //01 MRC
                //01 SRC   28
                //90 05 Error Code
                //00 01
                //00 00
                //00 00
                //00 00
                //00 00
            }
            {
                //var data1 = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { 00, 64 }, 0));
                //var asda = GetType("D2010", 0);
                var arr = HexToByte("1A");
                //var sd = FinsTcpArea.DM.ToByte();
                //var sdads = HexToByte(FinsTcpArea.DM.ToString());
                var a = 30.ToString("X2");
                var arrsd = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int)1));
                //var data = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { 97, 0x7A }, 0));
                //var arr = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)45));
                //short ad = -26758;
                //var data1 = (ushort)ad;
                var asd = Convert.ToByte(28);
                client = new TcpClient();
                //client.ReceiveTimeout = 5000;
                //client.SendTimeout = 5000;
                client.Connect(IPAddress.Parse("10.1.62.102"), 502);
                byte[] result = new byte[24];
                {
                    List<byte> list = new List<byte>();
                    list.AddRange(new byte[] { 0x46, 0x49, 0x4E, 0x53 });
                    list.AddRange(new byte[] { 00, 00, 00, 0x0C });
                    list.AddRange(new byte[] { 00, 00, 00, 00 });
                    list.AddRange(new byte[] { 00, 00, 00, 00 });
                    list.AddRange(new byte[] { 00, 00, 00, 00 });
                    client.Client.Send(list.ToArray());
                    var rs = client.Client.Receive(result);
                }
                {
                    //var headerByte = result.Skip(0).Take(4).ToArray();
                    //Console.WriteLine("header:" + BitConverter.ToString(headerByte, 0).Replace("-", " ").ToUpper());
                    //var lenthByte = result.Skip(4).Take(4).ToArray();
                    //Console.WriteLine("length:" + BitConverter.ToString(lenthByte, 0).Replace("-", " ").ToUpper());
                    //var commandByte = result.Skip(8).Take(4).ToArray();
                    //Console.WriteLine("command:" + BitConverter.ToString(commandByte, 0).Replace("-", " ").ToUpper());
                    //var errorcodeByte = result.Skip(12).Take(4).ToArray();
                    //Console.WriteLine("errorcode:" + BitConverter.ToString(errorcodeByte, 0).Replace("-", " ").ToUpper());
                    //var clientByte = result.Skip(16).Take(4).ToArray();
                    //Console.WriteLine("client Node:" + BitConverter.ToString(clientByte, 0).Replace("-", " ").ToUpper());
                    //var serverByte = result.Skip(20).Take(4).ToArray();
                    //Console.WriteLine("server Node:" + BitConverter.ToString(serverByte, 0).Replace("-", " ").ToUpper());
                }
                {
                    // DA1 SA1 dataValue add1  add2 add3 num1 num2
                    List<byte> header = new List<byte>();
                    header.AddRange(HexToByte("46494E53")); // FINS
                    //header.AddRange(HexToByte("0000001A")); // LEN
                    header.AddRange(HexToByte("0000001B")); // LEN
                    //header.Add(Convert.ToByte(27));
                    header.AddRange(HexToByte("00000002")); // COMM
                    header.AddRange(HexToByte("00000000")); //ERROR

                    var list = new List<byte>();
                    list.Add(0x80); //ICF
                    list.Add(0x00); //RSV
                    list.Add(0x02); //GCT
                    list.Add(0x00); //DNA
                    list.Add(result[23]); //DA1
                    list.Add(00); //DA2
                    list.Add(00); //SNA
                    list.Add(result[19]); //SA1
                    list.Add(00); //SA2
                    list.Add(01); //SID
                    list.Add(01); //MRC
                    list.Add(02); //SRC
                    list.Add(0x31); //AREA
                    list.AddRange(new byte[] { 00, 45, 01 }); //ADDRESS
                    list.AddRange(new byte[] { 00, 01 }); // LENGTH
                    //list.AddRange(new byte[] { 00, 02 });
                    client.Client.Send(header.ToArray(), header.Count, SocketFlags.None);
                    client.Client.Send(list.ToArray(), 18 , SocketFlags.None);
                    client.Client.Send(new byte[] { 0x00 }, 1, SocketFlags.None);
                    byte[] buffer = new byte[26];
                    client.Client.Receive(buffer, buffer.Length, SocketFlags.None);
                    Console.WriteLine(BitConverter.ToString(buffer, 0).Replace("-", " ").ToUpper());
                    //var asda = "";
                    //byte[] buffer = new byte[32];
                    //while (true)
                    //{
                    //    client.Client.Send(header.ToArray(), header.Count, SocketFlags.None);
                    //    client.Client.Send(list.ToArray());
                    //    client.Client.Receive(buffer, buffer.Length, SocketFlags.None);

                    //    //Console.WriteLine(BitConverter.ToString(buffer, 0).Replace("-", " ").ToUpper());
                    //    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}-->>{IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { buffer[30], buffer[31] }, 0))}");
                    //    Thread.Sleep(1000);
                    //}
                }
                Console.ReadLine();
            }
            {
                Console.WriteLine(IsOctal(375));
                Console.WriteLine(IsHexadecimal(64));
                var begin = HexToByte("0E00");
                var end = HexToByte("0EC7");
                var beginAddr = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(begin, 0 * 2));
                var endAddr = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(end, 0 * 2));
                Console.WriteLine($"beginAddr:{beginAddr}-->>endAddr:{endAddr}");

                //var source = HexToByte("6000");
                //var addr = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(source, 0 * 2));

                //var beginByte = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)(0 + addr)));
                //var beginHex = BitConverter.ToString(beginByte, 0).Replace("-", string.Empty).ToUpper();
                //var endByte = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)(1023 + addr)));
                //var endHex = BitConverter.ToString(endByte, 0).Replace("-", string.Empty).ToUpper();
                //Console.WriteLine($"beginHex:{beginHex}-->>endHex:{endHex}");
                Console.ReadLine();
            }
            {
                //short[] datas = new short[250 / 2];
                //for (var i = 0; i < datas.Length; i++)
                //{
                //    var data = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[250] { 00 0F }, i * 2));
                //    datas[i] = data;
                //}
                var buff = HexToByte("17ff");
                var h = Convert.ToByte("07", 16);
                var l = Convert.ToByte("DA", 16);
                var data = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buff, 0 * 2));
                byte[] buffer = new byte[] { 07, 78, 00, 00, 00, 06, 03, 03, 00, 00, 00, 03 };
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 502);
                byte[] result = new byte[1024];
                client.Client.Send(buffer);
                var rs = client.Client.Receive(result);
                //while (true)
                //{
                //    client.Client.Send(buffer);
                //    var rs = client.Client.Receive(result);
                //    Console.WriteLine(string.Join(",", result));
                //    Thread.Sleep(1000);
                //}
                Console.ReadLine();
            }
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("192.168.120.85"), 502);
                BuildMessageFrame();
                var result = ReadData();
                Console.WriteLine(string.Join(",", result));
                Console.ReadLine();
            }
        }
        private static short[] ReadData()
        {
            byte[] fullFrame = ReadRequestResponse();
            byte[] mbapHeader = fullFrame.Slice(0, 6).ToArray();
            var messageFrame = fullFrame.Slice(6, fullFrame.Length - 6).ToArray();

            var ByteCount = messageFrame[2];
            var tempArr = messageFrame.Slice(3, ByteCount).ToArray();

            short[] result = new short[tempArr.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(tempArr, i * 2));
            }
            return result;
        }
        private static byte[] ReadRequestResponse()
        {
            var mbapHeader = new byte[6];
            int numByteRead = 0;
            while (numByteRead != 6)
            {
                int read = client.GetStream().Read(mbapHeader, numByteRead, 6 - numByteRead);
                numByteRead += read;
            }
            var frameLength = (ushort)IPAddress.HostToNetworkOrder(BitConverter.ToInt16(mbapHeader, 4));
            var messageFrame = new byte[frameLength];
            numByteRead = 0;
            while (numByteRead != frameLength)
            {
                int read = client.GetStream().Read(messageFrame, numByteRead, frameLength - numByteRead);
                numByteRead += read;
            }
            var frame = mbapHeader.Concat(messageFrame).ToArray();
            return frame;
        }
        private static void BuildMessageFrame()
        {
            byte[] header = GetMbapHeader();
            byte[] pdu = ProtocolDataUnit();
            var messageBody = new MemoryStream(header.Length + pdu.Length);
            messageBody.Write(header, 0, header.Length);
            messageBody.Write(pdu, 0, pdu.Length);
            var arr = messageBody.ToArray();
            client.GetStream().Write(arr, 0, arr.Length);
        }
        private static byte[] GetMbapHeader()
        {
            var pdu = ProtocolDataUnit();
            byte[] tid = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)1));
            byte[] length = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)(pdu.Length + 1)));

            var stream = new MemoryStream(7);
            stream.Write(tid, 0, tid.Length);
            stream.WriteByte(0);
            stream.WriteByte(0);
            stream.Write(length, 0, length.Length);
            stream.WriteByte(1);
            return stream.ToArray();
        }
        private static byte[] MessageFrame()
        {
            var pdu = ProtocolDataUnit();
            var frame = new MemoryStream(1 + pdu.Length);
            frame.WriteByte(1);
            frame.Write(pdu, 0, pdu.Length);
            return frame.ToArray();
        }
        private static byte[] ProtocolDataUnit()
        {
            List<byte> pdu = new List<byte>();
            pdu.Add(3);
            //pdu.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)402011)));
            pdu.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)2010)));
            pdu.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)2)));
            return pdu.ToArray();
        }
    }

    public static class FinsTcpExtension
    {
        public static Tuple<bool, byte[]> HandShake(this Socket client)
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

        public static ushort ReadUSort(this Socket client, byte[] list, uint address)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            List<byte> buffer = new List<byte>(list);
            buffer.Add(0x82);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(0x00);
            buffer.Add(0x00);
            buffer.Add(0x01);
            var response = new byte[32];
            client.Send(header, SocketFlags.None);
            client.Send(buffer.ToArray(), SocketFlags.None);
            client.Receive(response, response.Length, SocketFlags.None);
            return (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { response[30], response[31] }, 0));
        }

        public static uint ReadUInt(this Socket client, byte[] list, uint address)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            List<byte> buffer = new List<byte>(list);
            buffer.Add(0x82);
            buffer.Add((byte)((uint)(address >> 8 & 0xFFu)));
            buffer.Add((byte)((uint)(address & 0xFFu)));
            buffer.Add(0x00);
            buffer.Add(0x00);
            buffer.Add(0x02);
            var response = new byte[34];
            client.Send(header, SocketFlags.None);
            client.Send(buffer.ToArray(), SocketFlags.None);
            client.Receive(response, response.Length, SocketFlags.None);
            var low = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { response[30], response[31] }, 0));
            var high = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(new byte[2] { response[32], response[33] }, 0));
            var re = BitConverter.GetBytes(low).Concat(BitConverter.GetBytes(high)).ToArray();
            return BitConverter.ToUInt32(re, 0);
        }

        public static bool ReadBool(this Socket client, byte[] list, double bitAddress)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            var arr = bitAddress.ToString().Split(".");
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
            var response = new byte[32];
            client.Send(header, SocketFlags.None);
            client.Send(buffer.ToArray(), SocketFlags.None);
            client.Receive(response, response.Length, SocketFlags.None);
            if (response[30] == 0) return false;
            else return true;
        }

        public static void WriteBool(this Socket client, byte[] list, double bitAddress, bool data)
        {
            var header = new byte[16] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1B, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
            var arr = bitAddress.ToString().Split(".");
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
            client.Send(header, header.Length, SocketFlags.None);
            client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
            byte byteData = 0x00;
            if (data) byteData = 0x01;
            client.Send(new byte[] { byteData }, 1, SocketFlags.None);
        }

        public static void WriteUShort(this Socket client, byte[] list, uint address, ushort data)
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
            client.Send(header, header.Length, SocketFlags.None);
            client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
            client.Send(new byte[] { ((byte)((uint)data >> 8 & 0xFFu)), ((byte)((uint)(data & 0xFFu))) }, 2, SocketFlags.None);
        }

        public static void WriteInt(this Socket client, byte[] list, uint address, int data)
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
            client.Send(header, header.Length, SocketFlags.None);
            client.Send(buffer.ToArray(), buffer.Count, SocketFlags.None);
            var tempData = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data));
            byte[] byteData = new byte[4] { tempData[2], tempData[3], tempData[0], tempData[1] };
            client.Send(byteData, 4, SocketFlags.None);
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
    }
    public sealed class ModbusTcpHelper1
    {
        private string _ip;
        private int _port;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public ModbusTcpHelper1(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Run()
        {
            // ip为空,返回空ModbusMaster
            TcpClient client = new TcpClient();
            client.BeginConnect(IPAddress.Parse(_ip), _port, TcpConnect, client);
        }

        /// <summary>
        /// Tcp 连接回调函数
        /// </summary>
        /// <param name="result"></param>
        private void TcpConnect(IAsyncResult result)
        {
            try
            {
                TcpClient client = (TcpClient)result.AsyncState;
                if (!client.Connected)
                {
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} 无法连接...");
                    client.Close();
                    var tc = new TcpClient();
                    tc.BeginConnect(IPAddress.Parse(_ip), _port, new AsyncCallback(TcpConnect), tc);
                }
                else
                {
                    client.EndConnect(result);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
