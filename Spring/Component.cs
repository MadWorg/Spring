using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring
{
    public abstract class Component
    {

        public abstract void Draw(GameTime gameTime);

        public abstract void Update(GameTime gameTime);

    }
}
