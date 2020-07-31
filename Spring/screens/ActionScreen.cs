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

        private Room _room;

        private bool _test = false;

        public Enemy Enemy
        {
            get
            {
                return _room.Enemy;
            }
        }


        public CombatInterface ActionInterface;

        public SpellHandler SpellHandler;

        private MouseState _previousState, _currentState;

        public ActionScreen()
        {
            SpellHandler = new SpellHandler(this);
        }

        public override void LoadContent()
        {

            // dont make player and room here, temp fix(?)

            _room = new Room();
            Game1.Player.LoadContent();

            Game1.Player.SpellList.AddSpell(new Spell());
            Game1.Player.SpellList.AddSpell(new Spell(15, 2, "The pizza margerita of spells", "Fireball", "fireball_icon", Spell.Effect.Damage));
            Game1.Player.SpellList.AddSpell(new Spell(10, 1, "Restore your health", "Liferose", "liferose_icon", Spell.Effect.Heal));
            Game1.Player.SpellList.AddSpell(new Spell(20, 2, "Protect yourself", "Shield", "shield_icon", Spell.Effect.Shield));
            
            _room.LoadContent();

            ActionInterface = new CombatInterface(Enemy);
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

            Game1.Player.Update(gameTime);


            ActionInterface.Update(gameTime);




            // replace code below 

            _previousState = _currentState;
            _currentState = Mouse.GetState();

            #region Testing area 
            if (_currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed)
            {
                Game1.Player.Health -= 5;
                Game1.Player.Mana -= 1;

                _room.Enemy.Health -= 5;
                _room.Enemy.Mana -= 1;
            }

            if(Game1.Player.Health == 10)
            {
                Game1.Player.SpellList.RemoveSpell(0);
                Game1.Player.SpellList.RemoveSpell(2);
            }

            if(Game1.Player.Health == 5)
            {
                if(!_test)
                {
                    Game1.Player.SpellList.AddSpell(new Spell());
                    _test = true;
                }
                
            }
            #endregion

        }

        public override void Draw(GameTime gameTime)
        {
            _room.Draw(gameTime);
            Game1.Player.Draw(gameTime);
            ActionInterface.Draw(gameTime);
        }


    }
}
