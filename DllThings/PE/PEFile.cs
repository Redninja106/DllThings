using DllThings.PE.Header;
using DllThings.PE.Sections;
using DllThings.PE.Sections.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE;

internal class PEFile : PENode
{
    // https://raw.githubusercontent.com/corkami/pics/master/binary/pe101/pe101l.png

    public PEHeader PEHeader = new();
    public CodeSection CodeSection = new();
    public ImportsSection ImportsSection = new();
    public DataSection DataSection = new();

    protected override void Initialize()
    {
        AddChild(PEHeader);
        AddChild(CodeSection);
        AddChild(ImportsSection);
        AddChild(DataSection);
        base.Initialize();
    }

    public PEFile()
    {
        Initialize();
    }

    public void AddDataString()
    {
        
    }
    
    public void AddImport(string dll, string fn)
    {
        var imports = FindInChildren<ImportsSection>();
        imports.AddImport(dll, fn);
    }

    public void AddInstructionBytes(Span<byte> bytes)
    {
        
    }

    public override void Dump(Stream stream)
    {
        int location = 0;
        UpdateLocation(ref location);
        base.Dump(stream);
    }
}
