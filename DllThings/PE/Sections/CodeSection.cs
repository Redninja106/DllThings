using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Sections;
internal class CodeSection : PENode
{
    public override void Dump(Stream stream)
    {
        stream.PadTo(0x200);

        Span<byte> instructions = stackalloc byte[]
        { 
            0x6A, 0x00, 0x68, 0x00, 0x30, 0x40, 0x00, 0x68, 0x17,
            0x30, 0x40, 0x00, 0x6A, 0x00, 0xFF, 0x15, 0x70, 0x20,
            0x40, 0x00, 0x6A, 0x00, 0xFF, 0x15, 0x68, 0x20, 0x40, 0x00
        };

        stream.Write(instructions);
        stream.PadTo(0x400);
    }
}
