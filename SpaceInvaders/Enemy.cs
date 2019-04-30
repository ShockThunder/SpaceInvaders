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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

    public class Enemy
    {
        private float _x { get; set; }
        private float _y { get; set; }
        private bool _isAlive { get; set; }

        public float _width { get; set; }
        public float _height { get; set; }

        private Color _color = Color.White;
        private SpriteBatch _spriteBatch;
        private Texture2D _imgInvader { get; set; }

        public Enemy(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _spriteBatch = spriteBatch;
            _imgInvader = gameContent.imgInvader;
            _x = x;
            _y = y;
            _width = gameContent.imgInvader.Width;
            _height = gameContent.imgInvader.Height;
            _isAlive = true;
            

        }

        public void Draw()
        {
            if (_isAlive)
            {
                _spriteBatch.Draw(_imgInvader, new Vector2(_x, _y), null,
                    _color, 0, new Vector2(0,0), 1.0f, SpriteEffects.None, 0);
            }
        }

        public void SetX(float x)
        {
            this._x = x;
        }

        public void SetY(float y)
        {
            this._y = y;
        }

        public float GetX()
        {
            return _x;
        }

        public float GetY()
        {
            return _y;
        }

        public bool IsAlive()
        {
            return _isAlive;
        }

        public void Kill()
        {
            this._isAlive = false;
        }
    }
}
