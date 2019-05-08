using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
    public class FontManager
    {

        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;
        private SpriteFont _gameFont;
        private int _screenWidth;
        private int _screenHeight;



        public FontManager(int screenWidth, int screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;
            _gameFont = _gameContent.gameFont;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;    
        }
        
        public void DrawString(string msg, float x, float y)
        {
            _spriteBatch.DrawString(_gameFont, msg, new Vector2(x, y), Color.White);
        }

        public void DrawScore(int score)
        {
            _spriteBatch.DrawString(_gameFont, $"Score: {score}", new Vector2(10, 10), Color.White);
        }

        public void DrawTitleScreen()
        {
            string title = "SPACE ENEMIES";
            string startMsg = "Press LMB to start";
            Vector2 titleSize = _gameFont.MeasureString(title);
            Vector2 startMsgSize = _gameFont.MeasureString(startMsg);
            float scale = 1.5f;
            _spriteBatch.DrawString(_gameFont, title, new Vector2((_screenWidth - titleSize.X * scale) / 2, (_screenHeight - titleSize.Y * scale) / 2), Color.White, 0.0f, default, scale, SpriteEffects.None, 0);
            _spriteBatch.DrawString(_gameFont, startMsg, new Vector2((_screenWidth - startMsgSize.X) / 2, (_screenHeight + titleSize.Y * scale + startMsgSize.Y * 4) / 2), Color.White, 0.0f, default, 1.0f, SpriteEffects.None, 0);
            _spriteBatch.Draw(_gameContent.imgTitle, new Vector2((_screenWidth - _gameContent.imgTitle.Width / 5) / 2, 50), null, Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 0);
        }

        
    }
}