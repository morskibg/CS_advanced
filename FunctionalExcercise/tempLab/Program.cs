using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SortEven
{
    class Program
    {

        public static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition == "older")
            {
                return x => x >= age;
            }
            else
            {
                return x => x < age;
            }
        }
        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            if (format == "name")
            {
                return x => Console.WriteLine($"{x.Key}");
            }
            else if (format == "age")
            {
                return x => Console.WriteLine($"{x.Value}");
            }
            else
            {
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> data = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                data[tokens[0]] = int.Parse(tokens[1]);
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            var filtyr = CreateTester(condition, age);
            var printer = CreatePrinter(format);
            foreach (var person in data.Where(x => filtyr(x.Value)))
            {
                printer(person);
            }
        }
    }
}
