using System;
using System.Collections.Generic;
using DCore.Entities;
using DCore.Controllers;

namespace D_DConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stat = new Stats(new List<int>(){10,10,10,10,10,10},new Combatant() );
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine("{0} -> {1}",i,stat.getModifier(i));
            }
        }
    }
}
