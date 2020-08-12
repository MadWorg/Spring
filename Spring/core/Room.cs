using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.enemies;
using Spring.screens;
using System;

namespace Spring.core
{
    public class Room
    {

        private Texture2D _background;

        public string TextureName { get; set; }

        public Entity Enemy { get; set; }

        private ActionScreen Parent { get; set; }

        public Room(ActionScreen parent)
        {

            int room = Game1.Random.Next(1,6);

            TextureName = "room" + room;

            string[] monsters = {"Demon", "Ghost", "Skull" };
            Enemy = (Entity)Activator.CreateInstance(Type.GetType("Spring.enemies." + monsters[Game1.Random.Next(0, monsters.Length)]));

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
