using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class SpellDrawer
    {

        private ParticleEngine _particleEngine;

        private Spell _currentSpell;

        public SpellDrawer()
        {
            
        }

        public void LoadContent()
        {
            List<Texture2D> textures = new List<Texture2D>();

            textures.Add(Game1.GameContent.Load<Texture2D>("particles/particle_cross1"));
            textures.Add(Game1.GameContent.Load<Texture2D>("particles/particle_cross2"));
            textures.Add(Game1.GameContent.Load<Texture2D>("particles/particle_cross3"));

            _particleEngine = new ParticleEngine(textures, new Vector2(800, 450));

        }

        public void Update(GameTime gameTime)
        {
            _particleEngine.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _particleEngine.Draw(gameTime);
        }

    }
}
