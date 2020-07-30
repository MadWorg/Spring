using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Spring.core;

namespace Spring.gameLogic
{
    public static class SpellHandler
    {
        
        // finish this

        public static void CastSpell(Spell spell, Entity target)
        {
            if(spell.EffectType == Spell.Effect.Damage)
            {

                target.Health -= spell.Value;

            }
            else if(spell.EffectType == Spell.Effect.Heal)
            {

                var newHp = target.Health + spell.Value;

                if ( newHp >= target.MaxHealth)
                {

                    target.Health = target.MaxHealth;

                }
                else
                {

                    target.Health = newHp;

                }

            }
            else
            {
                return;
            }
        }

    }
}
