using System;
using System.IO;
using System.Collections.Generic;

using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace AtomicDeobfuscator
{
    class Program
    {
        private static void F(string filename)
        {
            Console.Title = "Atomic Deobfuscator";
            Console.WriteLine("Atomic Deobfuscator");
            ModuleDefMD module = ModuleDefMD.Load(filename);
            Console.WriteLine("Hide methods: " + hideMethodsRemover.Deobfuscate(module));
            ModuleWriterOptions mod = new ModuleWriterOptions(module);
            mod.MetadataLogger = DummyLogger.NoThrowInstance;
            string patho = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "-Deobfuscated" + Path.GetExtension(filename);
            module.Write(patho, mod);
            Console.WriteLine("saved to " + patho);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[Path]:");
                Console.ResetColor();
                string filename = Console.ReadLine().Replace(@"""", string.Empty);
                F(filename);
            }
        }
    }
}
