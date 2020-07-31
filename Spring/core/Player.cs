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
        private Texture2D _sprite;

        #region Properties

        #endregion

        #region Methods

        public Player()
        {
            Health = MaxHealth = 25;
            Mana = MaxMana = 3;
            SpellList = new Spellbook();
        }

        public void LoadContent()
        {
            //_sprite = Game1.GameContent.Load<Texture2D>("interface/whiteSquare");
            _sprite = Game1.GameContent.Load<Texture2D>("entity/player");
        }

        public void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_sprite, new Rectangle(230, 120, 350, 630), Color.White);
        }

        public void Update(GameTime gameTime)
        {

            CombatInterface.UpdateBar("playerHealth", _maxHp, _hp);

            CombatInterface.UpdateBar("playerMana", _maxMana, _mana);

        }

        #endregion


    }
}
