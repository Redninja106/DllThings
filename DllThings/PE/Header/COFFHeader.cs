using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Header;
internal class COFFHeader : PENode
{
    public override void Dump(Stream stream)
    {
        // PE Header magic number
        stream.WriteByte(0x50);
        stream.WriteByte(0x45);
        stream.WriteByte(0x00);
        stream.WriteByte(0x00);

        // i386 machine
        stream.WriteByte(0x4C);
        stream.WriteByte(0x01);

        // 3 sections
        stream.WriteByte(0x03);
        stream.WriteByte(0x00);

        stream.Pad(12);

        // size of optional header
        stream.WriteByte(0xe0);
        stream.WriteByte(0x00);

        // characteristics (32bit dll)
        stream.WriteByte(0x02);
        stream.WriteByte(0x01);
    }
}
