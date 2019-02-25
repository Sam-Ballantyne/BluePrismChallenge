using BluePrism.Services;
using System;
namespace BluePrism
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictName = @"H:\Visual Studio 2017\Projects\BluePrism\BluePrism\TextFiles\dictionary.txt";
            var resultName = @"H:\Visual Studio 2017\Projects\BluePrism\BluePrism\TextFiles\result.txt";
            var startWord = "rune";
            var endWord = "runt";

            InputHandler handler = new InputHandler(dictName, resultName, startWord, endWord);
            Console.WriteLine(handler.Run());
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
