using System;
using System.Collections.Generic;
using System.Text;
using DCore.Controllers;

namespace DCore.Entities
{
    public enum LiveState
    {
        Living,
        Dead,
        Unconscious
    }

    public class Combatant
    {
        public string Name { get; set; }
        public string ID => CreatureId.IdFromName(Name);
        public Stats Stats { get; set; }

        public int HitPoints { get; set; }
        public int DeathThreshold { get; set; }

        public int Level { get; set; }
        public int Exp{ get; set; }

        public LiveState LiveState
        {
            get
            {
                if (HitPoints >= 0)
                {
                    return LiveState.Living;
                }
                else if (HitPoints >= DeathThreshold)
                {
                    return LiveState.Unconscious;
                }
                else
                {
                    return LiveState.Dead;
                }
            }
        }

        public Abilities Abilities { get; set; }

        public Combatant()
        {
            Abilities = new Abilities();
        }

        public Combatant GiveStats(List<int> stats)
        {
            Stats = new Stats(stats,this);
            return this;
        }
        
    }
}
