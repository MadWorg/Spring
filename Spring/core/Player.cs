using Spring.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Player
    {

        private int _hp;
        private int _maxHp;
        private int _mana;
        private int _maxMana;

        public int Health
        {
            get { return _hp; }

            set
            {
                _hp = value;
                UpdateUI("playerHealth", "hp");
            }
        }

        public int MaxHealth
        {
            get { return _maxHp; }

            set
            {
                _maxHp = value;
                UpdateUI("playerHealth", "hp");
            }
        }

        public int Mana
        {
            get { return _mana; }

            set
            {
                _mana = value;
                UpdateUI("playerMana", "mana");
            }
        }

        public int MaxMana
        {
            get { return _maxMana; }

            set
            {
                _maxMana = value;
                UpdateUI("playerMana", "mana");
            }
        }

        public Player(int hp, int mana)
        {
            Health = MaxHealth = hp;
            Mana = MaxMana = mana;
        }

        public void UpdateUI(string label, string barType)
        {
            if(barType == "hp")
            {
                CombatInterface.UpdateBar(label, _maxHp, _hp);
            }
            else if(barType == "mana")
            {
                CombatInterface.UpdateBar(label, _maxMana, _mana);
            }

            // might add xp bar
        }


    }
}
