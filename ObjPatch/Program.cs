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
            public string? InputObjPath { get; set; }

            [Option('p', "patch-obj", Required = true)]
            public string? PatchObjPath { get; set; }

            [Option('o', "out", Required = false, Default = "out.o")]
            public string? OutObjPath { get; set; }
        }

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        static void Run(Options opts)
        {
            Console.WriteLine(opts.InputObjPath);
            Console.WriteLine(opts.OutObjPath);
        }
    }
}