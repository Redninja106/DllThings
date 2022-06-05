using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE.Sections.Imports;
internal class ImportsSection : PENode
{
    public ImportDirectoryTable table = new();
    public HintNameTable nameTable = new();

    public void AddImport(string library, string function)
    {
    }

    public override void Dump(Stream stream)
    {
        stream.PadTo(0x400);

        stream.Write(0x203c);
        stream.Pad(8);
        stream.Write(0x2078);
        stream.Write(0x2068);

        stream.Write(0x2044);
        stream.Pad(8);
        stream.Write(0x2085);
        stream.Write(0x2070);

        stream.Pad(20);

        stream.Write(0x204c);
        stream.Write(0);

        stream.Write(0x205a);
        stream.Write(0);

        stream.Write<short>(0);
        stream.Write("ExitProcess");

        stream.Write<short>(0);
        stream.Write("MessageBoxA");

        stream.Write<long>(0x204c);
        stream.Write<long>(0x205a);

        stream.Write("kernel32.dll");
        stream.Write("user32.dll");

        stream.PadTo(0x600);
    }
}
