using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPLCConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Plc plc = new Plc(CpuType.S71500, "192.168.0.202", 0, 1);
            if (plc.IsAvailable)
            {
                plc.Open();
                if (plc.IsConnected)
                {
                    //this reads first 200 bytes of DB1 - it's ok
                    var bytes = plc.ReadBytes(DataType.DataBlock, 9000, 0, 200);

                    // Try get structure tag using struct - it's ok
                    //RollingMillStructTag test = (RollingMillStructTag)plc.ReadStruct(typeof(RollingMillStructTag), 9000);

                    //Try get structure tag using class - it's ok
                    RollingMillStructTagClass testClass = new RollingMillStructTagClass();
                    plc.ReadClass(testClass, 9000);
                    int count = 0;
                    for (int i = 24; i < 2292; i+=126)
                    {
                        count += 1;
                        var buffer = new RollingMill();
                        plc.ReadClass(buffer, 9000, i);
                        //var buffer2 = plc.ReadBytes(DataType.DataBlock, 9000, i, 200);
                        //buffer.GM[count - 1] = BitConverter.ToUInt32(plc.ReadBytes(DataType.DataBlock, 9000, i, 4), 0);
                        //Console.WriteLine($"G{count - 1} = {buffer.GM[count - 1]}");
                    }
                   

                }
                else
                    Console.WriteLine("Connection not alive");
                plc.Close();
            }
            else
                Console.WriteLine("PLC not available");
            var buffer3 = ReadMultipleBytes(2166, 9000, 0);
            Console.ReadKey();
            
        }

        //ReadBytes it's limited to 200 bytes. Method with recusion
        public static List<byte> ReadMultipleBytes(int numBytes, int db, int startByteAdr)
        {
            Plc plc = new Plc(CpuType.S71500, "192.168.0.202", 0, 1);
            List<byte> resultBytes = new List<byte>();
            int index = startByteAdr;
            if (plc.IsAvailable)
            {
                plc.Open();
                if (plc.IsConnected)
                {
                    while (numBytes > 0)
                    {
                        var maxToRead = (int)Math.Min(numBytes, 200);
                        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, index, (int)maxToRead);
                        if (bytes == null)
                            return resultBytes;
                        resultBytes.AddRange(bytes);
                        numBytes -= maxToRead;
                        index += maxToRead;
                    }
                }
                plc.Close();
            }

            return resultBytes;
        }

       

        
    }
}
