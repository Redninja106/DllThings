using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Header;

internal class DataDirectories : PENode
{
    public override void Dump(Stream stream)
    {
        stream.Pad(8);

        stream.Write(0x2000);

        stream.Pad(0x138 - (int)stream.Position);
    }
}
