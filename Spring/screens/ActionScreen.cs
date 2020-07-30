using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Spring.core;
using Spring.ui;

namespace Spring.screens
{
    public class ActionScreen : GameScreen
    {
        Room room;

        public CombatInterface ActionInterface;

        private MouseState _previousState, _currentState;

        public ActionScreen()
        {
                       
        }

        public override void LoadContent()
        {

            ActionInterface = new CombatInterface();

            ActionInterface.LoadContent();

            Game1.GameState = Game1.State.Playing;

            // dont make player and room here, temp fix(?)

            room = new Room();
            Game1.Player.LoadContent();

            Game1.Player.Spells.AddSpell(new Spell());
            Game1.Player.Spells.AddSpell(new Spell(15, 2, "The pizza margerita of spells", "Fireball", "fireball_icon", Spell.Effect.Damage));
            Game1.Player.Spells.AddSpell(new Spell(10, 1, "Restore your health", "Liferose", "liferose_icon", Spell.Effect.Heal));
            Game1.Player.Spells.AddSpell(new Spell(20, 2, "Protect yourself", "Shield", "shield_icon", Spell.Effect.Shield));
            /*
            Game1.Player.Spells.AddSpell(Spelllist.Fireball);
            Game1.Player.Spells.AddSpell(Spelllist.Liferose);
            Game1.Player.Spells.AddSpell(Spelllist.Shield);
            */
            room.LoadContent();


            // switch game state
            

        }

        public override void Unload()
        {
            ActionInterface = null;
            Game1.GameContent.Unload();
        }

        public override void Update(GameTime gameTime)
        {

            if (Game1.Player.Health <= 0)
            {
                ScreenManager.Instance.SwitchScreen("GameOverScreen");
                Game1.Player = new Player(); // resets player to default test value, replace later
            }


            ActionInterface.Update(gameTime);

            _previousState = _currentState;

            _currentState = Mouse.GetState();

            #region Testing area 
            if (_currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed)
            {
                Game1.Player.Health -= 5;
                Game1.Player.Mana -= 1;

                room.Enemy.Health -= 5;
                room.Enemy.Mana -= 1;
            }

            if(Game1.Player.Health == 10)
            {
                Game1.Player.Spells.RemoveSpell(0);
                Game1.Player.Spells.RemoveSpell(2);
            }
            #endregion

        }

        public override void Draw(GameTime gameTime)
        {
            room.Draw(gameTime);
            Game1.Player.Draw(gameTime);
            ActionInterface.Draw(gameTime);
        }


    }
}
