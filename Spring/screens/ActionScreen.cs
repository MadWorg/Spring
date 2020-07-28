using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Spring.core;
using Spring.ui;

namespace Spring.screens
{
    public class ActionScreen : CustomScreen
    {

        Player player;
        Room room;
        public CombatInterface cInterface;

        public ActionScreen()
        {
            cInterface = new CombatInterface();
            

            // player must be built last
                       
        }

        public override void LoadContent()
        {

            // ugly temporary fix for loading same content twice
            // remove asap and check for loading otherwise, possibly in ScreenManager

            if (Loaded) return;  // loading issue

            cInterface.LoadContent();

            // dont make player and room here, temp fix(?)
            
            room = new Room();
            player = new Player(255, 6);
            player.LoadContent();
            room.LoadContent();

            Loaded = true; // loading issue

        }

        public override void Unload()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            cInterface.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            room.Draw(gameTime);
            player.Draw(gameTime);
            cInterface.Draw(gameTime);
        }


    }
}
