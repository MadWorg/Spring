using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spring.core;
using Spring.enemies;
using Spring.gameLogic;
using Spring.ui;

namespace Spring.screens
{
    public class ActionScreen : GameScreen
    {
        private Room[] _floor;

        private int roomIndex = 0;

        private static bool _playerTurn = true;

        private static bool _newGame = true;

        public static bool PlayerTurn
        {
            get
            {
                return _playerTurn;
            }

            set
            {
                _playerTurn = value;
            }

        }

        public Entity Enemy
        {
            get
            {
                return _floor[roomIndex].Enemy;
            }
        }


        public CombatInterface ActionInterface;

        public static SpellHandler SpellHandler;

        public ActionScreen()
        {
            SpellHandler = new SpellHandler(this);
            GenerateFloor(3);
        }

        public override void LoadContent()
        {

            // make rooms separately, add Floor class to hold rooms

            Game1.Player.LoadContent();

            if (_newGame)
            {               

                GenerateFloor(3);

                foreach (Room room in _floor)
                {
                    room.LoadContent();
                }

                _newGame = false;
            }           

            ActionInterface = new CombatInterface(Enemy, this);
            ActionInterface.LoadContent();

            //SpellHandler.LoadContent();

            // switch game state
            Game1.GameState = Game1.State.Playing;

        }

        public override void Unload()
        {
            ActionInterface = null;
            // give player info back to game1
            Game1.GameContent.Unload();
        }

        public override void Update(GameTime gameTime)
        {

            if (Game1.Player.Health <= 0)
            {
                ScreenManager.Instance.SwitchScreen("GameOverScreen");
                Game1.Player = new Player(); // resets player to default test value, replace later
                Game1.Player.LoadContent();
                _newGame = true;
            }

            if(Enemy.Health <= 0)
            {
                Enemy.Health = Enemy.MaxHealth;

                if(roomIndex < _floor.Length-1)
                {
                    roomIndex++;
                }
                else
                {
                    ScreenManager.Instance.SwitchScreen("GameWinScreen");
                    _newGame = true;
                    roomIndex = 0;
                    Game1.Player = new Player();
                }

                

            } 

            Game1.Player.Update(gameTime);

            Enemy.Update(gameTime);

            //remove this after testing
            //SpellHandler.Update(gameTime);

            ActionInterface.Update(gameTime);


        }

        public override void Draw(GameTime gameTime)
        {

            

            _floor[roomIndex].Draw(gameTime);

            Game1.Player.Draw(gameTime);

            // remove this after testing
            //SpellHandler.Draw(gameTime);

            ActionInterface.Draw(gameTime);

        }

        private void GenerateFloor(int roomCount)
        {
            var floor = new Room[roomCount];

            for(int i = 0; i < roomCount; i++)
            {
                //add random room generation, possibly make the room generate itself randomly?
                floor[i] = new Room(this);
            }

            _floor = floor;
        }
    }
}
