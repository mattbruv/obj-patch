using System;
using LibObjectFile.Elf;
using CommandLine;

namespace ObjPatch
{
    internal class Program
    {
        public class Options
        {
            [Option('i', "input-obj", Required = true)]
            public string InputObjPath { get; set; } = String.Empty;

            [Option('p', "patch-obj", Required = true)]
            public string PatchObjPath { get; set; } = String.Empty;

            [Option('o', "out", Required = false, Default = "out.o")]
            public string OutObjPath { get; set; } = String.Empty;
        }

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        static void Run(Options opts)
        {
            var patchStream = File.OpenRead(opts.PatchObjPath);
            var patchElf = ElfObjectFile.Read(patchStream);

            var outElfStream = File.OpenWrite(opts.OutObjPath);
            patchElf.Write(outElfStream);
        }
    }
}