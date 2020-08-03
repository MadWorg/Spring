using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Spring.core;
using Spring.screens;

namespace Spring.gameLogic
{
    public class SpellHandler
    {

        // potentially make this class static?

        private ActionScreen _parent;

        public SpellHandler(ActionScreen parent)
        {
            _parent = parent;
        }

        public void CastSpell(Spell spell, Entity caster)
        {

            if (caster.Mana < spell.Cost)
            {
                return;
            }

            if(spell.EffectType == Spell.Effect.Damage)
            {
                if(caster is Player)
                {
                    _parent.Enemy.Health -= spell.Value;
                }
                else
                {
                    Game1.Player.Health -= spell.Value;
                }
                

            }
            else if(spell.EffectType == Spell.Effect.Heal)
            {

                var newHp = caster.Health + spell.Value;

                if ( newHp >= caster.MaxHealth)
                {
                    caster.Health = caster.MaxHealth;
                }
                else
                {
                    caster.Health = newHp;
                }

            }
            else
            {
                return;
            }

            caster.Mana -= spell.Cost;

        }

    }
}
