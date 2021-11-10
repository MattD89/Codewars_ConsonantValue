using System;
using System.Collections.Generic;
using System.Linq;

namespace Consonant_Value
{
    class Program
    {
        //Given a lowercase string that has alphabetic characters only and no spaces, return the highest value of consonant substrings.Consonants are any letters of the alphabet except "aeiou".
        //We shall assign the following values: a = 1, b = 2, c = 3, .... z = 26.
        //For example, for the word "zodiacs", let's cross out the vowels. We get: "z o d ia cs"


        //Tests----------
        //("zodiac", 26)
        //("chruschtschov", 80)
        //("khrushchev", 38)
        //("strength", 57)
        //("catchphrase", 73)
        //("twelfthstreet", 103)
        //("mischtschenkoana", 80)

        static void Main(string[] args)
        {
            var res = Solve("mischtschenkoana");
            Console.Write(res);
            Console.ReadLine();
        }

        public static int Solve(string s)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var alphArray = alphabet.ToCharArray();
            var kvp = new Dictionary<int, char>();
            var calcValues = new List<int>();

            for (int i = 0; i < alphArray.Count(); i++)
            {
                kvp.Add(i + 1, alphArray[i]);
            }

            var splitWord = s.Split('a', 'e', 'i', 'o', 'u').ToList();
            splitWord.ForEach(x =>
            {
                var characters = x.ToList();
                var count = 0;
                characters.ForEach(y =>
                {
                    count += kvp.Where(z => z.Value == y).Select(k => k.Key).First();
                });
                calcValues.Add(count);
            });

            return calcValues.Max();
        }
    }
}
