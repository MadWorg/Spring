using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.core;
using Spring.screens;
using Spring.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.enemies
{
    class Ghost : Entity
    {

        public Ghost()
        {
            Health = MaxHealth = 75;
            Mana = MaxMana = 3;
        }

        public override void LoadContent()
        {
            _sprite = new AnimatedSprite(Game1.GameContent.Load<Texture2D>("entity/ghost"), 1, 64, 80)
            {
                Position = new Vector2(1020, 120),
                Scale = 6f,
                MaxFrame = 7
            };
        }

        public override void Draw(GameTime gameTime)
        {
            _sprite.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (Health > 0)
            {
                _sprite.Update(gameTime);

                CombatInterface.UpdateBar("enemyHealth", _maxHp, _hp);

                CombatInterface.UpdateBar("enemyMana", _maxMana, _mana);

                if (!ActionScreen.PlayerTurn)
                {
                    UseTurn(gameTime);
                }
            }



        }

        private void UseTurn(GameTime gameTime)
        {
            Mana = MaxMana; // resets properly, too fast to notice by eye

            var stealHP = new Spell(12, 3, "Lifesteal", Spell.Effect.Damage);
            var heal = new Spell(12, 0, "HealFromEnemy", Spell.Effect.Heal);

            ActionScreen.SpellHandler.CastSpell(stealHP, this);
            ActionScreen.SpellHandler.CastSpell(heal, this);

            ActionScreen.PlayerTurn = true;

            Game1.Player.Mana = Game1.Player.MaxMana;
        }

    }
}
