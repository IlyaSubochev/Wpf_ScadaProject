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
                if (!plc.IsConnected)
                {
                    //this reads first 200 bytes of DB1
                    var bytes = plc.ReadBytes(DataType.DataBlock, 1, 0, 200);
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
                    return new List<byte>();
                resultBytes.AddRange(bytes);
                numBytes -= maxToRead;
                index += maxToRead;
            }

            return resultBytes;
        }
    }
}
