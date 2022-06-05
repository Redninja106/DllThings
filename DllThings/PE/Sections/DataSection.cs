using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Sections;

internal class DataSection : PENode
{
    public override void Dump(Stream stream)
    {
        stream.PadTo(0x600);

        stream.Write("a simple PE executable");
        stream.Write("Hello world!");

        stream.PadTo(0x800);
    }
}
