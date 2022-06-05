using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Header;
internal class SectionsTable : PENode
{
    public override void Dump(Stream stream)
    {
        stream.Write(".text", 8);
        
        stream.Write(0x1000);
        stream.Write(0x1000);
        stream.Write(0x200);
        stream.Write(0x200);

        stream.Pad(12);

        stream.WriteByte(0x20);
        stream.WriteByte(0x00);
        stream.WriteByte(0x00);
        stream.WriteByte(0x60);
        
        stream.Write(".rdata", 8);

        stream.Write(0x1000);
        stream.Write(0x2000);
        stream.Write(0x200);
        stream.Write(0x400);
        
        stream.Pad(12);

        stream.WriteByte(0x40);
        stream.WriteByte(0x00);
        stream.WriteByte(0x00);
        stream.WriteByte(0x40);
        
        stream.Write(".data", 8);

        stream.Write(0x1000);
        stream.Write(0x3000);
        stream.Write(0x200);
        stream.Write(0x600);
        
        stream.Pad(12);

        stream.WriteByte(0x40);
        stream.WriteByte(0x00);
        stream.WriteByte(0x00);
        stream.WriteByte(0xc0);
    }
}
