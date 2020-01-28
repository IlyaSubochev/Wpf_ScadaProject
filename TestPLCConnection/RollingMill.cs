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
            GM = new object[18];
            
        }
        public object [] GM { get; set; }
        public UInt32 G1 { get; set; }
        public UInt32 G2 { get; set; }
        public UInt32 G3 { get; set; }
        public UInt32 G4 { get; set; }
        public UInt32 G5 { get; set; }
        public UInt32 G6 { get; set; }
        public UInt32 G7 { get; set; }
        public UInt32 G8 { get; set; }
        public UInt32 G9 { get; set; }
        public UInt32 G10 { get; set; }
        public UInt32 G11 { get; set; }
        public UInt32 G12 { get; set; }
        public UInt32 G13 { get; set; }
        public UInt32 G14 { get; set; }
        public UInt32 G15 { get; set; }
        public UInt32 G16 { get; set; }
        public UInt32 G17 { get; set; }
        public UInt32 G18 { get; set; }

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
