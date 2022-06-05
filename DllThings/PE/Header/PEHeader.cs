using DllThings.PE.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Header;

internal class PEHeader : PENode
{
    protected override void Initialize()
    {
        AddChild(new DOSHeader());
        AddChild(new COFFHeader());
        AddChild(new OptionalHeader());
        AddChild(new DataDirectories());
        AddChild(new SectionsTable());
        base.Initialize();
    }
}