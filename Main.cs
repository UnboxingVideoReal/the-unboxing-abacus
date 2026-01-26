using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using static boxMos.Scientific;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using boxMos.Terms;


namespace boxMos
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TtfFontBakerResult ncm;
        public SpriteFont font;
        private int start = 0;
        public string written = "";
        private Keys previousKey = Keys.None;
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            using (var str = File.OpenRead("Content/New Computer Modern.ttf"))
            {
                ncm = TtfFontBaker.Bake(str,
                    32,
                    1024,
                    1024,
                    [
                        CharacterRange.BasicLatin,
                    CharacterRange.Latin1Supplement,
                    CharacterRange.LatinExtendedA,
                    CharacterRange.Cyrillic, ]
                );

            }
            font = ncm.CreateSpriteFont(GraphicsDevice);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }
        public string testExpression()
        {
            //PolynomialTerm polynomialTerm = new PolynomialTerm([3,4,5,1,2]);
            //string yea = polynomialTerm.ToMath("x");
            var exp = SyntheticDivision([1, 2, 3], 2);
            //double solved = EvaluatePolynomial(1, exp, 2);
            //string polynomial = ExpressionToString(exp, "x");
            ////string function = ListToPolynomial(exp, "x");
            List<Term> integral = IndefiniteIntegral(exp, 0.0001);
            ////var exp = Integral(function)
            //string integralfunc = ListToIIntegral(integral, "x");
            string polynomial = ExpressionToString(integral, "x");



            return /*polynomial + ", indefinite integral = " + integralfunc.ToString()*/polynomial /*+ ", " + solved*/;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            Keys[] key = Keyboard.GetState().GetPressedKeys();
            Debug.WriteLine(testExpression());
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                if (key[0] != previousKey)
                {
                    start = 0;
                }

                if (start == 0 || start >= 60)
                {
                    written = written + key[0].ToString().ToLower().Replace("d0", "0").Replace("d1", "1").Replace("d2", "2").Replace("d3", "3").Replace("d4", "4").Replace("d5", "5").Replace("d6", "6").Replace("d7", "7").Replace("d8", "8").Replace("d9", "9").Replace("space", " ").Replace("oemcomma", ",").Replace("oemperiod", ".").Replace("oemquestion", "?").Replace("oemsemicolon", ";").Replace("oemquotes", "'").Replace("oemplus", "=").Replace("oemminus", "-").Replace("oemopenbrackets", "[").Replace("oemclosebrackets", "]").Replace("oempipe", "\\").Replace("oemtilde", "`").Replace("tab", "\t");
                    start += 1;
                }
                else
                {
                    start++;
                }
                previousKey = key[0];
            }
            else
            {
                previousKey = Keys.None;
            }
                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            bool yea = ((int)(gameTime.TotalGameTime.TotalSeconds / 1)) % 2 == 0;
            if (yea)
            {
                _spriteBatch.DrawString(font, $"Scientific (S) or Graphing (G)?: {written}|", new Vector2(10, 10), Color.Black);
            }
            else {
                _spriteBatch.DrawString(font, $"Scientific (S) or Graphing (G)?: {written}", new Vector2(10, 10), Color.Black);
            }
            _spriteBatch.End();
        }
    }
}
