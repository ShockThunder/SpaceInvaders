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
    public class BulletManager
    {
        public List<Bullet> Bullets = new List<Bullet>();
        public List<Bullet> tempBullets = new List<Bullet>();
        private EnemyWall _enemyWall;


        private SpriteBatch _spriteBatch;
        private GameContent _gameContent;
        public BulletManager(EnemyWall enemyWall, SpriteBatch spriteBatch, GameContent gameContent)
        {

            _spriteBatch = spriteBatch;
            _gameContent = gameContent;

            _enemyWall = enemyWall;
        }

        public void Draw()
        {
            if(Bullets.Count != 0)
            {
                foreach (var Bullet in Bullets)
                {
                    Bullet.Draw();
                }

            }
        }

        public void Update()
        {
            CheckHit();

            if (Bullets.Count != 0)
            {
                foreach (var Bullet in Bullets)
                {
                    Bullet.Update();
                }

                if (Bullets.Count > 30)
                {
                    
                    foreach (var Bullet in Bullets)
                    {
                        if (Bullet.CheckAlive())
                        {
                            tempBullets.Add(Bullet);
                        }
                    }
                    Bullets.Clear();

                    foreach (var Bullet in tempBullets)
                    {
                        Bullets.Add(Bullet);
                    }

                    tempBullets.Clear();
                }
            }

            
        }

        private void CheckHit()
        {
            
            List<Enemy> enemies = _enemyWall.GetEnemies();


            foreach (var Enemy in enemies)
            {
                if (Enemy.CheckAlive())
                {
                    foreach (var Bullet in Bullets)
                    {
                        if (Bullet.CheckAlive())
                        {
                            if(Intersect(Enemy, Bullet))
                            {
                                Bullet.Kill();
                                Enemy.Kill();
                                
                            }
                        }
                    }
                }
            }
            
        }

        public void Shoot(float x, float y)
        {
            Bullet b = new Bullet(x, y, _spriteBatch, _gameContent);
            Bullets.Add(b);
        }

        public bool Intersect(Enemy enemy, Bullet bullet)        
        {
            if(enemy.GetRectangle().Intersects(bullet.GetRectangle()))
            return true;

            return false;
        }
    }
}