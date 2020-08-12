using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public abstract class Entity
    {

        // Fields

        protected int _hp;

        protected int _maxHp;

        protected int _mana;

        protected int _maxMana;

        protected AnimatedSprite _sprite;

        protected Texture2D _staticSprite;

        public Spellbook SpellList;


        // Properties

        public int Health
        {
            get
            {
                return _hp;
            }

            set
            {
                _hp = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return _maxHp;
            }

            set
            {
                _maxHp = value;
            }
        }

        public int Mana
        {
            get
            {
                return _mana;
            }

            set
            {
                _mana = value;
            }
        }

        public int MaxMana
        {
            get
            {
                return _maxMana;
            }

            set
            {
                _maxMana = value;
            }
        }

        // Methods

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);


    }
}
