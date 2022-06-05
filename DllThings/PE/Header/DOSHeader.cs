using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Header;
internal class DOSHeader : PENode
{
    public override void Dump(Stream stream)
    {
        stream.WriteByte(0x4D);
        stream.WriteByte(0x5A);

        stream.Pad(58);

        var coffHeader = Root.FindInChildren<COFFHeader>();
        stream.Write(coffHeader.Begin);
    }

    protected override int GetSize()
    {
        return 0x40;
    }
}
