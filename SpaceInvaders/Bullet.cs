using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders
{
    public class Bullet
    {
        public float X;
        public float Y;
        private float Yvelocity = 3;
        private float _width;
        private float _height;
        public bool visible { get; set; }
        private Texture2D _imgBullet { get; set; }
        private SpriteBatch _spriteBatch { get; set; }
        private GameContent _gameContent;

        public Bullet(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;
            _imgBullet = _gameContent.imgBullet;
            _width = _imgBullet.Width;
            _height = _imgBullet.Height;
                       
            visible = true;
            X = x;
            Y = y;
        }

        public void Draw()
        {
            if (!visible)
            {
                return;
            }

            

            _spriteBatch.Draw(_imgBullet, new Vector2(X + _width, Y), null, Color.White, 0,
                new Vector2(_width, _height), 1.0f, SpriteEffects.None, 0);
        }
                
        public bool Move()
        {
            if (!visible)
            {
                return false;
            }

            Y = Y - Yvelocity;
            return true;

        }

        public void Update()
        {
            Y -= Yvelocity;
        }
    }
}
