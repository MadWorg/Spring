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
    class Skull : Entity
    {

        public Skull()
        {
            Health = MaxHealth = 50;
            Mana = MaxMana = 3;
        }

        public override void LoadContent()
        {
            _sprite = new AnimatedSprite(Game1.GameContent.Load<Texture2D>("entity/skull"), 1, 96, 112)
            {
                Position = new Vector2(1020, 120),
                Scale = 2f,
                MaxFrame = 8
            };
        }

        public override void Draw(GameTime gameTime)
        {
            _sprite.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if(Health > 0)
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

            ActionScreen.SpellHandler.CastSpell(new Spell(10, 3, "Blast", Spell.Effect.Damage), this);

            ActionScreen.PlayerTurn = true;

            Game1.Player.Mana = Game1.Player.MaxMana;
        }

    }
}
