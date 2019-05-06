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
    public class Player
    {
        private float _x;
        private float _y;

        private int _width;
        private int _height;

        private int _screenWidth;
        private int _screenHeight;

        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;

        private bool _isAlive = true;
        public Player(int screenWidth, int screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;
            _x = _screenWidth / 2;
            _y = _screenHeight - 50;
            _width = _gameContent.imgPlayer.Width;
            _height = _gameContent.imgPlayer.Height;
        }

        public void MovePlayer(float x)
        {
            if (x > _screenWidth)
                _x = _screenWidth - _width;
            else if (x < 0)
                _x = 0;
            else
            _x = x;
        }

        public void Draw()
        {
            _spriteBatch.Draw(_gameContent.imgPlayer, new Rectangle((int)_x, (int)_y, _width, _height), Color.White);
        }

        public void Update()
        {

        }

        public bool CheckAlive()
        {
            return _isAlive;
        }
    }
}