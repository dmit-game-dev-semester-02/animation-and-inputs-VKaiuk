using System;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01_animation_input;
    
/// <summary>
/// Represents a cel animated texture.
/// in other words, represetns a spritesheet
/// </summary>
public class CelAnimationSequence
{
    // The texture containing the animation sequence...
    protected Texture2D texture;

    // The length of time a cel is displayed...
    protected float celTime;

    // Sequence metrics
    protected int celWidth;
    protected int celHeight;

    protected int celCount;
       
    public CelAnimationSequence(Texture2D texture, int celWidth, int celHeight, float celTime)
    {
        this.texture = texture;
        this.celWidth = celWidth;
        this.celTime = celTime;
        this.celHeight = celHeight;

        celCount = texture.Width / celWidth;
    }

    public Texture2D Texture
    {
        get { return texture; }
    }

    public float CelTime
    {
        get { return celTime; }
    }

    public int CelCount
    {
        get { return celCount; }
    }

    public int CelWidth
    {
        get { return celWidth; }
    }

    public int CelHeight
    {
        get { return celHeight; }
    }
}
