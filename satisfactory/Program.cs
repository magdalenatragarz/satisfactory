using System;

namespace Satisfactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyPressed;

            do
            {
                Console.Clear();

                var parser = new UserInputParser();
                var tree = parser.getTree();
                var wantedProductionPerMinute = parser.getWantedProductionPerMinute();

                var calculator = new BasicCalculator();
                var adjusted = calculator.adjustComponentTreeToWantedProduction(tree, wantedProductionPerMinute);

                Console.WriteLine(adjusted.getComponentTreeDescription());

                keyPressed = Console.ReadKey();

            } while (keyPressed.Key != ConsoleKey.Escape);
        }
    }
}
