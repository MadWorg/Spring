using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.screens;
using Spring.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Enemy : Entity
    {

        private Texture2D _sprite;

        private ActionScreen _parent = null;

        public string TextureName { get; set; }

        public Enemy()
        {
            Health = MaxHealth = 200;
            Mana = MaxMana = 7;
            TextureName = "skelly";
            SpellList = new Spellbook();
        }

        public Enemy(ActionScreen parent)
        {
            Health = MaxHealth = 200;
            Mana = MaxMana = 7;
            TextureName = "skelly";
            SpellList = new Spellbook();
            _parent = parent;
        }

        public void LoadContent()
        {
            //_sprite = Game1.GameContent.Load<Texture2D>("entity/" + TextureName);

            //_sprite = Game1.GameContent.Load<Texture2D>("interface/whiteSquare");

            _sprite = Game1.GameContent.Load<Texture2D>("entity/" + TextureName);

        }

        public void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_sprite, new Rectangle(1020, 120, 350, 630), Color.White);
        }

        public void Update(GameTime gameTime)
        {

            CombatInterface.UpdateBar("enemyHealth", _maxHp, _hp);

            CombatInterface.UpdateBar("enemyMana", _maxMana, _mana);



        }

        private void UseTurn(GameTime gameTime)
        {
            var testSpell = new Spell();
            _parent.SpellHandler.CastSpell(testSpell, this);
        }

    }
}
