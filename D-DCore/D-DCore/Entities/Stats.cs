using System;
using System.Collections.Generic;
using System.Text;

namespace DCore.Entities
{
    public enum StatName
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public class Stats
    {
        private Dictionary<StatName,int> _stats;
        private Dictionary<StatName, int> _mods;
        private Combatant _owner;


        public Stats(List<int> startStats,Combatant combatant)
        {
            _owner = combatant;
            _stats = new Dictionary<StatName, int>();
            _mods = new Dictionary<StatName, int>();

            if (startStats.Count != 6)
            {
                throw  new Exception("Invalid stats given for stats.");
            }
            foreach (StatName stat in Enum.GetValues(typeof(StatName)))
            {
                var val = startStats[(int) stat];
                if (val < 0)
                {
                    val = 0;
                }
                _stats.Add(stat, val);
            }
            
            setMods();
        }

        public int getProf(int level)
        {
            var gl = level - 1;
            var profs = (gl-(gl%4))/4 +2;
            return profs;
        }

        public void setMods()
        {
            _mods.Clear();
            foreach (var stat in _stats)
            {
                _mods.Add(stat.Key,getModifier(stat.Value));
            }
        }

        public int getModifier(int val)
        {
            var closest = val - (val % 2);
            return ((closest / 2) - 5);
        }

        public int ThrowFor(StatName stat,RollState rollState = RollState.Normal)
        {
            var ll = _mods[stat]+getProf(_owner.Level);

            var offset = ll >= 0 ? "+"+ll.ToString()  :ll.ToString();
            var roll = Dice.RollDice($"1d20{offset}");

            if (rollState == RollState.Normal)
            {
                return roll;
            }
            else if (rollState == RollState.Advantage)
            {
                var second = Dice.RollDice($"1d20{offset}");
                return Math.Max(roll, second);
            }
            else
            {
                var second = Dice.RollDice($"1d20{offset}");
                return Math.Min(roll, second);
            }
        }

    }
}
