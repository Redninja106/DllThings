using DllThings.PE;

PEFile file = new();

using (var stream = File.Create("./a.exe"))
{
    file.Dump(stream);
    stream.Flush();
}

using (var stream = new MemoryStream(file.Size))
{
    file.Dump(stream);

    var bytes = stream.GetBuffer();

    for (int i = 0; i < bytes.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.White;

        if (i % 16 == 0)
        {
            Console.WriteLine();
            Console.Write($"0x{i:x4} | ");
        }

        if (bytes[i] == 0x00)
            Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.Write($"{bytes[i]:x2}");

        if (i % 16 == 3 || i % 16 == 11)
        {
            Console.Write('-');
        }
        else
        {
            Console.Write(' ');
        }

        if (i % 16 == 7)
        {
            Console.Write(' ');
        }
    }
}