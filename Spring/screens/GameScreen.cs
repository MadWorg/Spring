using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.screens
{
    public abstract class GameScreen
    {

        public abstract void LoadContent();

        public abstract void Unload();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);

    }
}
