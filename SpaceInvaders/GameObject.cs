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
    public class GameObject
    {
        private float _x;
        private float _y;

        private float _width;
        private float _height;

        private float _screenWidth;
        private float _screenHeight;

        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;

        public GameObject(float screenHeight, float screenWidth, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;
        }

    }
}
