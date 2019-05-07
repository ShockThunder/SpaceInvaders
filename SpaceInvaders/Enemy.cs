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
    public class Enemy
    {
        private float _x;
        private float _y;

        private int _width;
        private int _height;

        //private int _screenWidth;
        //private int _screenHeight;

        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;

        private bool _isAlive = true;

        public Enemy(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
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

        }

        public void Draw()
        {
            if(CheckAlive())
            _spriteBatch.Draw(_gameContent.imgInvader, new Rectangle((int)_x, (int)_y, _width, _height), Color.White);
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


        #region PositionMethods
        public float GetX()
        {
            return _x;
        }

        public float GetY()
        {
            return _y;
        }

        public void SetX(float x)
        {
            _x = x;
        }

        public void SetY(float y)
        {
            _y = y;
        }

        public void SetPosition(float x, float y)
        {
            _x = x;
            _y = y;
        }
        #endregion
    }
}