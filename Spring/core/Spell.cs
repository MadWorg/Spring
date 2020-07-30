﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Spell
    {      
    
        public string Name { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

        public int Cost { get; set; }

        public Texture2D Icon { get; set; }

        public int Index { get; set; }

        public Spell()
        {
            Value = 5;  // spells that deal damage will have negative numbers or maybe not
            Cost = 1;
            Description = "This is a test spell";
            Name = "TestSpell";
            Icon = Game1.GameContent.Load<Texture2D>("spells/spell_test");
            Index = 0;
        }

        public Spell(string spell_icon)
        {
            Value = 5;  // spells that deal damage will have negative numbers or maybe not
            Cost = 1;
            Description = "This is a test spell";
            Name = "TestSpell";
            Icon = Game1.GameContent.Load<Texture2D>("spells/" + spell_icon);
            Index = 0;
        }

    }
}