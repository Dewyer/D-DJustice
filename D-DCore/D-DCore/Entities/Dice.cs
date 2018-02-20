using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DCore.Entities
{

    public enum RollState
    {
        Advantage,
        Disadvantage,
        Normal
    }

    public static class Dice
    {
        public static Random Rng = new Random();

        public static int RollDice(string diceS)
        {
            try
            {
                var newS = Regex.Replace(diceS, @"\s+", "");
                var tokens = newS.Split('d');
                var timeser = int.Parse(tokens[0]);

                var second = tokens[1].Split('+');
                var dice = int.Parse(second[0]);
                var offset = 0;
                if (second.Length == 2)
                {
                    offset = int.Parse(second[1]);
                }

                var sum = 0;
                for (int ii = 0; ii < timeser; ii++)
                {
                    sum += Rng.Next(1, dice + 1);
                }
                sum += offset;
                return sum;
            }
            catch (Exception e)
            {
                throw new Exception($"Wrong dice string provided .. {diceS} is invalid");
            }
        }

    }
}
