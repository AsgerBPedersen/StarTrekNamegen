using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace startrek_namegen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>{
                "[S|Sp|Sk|St|T] [a|e|i|o|u|y] [r|t|p|d|f|j|k|l|v|b|n|m] [a|e|i|o|u|y] [q|p|k|ck|l]",
                "[S|Sp|Sk|St|T] [a|e|i|o|u|y] [q|p|k|ck|l]",
                "[T’|C] [P|K|Q] [a|e|i|o|u|y] [r|j|’p|k|l]"
            };
            List<string> names = new List<string>();
            foreach (string s in input)
            {
                names = names.Concat(NameGenerator(CleanInput(s))).ToList();

            }

            SaveNames(names);
            Console.WriteLine(names.Count);
            Console.ReadKey();
        }

        static List<string[]> CleanInput(string input)
        {
            List<string> splitInput = input.Split(' ').ToList();

            List<string[]> output = new List<string[]>();


            for (int i = 0; i < splitInput.Count; i++)
            {
                splitInput[i] = splitInput[i].Replace("[", "");

                splitInput[i] = splitInput[i].Replace("]", "");

                splitInput[i] = splitInput[i].Replace('|', ' ');

                output.Add(splitInput[i].Split(' ').ToArray());
            }


            return output;
        }

        static void SaveNames(List<string> names)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\asge4899\\source\\repos\\startrek namegen\\startrek namegen\\names.txt"))
            {
                foreach (string name in names)
                {
                    writer.WriteLine(name);
                }
            }
        }

        static List<string> NameGenerator(List<string[]> input) {
            List<string> names = new List<string>();
            if(input.Count > 1)
            {
                
                foreach (string s in input[0])
                {
                    NameGenerator(input.GetRange(1, input.Count - 1)).ForEach(n => names.Add(s + n));
                }
            } else
            {
                foreach (string s in input[0])
                {

                    names.Add(s);
                }
            }
            return names;
        }
    }
}
