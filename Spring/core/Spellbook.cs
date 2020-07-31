using Spring.ui;
using System.Collections.Generic;

namespace Spring.core
{
    public class Spellbook
    {

        private int _spellCount;

        private static Spell[] _spells;

        public Spell[] GetSpells
        {
            get
            {
                return _spells;
            }
        }

        public Spellbook()
        {

            _spellCount = 0;
            _spells = new Spell[4];

        }

        public Spellbook(Spell[] spells, int count)
        {
            _spellCount = count;
            _spells = spells;

        }

        private void UpdateUI()
        {

            if (Game1.GameState != Game1.State.Playing)
            {
                return;
            }

            CombatInterface.UpdateSpell(_spells);
        }

        public void AddSpell(Spell spell)
        {
            if(_spellCount < 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if(_spells[i] == null)
                    {
                        _spells[i] = spell;
                        _spellCount++;
                        UpdateUI();
                        return;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Spellbook full, could not save spell");
            }
        }

        public void ReplaceSpell(Spell spell, int index)
        {
            _spells[index] = spell;
            UpdateUI();
        }

        public void RemoveSpell(int index)
        {
            _spells[index] = null;
            _spellCount--;
            UpdateUI();
        }

    }
}
