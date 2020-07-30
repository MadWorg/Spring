using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public abstract class Entity
    {

        // Fields

        protected int _hp;

        protected int _maxHp;

        protected int _mana;

        protected int _maxMana;

        public Spellbook Spells;


        // Properties

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int Mana { get; set; }

        public int MaxMana { get; set; }

    }
}
