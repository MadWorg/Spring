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

        public Spellbook SpellList;


        // Properties

        public int Health
        {
            get
            {
                return _hp;
            }

            set
            {
                _hp = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return _maxHp;
            }

            set
            {
                _maxHp = value;
            }
        }

        public int Mana
        {
            get
            {
                return _mana;
            }

            set
            {
                _mana = value;
            }
        }

        public int MaxMana
        {
            get
            {
                return _maxMana;
            }

            set
            {
                _maxMana = value;
            }
        }

    }
}
