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
        private float X;
        private float Y;
        private float Yvelocity;
        private float _width;
        private float _height;
        public bool Visible { get; set; }
        private Texture2D imgBullet { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private GameContent gameContent;

        private float _screenWidth;
        private float _screenHeight;

        public Bullet(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            this.spriteBatch = spriteBatch;
            this.gameContent = gameContent;
            imgBullet = gameContent.imgBullet;
            _width = imgBullet.Width;
            _height = imgBullet.Height;

            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            Visible = false;
        }

        public void Draw()
        {
            if (!Visible)
            {
                return;
            }

            

            spriteBatch.Draw(imgBullet, new Vector2(X, Y), null, Color.White, 0,
                new Vector2(_width, _height), 1.0f, SpriteEffects.None, 0);
        }

        public void Shoot(float x, float y, float yvelocity, Player player)
        {           
            
            Visible = true;
            X = player.X;
            Y = player.Y;
            Yvelocity = yvelocity;

        }

        public bool Move()
        {
            if (!Visible)
            {
                return false;
            }

            Y = Y - Yvelocity;
            return true;

        }
    }
}
