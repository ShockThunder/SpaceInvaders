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
    public class EnemyWall
    {
        private int _enemyCountX = 15;
        private int _enemyCountY = 3;

        private float _initialX;
        private float _initialY;

        private int _screenWidth;
        private int _screenHeight;

        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;

        private List<Enemy> Enemies = new List<Enemy>();
        private int _enemyWidth;
        private int _enemyHeight;

        private bool _moveLeft = true;

        public EnemyWall(int screenWidth, int screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _spriteBatch = spriteBatch;
            _gameContent = gameContent;

            _enemyWidth = gameContent.imgInvader.Width + 10;
            _enemyHeight = gameContent.imgInvader.Height + 10;
            _initialY = 50;
            _initialX = _screenWidth / 2 - ((_enemyCountX + 1) * _enemyWidth) / 2;

            FillEnemies();
        }

        public void Update()
        {
            Moving();
        }

        public void Draw()
        {
            foreach (var Enemy in Enemies)
            {
                if (Enemy.CheckAlive())
                {
                    Enemy.Draw();
                }
            }
        }

        #region SearchPositionMethods
        public Enemy GetLeftInvader()
        {
            foreach (var Enemy in Enemies)
            {
                if (Enemy.GetX() <= GetLeftX() && Enemy.CheckAlive())
                    return Enemy;
            }
            return null;
        }

        public Enemy GetRightInvader()
        {
            foreach (var Enemy in Enemies)
            {
                if (Enemy.GetX() >= GetRightX() && Enemy.CheckAlive())
                    return Enemy;
            }
            return null;
        }

        public float GetHighestY()
        {
            float highY = 600; 
            foreach (var Enemy in Enemies)
            {
                if (Enemy.GetY() < highY && Enemy.CheckAlive())
                    highY = Enemy.GetY();
            }

            return highY;
        }

        public float GetLowestY()
        {
            float lowY = 0;
            foreach (var Enemy in Enemies)
            {
                if (Enemy.GetY() > lowY && Enemy.CheckAlive())
                    lowY = Enemy.GetY();
            }

            return lowY;
        }

        public float GetLeftX()
        {
            float leftX = 800;
            foreach (var Enemy in Enemies)
            {
                if (Enemy.GetX() < leftX && Enemy.CheckAlive())
                    leftX = Enemy.GetX();
            }
            return leftX;
        }
        public float GetRightX()
        {
            float rightX = 0;
            foreach (var Enemy in Enemies)
            {
                if (Enemy.GetX() > rightX && Enemy.CheckAlive())
                    rightX = Enemy.GetX();
            }
            return rightX;
        }
        #endregion

        #region MovingMethods
        public void Moving()
        {
            if (_moveLeft)
            {
                MoveLeft();
                if(GetLeftX() <= 10)
                {
                    _moveLeft = false;
                    MoveDown();
                }
            }
            else
            {
                MoveRight();
                if (GetRightX() >= _screenWidth - 10)
                {
                    _moveLeft = true;
                    MoveDown();
                }
            }
        }

        private void MoveLeft()
        {
            foreach (var Enemy in Enemies)
            {
                Enemy.SetX(Enemy.GetX() - 1);
            }
        }

        private void MoveRight()
        {
            foreach (var Enemy in Enemies)
            {
                Enemy.SetX(Enemy.GetX() + 1);
            }
        }

        private void MoveDown()
        {
            foreach (var Enemy in Enemies)
            {
                Enemy.SetY(Enemy.GetY() + 10);
            }
        }
        #endregion

        private void FillEnemies()
        {
            float eX = _initialX;
            float eY = _initialY;
            for (int i = 0; i < _enemyCountY; i++)
            {
                eY += _enemyHeight;
                eX = _initialX;

                for (int j = 0; j < _enemyCountX; j++)
                {
                    eX += _enemyWidth;
                    Enemy tempEnemy = new Enemy(eX, eY, _spriteBatch, _gameContent);
                    Enemies.Add(tempEnemy);
                }
            }
        }

        public int GetEnemiesX()
        {
            return _enemyCountX;
        }
        public int GetEnemiesY()
        {
            return _enemyCountY;
        }

        public List<Enemy> GetEnemies()
        {
            return Enemies;
        }

    }
}