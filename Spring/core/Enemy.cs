﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Enemy
    {

        private int _hp;
        private int _maxHp;
        private int _mana;
        private int _maxMana;

        public int Health
        {
            get { return _hp; }

            set
            {
                _hp = value;
                UpdateUI("enemyHealth", "hp");
            }
        }

        public int MaxHealth
        {
            get { return _maxHp; }

            set
            {
                _maxHp = value;
                UpdateUI("enemyHealth", "hp");
            }
        }

        public int Mana
        {
            get { return _mana; }

            set
            {
                _mana = value;
                UpdateUI("enemyMana", "mana");
            }
        }

        public int MaxMana
        {
            get { return _maxMana; }

            set
            {
                _maxMana = value;
                UpdateUI("enemyMana", "mana");
            }
        }

        private Texture2D _sprite;

        public string TextureName { get; set; }

        public Enemy()
        {
            Health = MaxHealth = 100;
            Mana = MaxMana = 3;
            TextureName = "darkOrc";
        }

        public void LoadContent()
        {
            //_sprite = Game1.GameContent.Load<Texture2D>("entity/" + TextureName);
            _sprite = Game1.GameContent.Load<Texture2D>("interface/whiteSquare");
        }

        public void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_sprite, new Rectangle(1020, 120, 350, 630), Color.Magenta);
        }

        public void UpdateUI(string label, string barType)
        {
            if(barType == "hp")
            {
                CombatInterface.UpdateBar(label, _maxHp, _hp);
            }
            else if(barType == "mana")
            {
                CombatInterface.UpdateBar(label, _maxMana, _mana);
            }
        }
    }
}
