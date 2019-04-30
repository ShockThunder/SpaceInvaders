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
        private float _x { get; set; }
        private float _y { get; set; }
        private float _width { get; set; }
        private float _height { get; set; }
        private float _screenWidth { get; set; }
        private float _screenHeight { get; set; }

        private Texture2D _imgPlayer { get; set; }
        private SpriteBatch _spriteBatch { get; set; }
        private GameContent _gameContent { get; set; }

        private Bullet[] _bullets { get; set; }


        public Player(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;
                    
            _imgPlayer = _gameContent.imgPlayer;

            _width = _imgPlayer.Width;
            _height = _imgPlayer.Height;
            
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            _x = (_screenWidth - gameContent.imgPlayer.Width) / 2;
            _y = _screenHeight - 50;
        }

        public void Draw()
        {
            _spriteBatch.Draw(_imgPlayer, new Vector2(_x, _y), null, Color.White,
                0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public void MoveLeft()
        {
            _x -= 5;
            if (_x < 1)
                _x = 1;
        }

        public void MoveRight()
        {
            _x += 5;
            if ((_x + _width) > _screenWidth)
                _x = _screenWidth - _width;
        }

        public void MoveTo(float x)
        {
            if (x >= 0)
            {
                if (x < _screenWidth - _width)
                {
                    _x = x;
                }
                else
                {
                    _x = _screenWidth - _width;
                }
            }
            else
            {
                if (x < 0)
                {
                    _x = 0;
                }
            }
        }
        
        public void Shoot()
        {
            EntityManager.Add(new Bullet(this._x, this._y, _spriteBatch, _gameContent));
            
        }

    }
}
