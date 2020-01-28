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
                    //this reads first 200 bytes of DB1 - - does't work getting 0
                    var bytes = plc.ReadBytes(DataType.DataBlock, 9000, 0, 200);

                    // Try get structure tag using struct - does't work getting 0
                    RollingMillStructTag test = (RollingMillStructTag)plc.ReadStruct(typeof(RollingMillStructTag), 9000);

                    //Try get structure tag using class - does't work getting 0
                    RollingMillStructTagClass testClass = new RollingMillStructTagClass();
                    plc.ReadClass(testClass, 9000);

                    for (int i = 24; i <= 2292; i+=126)
                    {
                        var buffer = new RollingMill();
                        buffer.GM[i]= plc.Read(DataType.DataBlock, 9000, i, VarType.DWord, 1);                        
                    }


                }
                else
                    Console.WriteLine("Connection not alive");
                plc.Close();
            }
            else
                Console.WriteLine("PLC not available");
            
            
        }

        //ReadBytes it's limited to 200 bytes. Method with recusion
        public static List<byte> ReadMultipleBytes(int numBytes, int db, int startByteAdr = 0)
        {
            List<byte> resultBytes = new List<byte>();
            int index = startByteAdr;
            while (numBytes > 0)
            {
                var maxToRead = (int)Math.Min(numBytes, 200);
                byte[] bytes = ReadBytes(DataType.DataBlock, db, index, (int)maxToRead);
                if (bytes == null)
                    return resultBytes;
                resultBytes.AddRange(bytes);
                numBytes -= maxToRead;
                index += maxToRead;
            }

            return resultBytes;
        }

        public struct RollingMillStructTag 
        {
            public UInt32 DWordNF;
            public UInt32 DWordNZR;
            public UInt32 DWordVF;
            public UInt32 DWordVPR;
            public UInt32 DWOrdVZR;
        }

        
    }
}
