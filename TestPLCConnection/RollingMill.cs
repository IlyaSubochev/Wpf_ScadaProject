using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPLCConnection
{
    public class RollingMill
    {
        public RollingMill()
        {
           // GM = new uint[18];
            
        }
        //public uint [] GM { get; set; }
        public uint G01 { get; set; }
        public uint G02 { get; set; }
        public uint G03 { get; set; }
        public uint G04 { get; set; }
        public uint G05 { get; set; }
        public uint G06 { get; set; }
        public uint G07 { get; set; }
        public uint G08 { get; set; }
        public uint G09 { get; set; }
        public uint G10 { get; set; }
        public uint G11 { get; set; }
        public uint G12 { get; set; }
        public uint G13 { get; set; }
        public uint G14 { get; set; }
        public uint G15 { get; set; }
        public uint G16 { get; set; }
        public uint G17 { get; set; }
        public uint G18 { get; set; }

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
