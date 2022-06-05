using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE;

/// <summary>
/// A relative virtual address in a PRE file.
/// </summary>
/// <typeparam name="T"></typeparam>
internal class RVANode<T> : PENode where T : PENode
{
    public T Target { get; set; }

    public RVANode(T target)
    {
        Target = target;
    }

    protected override void Initialize()
    {
    }

    public override void Dump(Stream stream)
    {
        stream.Write(Target.Begin);
    }

    protected override int GetSize()
    {
        return 4;
    }
}
