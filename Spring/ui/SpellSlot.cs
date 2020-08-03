using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spring.core;
using Spring.screens;

namespace Spring.ui
{
    class Spellslot : Component
    {

        #region Fields

        public string Label;

        public int Index;

        private Texture2D _icon;

        private Texture2D _border;

        private MouseState _previousState, _currentState;

        private bool _hovering;

        #endregion

        #region Properties

        public Vector2 Position { get; set; }

        public Color Tint { get; set; }

        public int SpellIndex { get; set; }

        public Spell Spell { get; set; } // edit this to load spell icon

        public ActionScreen Parent { get; set; }

        //public Spell Spell { get; set; }    // uncomment when spells are done

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 120, 120);
            }
        }

        #endregion

        #region Methods

        public Spellslot(int index)
        {
            Index = index;
            Tint = Color.White;
            _icon = Game1.GameContent.Load<Texture2D>("spells/spell_blank");
            _border = Game1.GameContent.Load<Texture2D>("spells/spell_border");
        }

        public Spellslot(string label, int index)
        {
            Label = label;
            Index = index;
            Tint = Color.White;
            _icon = Game1.GameContent.Load<Texture2D>("spells/spell_blank");
            _border = Game1.GameContent.Load<Texture2D>("spells/spell_border");
        }

        public override void Draw(GameTime gameTime)
        {

            Tint = Color.White;

            // add spell availability logic -> color red if you cant cast it etc
            // add icon replacing

            if(_hovering)
            {
                Tint = Color.LightSkyBlue;
            }

            if(Spell == null)
            {
                Game1.SpriteBatch.Draw(_icon, Rectangle, Tint);
                Game1.SpriteBatch.Draw(_border, Rectangle, Color.White);
            }
            else
            {

                if(Spell.Cost > Game1.Player.Mana)
                {
                    Tint = Color.Red;
                }

                Game1.SpriteBatch.Draw(Spell.Icon, Rectangle, Tint);
                Game1.SpriteBatch.Draw(_border, Rectangle, Color.White);
            }

            

        }

        public override void Update(GameTime gameTime)
        {

            _previousState = _currentState;
            _currentState = Mouse.GetState();

            var mouseRectanlge = new Rectangle(_currentState.X, _currentState.Y, 1, 1);

            _hovering = false;

            if(mouseRectanlge.Intersects(Rectangle))
            {
                _hovering = true;

                if(_currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed)
                {
                    Parent.SpellHandler.CastSpell(Spell, Game1.Player);
                }

            }

        }

        #endregion
    }
}
