using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Spring.core;
using Spring.gameLogic;
using Spring.ui;

namespace Spring.screens
{
    public class ActionScreen : GameScreen
    {
        private Room[] _floor;

        private int roomIndex = 0;

        private static bool _playerTurn = true;

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

        public Enemy Enemy
        {
            get
            {
                return _floor[roomIndex].Enemy;
            }
        }


        public CombatInterface ActionInterface;

        public SpellHandler SpellHandler;

        public ActionScreen()
        {
            SpellHandler = new SpellHandler(this);
            _floor = GenerateFloor(3);
        }

        public override void LoadContent()
        {

            // make rooms separately, add Floor class to hold rooms

            
            Game1.Player.LoadContent();

            /*
            Game1.Player.SpellList.AddSpell(new Spell());
            Game1.Player.SpellList.AddSpell(new Spell(15, 2, "The pizza margerita of spells", "Fireball", "fireball_icon", Spell.Effect.Damage));
            Game1.Player.SpellList.AddSpell(new Spell(10, 1, "Restore your health", "Liferose", "liferose_icon", Spell.Effect.Heal));
            Game1.Player.SpellList.AddSpell(new Spell(20, 2, "Protect yourself", "Shield", "shield_icon", Spell.Effect.Shield));
            */

            _floor[roomIndex].LoadContent();

            ActionInterface = new CombatInterface(Enemy, this);
            ActionInterface.LoadContent();

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
            }

            if(Enemy.Health <= 0)
            {
                Console.WriteLine("Give loot and switch to new screen");
                Console.WriteLine("Currently just resets it to full hp");
                Enemy.Health = Enemy.MaxHealth;
            } 

            Game1.Player.Update(gameTime);

            Enemy.Update(gameTime);

            ActionInterface.Update(gameTime);


        }

        public override void Draw(GameTime gameTime)
        {
            _floor[roomIndex].Draw(gameTime);

            Game1.Player.Draw(gameTime);

            ActionInterface.Draw(gameTime);
        }

        private Room[] GenerateFloor(int roomCount)
        {
            var floor = new Room[roomCount];

            for(int i = 0; i < roomCount; i++)
            {
                //add random room generation, possibly make the room generate itself randomly?
                floor[i] = new Room(this);
            }

            return floor;
        }
    }
}
