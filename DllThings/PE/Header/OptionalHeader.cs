using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Header;

internal class OptionalHeader : PENode
{
    public override void Dump(Stream stream)
    {
        // optional header magic
        stream.WriteByte(0x0B);
        stream.WriteByte(0x01);

        stream.Pad(14);
        
        // address of entry point
        stream.Write(0x1000);

        stream.Pad(8);

        // image base
        stream.Write(0x400000);

        // section alignment
        stream.Write(0x1000);

        // file alignment
        stream.Write(0x200);

        stream.Pad(8);

        // subsystem version
        stream.WriteByte(0x04);
        stream.WriteByte(0x00);

        stream.Pad(6);

        // size of image
        stream.Write(0x4000);

        // size of headers
        stream.Write(0x200);

        stream.Write(0x0);
        
        // subsystem
        stream.Write<short>(0x02);

        stream.Pad(22);

        // number of rva and sizes
        stream.Write(0x10);
    }
}
