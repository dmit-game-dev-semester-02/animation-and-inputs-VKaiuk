using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01_animation_input;

public class CelAnimationPlayer
{
    private CelAnimationSequence celAnimationSequence;
    private int celIndex;
    private float celTimeElapsed;
    private Rectangle celSourceRectangle;

    public void Play(CelAnimationSequence celAnimationSequence, int row = 1)
    {
        if (celAnimationSequence == null)
        {
            throw new Exception("CelAnimationPlayer.PlayAnimation received null CelAnimationSequence");
        }
        if (celAnimationSequence != this.celAnimationSequence || celSourceRectangle.Y != row * celAnimationSequence.CelHeight)
        {
            this.celAnimationSequence = celAnimationSequence;
            celIndex = 0;
            celTimeElapsed = 0.0f;

            celSourceRectangle.X = 0;
            celSourceRectangle.Y = row * celAnimationSequence.CelHeight;
            celSourceRectangle.Width = this.celAnimationSequence.CelWidth;
            celSourceRectangle.Height = this.celAnimationSequence.CelHeight;
        }
    }
    public void Update(GameTime gameTime)
    {
        if (celAnimationSequence != null)
        {
            celTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (celTimeElapsed >= celAnimationSequence.CelTime)
            {
                celTimeElapsed -= celAnimationSequence.CelTime;
                celIndex = (celIndex + 1) % celAnimationSequence.CelCount;

                celSourceRectangle.X = celIndex * celSourceRectangle.Width;
            }
        }
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects, Vector2 scale)
    {
        if (celAnimationSequence != null)
        {
            spriteBatch.Draw(celAnimationSequence.Texture, position, celSourceRectangle, Color.White, 0.0f, Vector2.Zero, scale, spriteEffects, 0.0f);
        }
    }
    
}

