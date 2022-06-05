using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllThings.PE;

internal abstract class PENode
{
    private static readonly DummyStream dummyStream = new();

    public PENode Parent => parent;
    public PEFile Root => root;
    public IReadOnlyList<PENode> Children => children;
    public int Begin => begin;
    public int End => begin + Size - 1;
    public int Size => GetSize();

    private PEFile root;
    private PENode parent;
    private readonly List<PENode> children = new(); 
    private int begin;
    private bool initialized;

    public virtual void Dump(Stream stream)
    {
        foreach (var c in children)
        {
            c.Dump(stream);
        }
    }
    

    public PENode()
    {
    }        

    protected virtual void Initialize()
    {
        foreach (var child in children)
        {
            child.Initialize();
        }

        initialized = true;
    }

    public void SetParent(PENode parent)
    {
        this.parent = parent;

        // find root element
        PENode root = this;
        while (root.Parent is not null)
        {
            root = root.Parent;
        }

        this.root = root as PEFile;

        if (parent is not null)
        {
            //parent.ChildResized(this);
        }

        if (initialized)
            Initialize();
    }

    public void AddChild(PENode child)
    {
        if (this.children.Contains(child))
            throw new Exception();

        children.Add(child);
        child.SetParent(this);

        //Parent?.ChildResized(this);
    }

    private void ChildResized(PENode child)
    {
        var index = children.IndexOf(child);

        for (int i = index + 1; i < children.Count; i++)
        {
            //children[i].UpdateLocation(children[i - 1].End + 1);
        }

        //if (Parent != null)
            //Parent.ChildResized(child);
    }

    public T FindInChildren<T>() where T : PENode
    {
        return FindAllInChildren<T>().FirstOrDefault();
    }

    public IEnumerable<T> FindAllInChildren<T>() where T : PENode
    {
        foreach (var child in Children)
        {
            if (child is T element)
            {
                yield return element;
            }

            foreach (var elem in child.FindAllInChildren<T>())
            {
                yield return elem;
            }
        }
    }

    protected virtual int GetSize()
    {
        if (children.Any())
        {
            return children.Sum(c=>c.Size);
        }
        else
        {
            dummyStream.Position = Begin;
            Dump(dummyStream);
            return ((int)dummyStream.Position - Begin);
        }
    }

    internal virtual void UpdateLocation(int begin)
    {
        this.begin = begin;
    }

    internal virtual void UpdateLocation(ref int location)
    {
        begin = location;

        if (this.children.Any())
        {
            foreach (var child in children)
            {
                child.UpdateLocation(ref location);
            }
        }
        else
        {
            location += GetSize();
        }
    }
}