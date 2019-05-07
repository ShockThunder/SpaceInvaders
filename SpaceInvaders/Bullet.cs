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
    public class Bullet
    {
        private float _x;
        private float _y;

        private int _width;
        private int _height;

        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;

        private bool _isAlive = true;
        private int _yVelocity = -3;

        public Bullet(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _x = x;
            _y = y;
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;
            _width = _gameContent.imgInvader.Width;
            _height = _gameContent.imgInvader.Height;
        }

        public void Update()
        {
            Moving();

            if (GetY() < 0)
            {
                Kill();
            }
        }

        public void Draw()
        {
            if (CheckAlive())
            _spriteBatch.Draw(_gameContent.imgBullet, new Rectangle((int)_x, (int)_y, _width, _height), Color.White);
        }

        public void Kill()
        {
            _isAlive = false;
        }

        public bool CheckAlive()
        {
            return _isAlive;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)_x, (int)_y, _width, _height);
        }

        private void Moving()
        {
            _y += _yVelocity;
        }

        public float GetY()
        {
            return _y;
        }

        public float GetX()
        {
            return _x;
        }
    }
}