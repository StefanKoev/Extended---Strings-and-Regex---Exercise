using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string privateMessagRegex = @"^([0-9]+) <-> ([A-Za-z0-9]+)$";
            string broadcastRegex = "^([^0-9]+) <-> ([A-Za-z0-9]+)$";

            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            while (input != "Hornet is Green")
            {
                var privateMessageMatch = Regex.Match(input, privateMessagRegex);
                var broadcastMatch = Regex.Match(input, broadcastRegex);
            
                if (privateMessageMatch.Success)
                {
                    string recipiendCode = privateMessageMatch.Groups[1].ToString();
                    recipiendCode = string.Join("", recipiendCode.ToCharArray().Reverse().ToArray());
                    messages.Add(recipiendCode + " -> " + privateMessageMatch.Groups[2].ToString());
                }

                if (broadcastMatch.Success)
                {
                    string frequency = broadcastMatch.Groups[2].ToString();
                    string frequencyResult = "";
                    for (int i = 0; i < frequency.Length; i++)
                    {
                        if (char.IsLower(frequency[i]))
                        {
                            frequencyResult += frequency[i].ToString().ToUpper();
                        }
                        else if (char.IsUpper(frequency[i]))
                        {
                            frequencyResult += frequency[i].ToString().ToLower();
                        }
                        else
                        {
                            frequencyResult += frequency[i].ToString();
                        }
                    }
                    broadcasts.Add(frequencyResult + " -> " + broadcastMatch.Groups[1]);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                broadcasts.ForEach(e => Console.WriteLine(e));
            }

            Console.WriteLine("Messages:");
            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                messages.ForEach(e => Console.WriteLine(e));
            }
        }
    }
}
