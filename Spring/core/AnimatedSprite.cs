using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spring.core
{
    public class AnimatedSprite
    {

        #region Fields

        Texture2D spriteTexture;
        float timer = 0f; // for delaying animation
        float interval = 120f; // time step
        int currentFrame = 0;
        int spriteWidth = 32;
        int spriteHeight = 32;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        #endregion

        #region Properties

        public int MaxFrame { get; set; }

        public float Scale { get; set; }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        #endregion

        public AnimatedSprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            spriteTexture = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            Scale = 1f;
        }

        public void Update(GameTime gameTime) // animates the sprite
        {

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame >= MaxFrame)
                {
                    currentFrame = 1;
                }

                timer = 0f;
            }
        }

        public void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
