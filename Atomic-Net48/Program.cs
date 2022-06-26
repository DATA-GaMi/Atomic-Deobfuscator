using System;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace Atomic_Net48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename;
            try
            {
                filename = args[0];
            }
            catch
            {
                Console.Write("Enter path: ");
                filename = Console.ReadLine().Replace(@"""", "");
            }
            Console.Title = "Atomic Deobfuscator By CursedSheep ;D";
            Console.WriteLine("Atomic Deobfuscator by Cursedsheep ;D");
            ModuleDefMD module = ModuleDefMD.Load(filename);
            Console.WriteLine("Hide methods: " + HideMethodsRemover.Deobfuscate(module));
            ModuleWriterOptions mod = new ModuleWriterOptions(module);
            mod.MetadataLogger = DummyLogger.NoThrowInstance;
            string patho = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "-Deobfuscated" + Path.GetExtension(filename);
            module.Write(patho, mod);
            Console.WriteLine("saved to " + patho);
            Console.ReadKey();
        }
    }
}
