using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Room
    {

        private Texture2D _background;

        public string TextureName { get; set; }

        public Enemy Enemy { get; set; }

        public Room(string texture, Enemy enemy)
        {
            TextureName = texture;
            Enemy = enemy;
        }

        public Room()
        {
            TextureName = "testRoom";
            Enemy = new Enemy();
        }

        public void LoadContent()
        {
            _background = Game1.GameContent.Load<Texture2D>("background/" + TextureName);
            Enemy.LoadContent();
        }

        public void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_background, new Rectangle(0,0, 1600, 900), Color.White);
            Enemy.Draw(gameTime);
        }


 
    }
}
