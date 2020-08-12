using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Player : Entity
    {

        #region Fields

        private Texture2D _headSprite;
        private Texture2D _bodySprite;
        private Texture2D _handSprite;

        #endregion

        #region Properties

        public Color Color { get; set; }

        #endregion

        #region Methods

        public Player()
        {
            Health = MaxHealth = 100;
            Mana = MaxMana = 3;
            SpellList = new Spellbook();
            Color = Color.Purple;

            SpellList.AddSpell(new Spell());
            SpellList.AddSpell(new Spell(150, 2, "The pizza margerita of spells", "Fireball", "fireball_icon", Spell.Effect.Damage));
            SpellList.AddSpell(new Spell(15, 1, "Restore your health", "Liferose", "liferose_icon", Spell.Effect.Heal));
            SpellList.AddSpell(new Spell(20, 2, "Protect yourself", "Shield", "shield_icon", Spell.Effect.Shield));

        }

        public override void LoadContent()
        {
            _headSprite = Game1.GameContent.Load<Texture2D>("entity/player1");
            _bodySprite = Game1.GameContent.Load<Texture2D>("entity/player2");
            _handSprite = Game1.GameContent.Load<Texture2D>("entity/player3");
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_headSprite, new Rectangle(230, 120, 350, 630), Color.White);
            Game1.SpriteBatch.Draw(_bodySprite, new Rectangle(230, 120, 350, 630), Color);
            Game1.SpriteBatch.Draw(_handSprite, new Rectangle(230, 120, 350, 630), Color.White);
        }

        public void Draw(GameTime gameTime, Vector2 pos)
        {
            Game1.SpriteBatch.Draw(_headSprite, new Rectangle((int)pos.X, (int)pos.Y, 350, 630), Color.White);
            Game1.SpriteBatch.Draw(_bodySprite, new Rectangle((int)pos.X, (int)pos.Y, 350, 630), Color);
            Game1.SpriteBatch.Draw(_handSprite, new Rectangle((int)pos.X, (int)pos.Y, 350, 630), Color.White);
        }

        public override void Update(GameTime gameTime)
        {

            CombatInterface.UpdateBar("playerHealth", _maxHp, _hp);

            CombatInterface.UpdateBar("playerMana", _maxMana, _mana);

        }

        #endregion


    }
}
