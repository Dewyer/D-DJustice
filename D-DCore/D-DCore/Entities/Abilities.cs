using System;
using System.Collections.Generic;
using System.Text;

namespace DCore.Entities
{
    public class AbilityResult
    {
        public int Damage { get; set; }
        public int Healing { get; set; }

        //...effects
    }

    interface IAbility
    {
        AbilityResult CastToDamage();
    }

    public class Abilities
    {
        private Dictionary<Type,IAbility> _abilities;

        public Abilities()
        {
            _abilities = new Dictionary<Type, IAbility>();
        }

        public Abilities AddAbility<T>(T ability)
        {
            var body = (IAbility) ability;
            _abilities.Add(typeof(T),body);
            return this;
        }

        public AbilityResult CastAbility<T>()
        {
            if (_abilities.ContainsKey(typeof(T)))
            {
                return _abilities[typeof(T)].CastToDamage();
            }
            return new AbilityResult()
            {
                Damage = 0,
                Healing = 0
            };
        }
    }
}
