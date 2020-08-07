using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.screens;
using Spring.ui;

namespace Spring.core
{
    public class Enemy : Entity
    {

        private Texture2D _sprite;

        public ActionScreen Parent = null;

        public string TextureName { get; set; }

        public Enemy()
        {
            Health = MaxHealth = 50;
            Mana = MaxMana = 3;
            TextureName = "skelly";
            SpellList = new Spellbook();
        }

        public Enemy(ActionScreen parent)
        {
            Health = MaxHealth = 50;
            Mana = MaxMana = 3;
            TextureName = "skelly";
            SpellList = new Spellbook();
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

            if(!ActionScreen.PlayerTurn)
            {
                UseTurn(gameTime);
            }



        }

        private void UseTurn(GameTime gameTime)
        {
            Mana = MaxMana; // resets properly, too fast to notice by eye

            ActionScreen.SpellHandler.CastSpell(new Spell(), this);

            ActionScreen.PlayerTurn = true;

            Game1.Player.Mana = Game1.Player.MaxMana;
        }

    }
}
