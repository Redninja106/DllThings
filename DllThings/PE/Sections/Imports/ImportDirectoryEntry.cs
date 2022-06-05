using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Sections.Imports;

internal class ImportDirectoryEntry : PENode
{
    RVANode<ImportLookupTable> lookupTable;
    RVANode<ImportLookupTable> thunkTable;
    RVANode<LibraryNameEntry> name;

    public override void Dump(Stream stream)
    {
        lookupTable.Dump(stream);
        stream.Pad(8);
        name.Dump(stream);
        thunkTable.Dump(stream);
    }

    protected override void Initialize()
    {
        AddChild(lookupTable);
        AddChild(thunkTable);
        AddChild(name);
    }
}
