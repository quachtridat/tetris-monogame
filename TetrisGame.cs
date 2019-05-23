using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleTetris.Core2.Delegates;
using SimpleTetris.Core2.Graphics;
using SimpleTetris.Core2.TetrisComponents;
using SimpleTetris.Core2.TetrisComponents.Mechanics;

namespace SimpleTetris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TetrisGame : Game {
#if DEBUG
        System.IO.TextWriter textLogger;
#endif
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /*
        Texture2D textureTile;
        Core.Shape.Polyomino.Tetromino.Tetromino testingMino;
        */

        public TetrisGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
#if DEBUG
            textLogger = new System.IO.StreamWriter("log.txt");
#endif

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            /*
            SimpleTetris.Core.Shape.Polyomino.Tetromino.TetrominoBuilder builder = new Core.Shape.Polyomino.Tetromino.TetrominoBuilder();
            SimpleTetris.Core.Shape.Polyomino.Tetromino.BuildDirectors.MinoSimpleDirector director = new Core.Shape.Polyomino.Tetromino.BuildDirectors.MinoSimpleDirector(builder);

            director.Texture = SimpleTetris.Core.Graphics.Helpers.CreateTexture(graphics.GraphicsDevice, System.Convert.ToInt32(SimpleTetris.Core.Settings.GraphicalSettings.UnitWidth), System.Convert.ToInt32(SimpleTetris.Core.Settings.GraphicalSettings.UnitHeight), x => Color.Blue);
            director.Direct(Core.Shape.Polyomino.Tetromino.Tetrominoes.S);

            testingMino = builder.Build();

            textureTile = Content.Load<Texture2D>("tile");
            */

            /*
            this.Components.Add(new Core2.Piece.Mino(this, new System.Func<Texture2D>(() => {
                int w = 32;
                int h = 32;
                int sz = w * h;

                Texture2D texture = new Texture2D(GraphicsDevice, w, h);

                Color[] colors = new Color[sz];

                for (int i = 0; i < sz; ++i) colors[i] = Color.ForestGreen;

                texture.SetData(colors);

                return texture;
            })()));
            */

            /*
            int unitWidth = 32;
            int unitHeight = 32;

            Texture2D texture = new System.Func<Texture2D>(() => {
                int w = 32;
                int h = 32;
                int sz = w * h;

                Texture2D tex = new Texture2D(GraphicsDevice, w, h);

                Color[] colors = new Color[sz];

                for (int i = 0; i < sz; ++i) colors[i] = Color.ForestGreen;

                tex.SetData(colors);

                return tex;
            })();

            Polyomino piece = new Polyomino(this);

            piece.Minoes.AddRange(new [] {
                new Mino(this, texture) {
                    Position = new Vector2(1 * unitWidth, 0 * unitHeight)
                },
                new Mino(this, texture) {
                    Position = new Vector2(0 * unitWidth, 1 * unitHeight)
                },
                new Mino(this, texture) {
                    Position = new Vector2(1 * unitWidth, 1 * unitHeight)
                },
                new Mino(this, texture) {
                    Position = new Vector2(2 * unitWidth, 1 * unitHeight)
                }
            });

            this.Components.Add(piece);
            */

            int unitWidth = Properties.Settings.Default.UnitWidth;
            int unitHeight = Properties.Settings.Default.UnitHeight;

            Texture2D texture = new Func<Texture2D>(() => {
                int w = unitWidth;
                int h = unitHeight;
                int sz = w * h;

                Texture2D tex = new Texture2D(GraphicsDevice, w, h);

                Color[] colors = new Color[sz];

                for (int i = 0; i < sz; ++i) colors[i] = Color.ForestGreen;

                tex.SetData(colors);

                return tex;
            })();

            Action<object[]> painter = new Action<object[]>((args) => {
                if (args.Length == 0) return;
                if (args[0] is Sprite) {
                    Sprite sprite = args[0] as Sprite;
                    spriteBatch.Begin();
                    if (sprite.SpriteMode == SpriteModes.Single)
                        spriteBatch.Draw(
                            sprite.SamplingTexture,
                            sprite.Position * new Vector2(unitWidth, unitHeight),
                            null,
                            Color.White,
                            sprite.RotationAngle,
                            Vector2.Zero,
                            sprite.Scale,
                            SpriteEffects.None,
                            0
                            );
                    spriteBatch.End();
                }
            });

            List<Mino> minoList = new List<Mino> {
                new Mino(this) {
                    Position = new Vector2(1, 0),
                },
                new Mino(this) {
                    Position = new Vector2(0, 1)
                },
                new Mino(this) {
                    Position = new Vector2(1, 1)
                },
                new Mino(this) {
                    Position = new Vector2(2, 1)
                }
            };

            foreach (Mino mino in minoList) {
                mino.SamplingTexture = texture;
                mino.Painter = painter;
            }

            Polyomino polyomino = new Polyomino(this) {
                FallMechanics = new MinoFall(),
                ShiftMechanics = new MinoShift(),
                RotateMechanics = new MinoRotate()
            };

            foreach (Mino mino in minoList) {
                polyomino.Minoes.Add(mino);
            }

            polyomino.OriginMino = polyomino.Minoes[2];

            Components.Add(polyomino);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            /*
            spriteBatch.Begin();
            //spriteBatch.Draw(textureTile, new Vector2(10, 10), Color.White);
            foreach (var block in testingMino.Blocks)
                if (block != null)
                    spriteBatch.Draw(block.Texture, new Vector2(block.Transform.Position.X * Core.Settings.GraphicalSettings.UnitWidth, block.Transform.Position.Y * Core.Settings.GraphicalSettings.UnitHeight), Color.White);
            spriteBatch.End();
            */

            

            base.Draw(gameTime);
        }
    }
}
