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
    class Demon : Entity
    {

        public Demon()
        {
            Health = MaxHealth = 250;
            Mana = MaxMana = 7;
        }

        public override void LoadContent()
        {
            _sprite = new AnimatedSprite(Game1.GameContent.Load<Texture2D>("entity/demon"), 1, 160, 144)
            {
                Position = new Vector2(980, 120),
                Scale = 4f,
                MaxFrame = 6
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
            Mana = MaxMana; // resets properly but too fast to notice by eye

            var cleave = new Spell(15, 3, "Cleave", Spell.Effect.Damage);

            ActionScreen.SpellHandler.CastSpell(cleave, this);

            if(Health <= 50)
            {
                ActionScreen.SpellHandler.CastSpell(new Spell(10, 2, "Unholy reconstruction", Spell.Effect.Heal), this);
            }
            else
            {
                ActionScreen.SpellHandler.CastSpell(cleave, this);
            }

            ActionScreen.PlayerTurn = true;

            Game1.Player.Mana = Game1.Player.MaxMana;
        }
    }
}
