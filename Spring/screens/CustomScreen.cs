using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.screens
{
    public abstract class CustomScreen
    {

        public bool Loaded = false;

        public abstract void LoadContent();

        public abstract void Unload();

        public abstract void Draw(GameTime gameTime);

        public abstract void Update(GameTime gameTime);

    }
}
