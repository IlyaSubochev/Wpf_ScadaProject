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
                    //this reads first 200 bytes of DB1
                    var bytes = plc.ReadBytes(DataType.DataBlock, 9000, 0, 200);

                    // Try get structure tag using struct
                    RollingMillStructTag test = (RollingMillStructTag)plc.ReadStruct(typeof(RollingMillStructTag), 9000);

                    //Try get structure tag using class
                    RollingMillStructTagClass testClass = new RollingMillStructTagClass();
                    plc.ReadClass(testClass, 9000);


                    
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

        public class RollingMillStructTagClass
        {
            public UInt32 DWordNF { get; set; }
            public UInt32 DWordNZR { get; set; }
            public UInt32 DWordVF { get; set; }
            public UInt32 DWordVPR { get; set; }
            public UInt32 DWOrdVZR { get; set; }
        }
    }
}
