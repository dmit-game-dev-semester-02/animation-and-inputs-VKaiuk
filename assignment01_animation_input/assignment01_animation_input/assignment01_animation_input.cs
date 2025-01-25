using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01_animation_input;

public class Input_AnimationGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background, _foreground;
    private CelAnimationPlayer _animationPlayer, _animationSpider;
    private CelAnimationSequence _personWalking, _spiderWalking;
    private Vector2 _spritePosition, _spiderPosition;

    private const int _WindowWidth = 634;
    private const int _WindowHeight = 360;
    public Input_AnimationGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        _graphics.ApplyChanges();

        _spritePosition = new Vector2(0,182);
        _spiderPosition = new Vector2(500, 230);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _background = Content.Load<Texture2D>("background-forest");
        _foreground = Content.Load<Texture2D>("treeOrange");
        Texture2D _spriteSheet = Content.Load<Texture2D>("mario");
        Texture2D _spiderSheet = Content.Load<Texture2D>("spider01");
        

        _personWalking = new CelAnimationSequence(_spriteSheet, 64, 64, 1 / 6f);
        _spiderWalking = new CelAnimationSequence(_spiderSheet, 64, 64, 1 / 6f);

        _animationPlayer = new CelAnimationPlayer();
        _animationPlayer.Play(_personWalking, 2);

        _animationSpider = new CelAnimationPlayer();
        _animationSpider.Play(_spiderWalking, 1);
        
    }

    protected override void Update(GameTime gameTime)
    {

        // TODO: Add your update logic here

        base.Update(gameTime);

        KeyboardState keyboardState = Keyboard.GetState();

        if(keyboardState.IsKeyDown(Keys.A))
        {
            _spritePosition.X -= 3;

            _animationPlayer.Play(_personWalking, 1);
            _animationPlayer.Update(gameTime);
        }
        else if(keyboardState.IsKeyDown(Keys.D))
        {
            _spritePosition.X += 3;
            
            _animationPlayer.Play(_personWalking, 2);
            _animationPlayer.Update(gameTime);
        }

        if(keyboardState.IsKeyDown(Keys.Left))
        {
            _spiderPosition.X -= 3;

            _animationSpider.Play(_spiderWalking, 1);
            _animationSpider.Update(gameTime);
        }
        else if(keyboardState.IsKeyDown(Keys.Right))
        {
            _spiderPosition.X += 3;
            
            _animationSpider.Play(_spiderWalking, 3);
            _animationSpider.Update(gameTime);
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_foreground, new Vector2(0.5f, 0.5f), null, Color.White, 0f, Vector2.Zero, new Vector2(330, 10), SpriteEffects.None, 0f);
   
        _animationPlayer.Draw(_spriteBatch, _spritePosition, SpriteEffects.None, new Vector2(2.0f, 2.0f));

        _animationSpider.Draw(_spriteBatch, _spiderPosition, SpriteEffects.None, new Vector2(2.0f, 2.0f));
        

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
