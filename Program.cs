using System;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSampleViewModel();
            EmitDemo.GenerateAssembly();
        }

        static void GenerateSampleViewModel()
        {
            const string models = @"namespace Models
{
  public class Item
  {
    public string ItemName { get; set }
  }
}
";
            var node = CSharpSyntaxTree.ParseText(models).GetRoot();
            var viewModel = ViewModelGeneration.GenerateViewModel(node);
            if (viewModel != null)
                Console.WriteLine(viewModel.ToFullString());
            // Console.ReadLine();
        }
    }
}
