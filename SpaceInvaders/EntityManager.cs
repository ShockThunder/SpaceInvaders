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
    static class EntityManager
    {
        static List<Bullet> bulletsFirst = new List<Bullet>();

        static bool useFirst = true;
        static List<Bullet> bulletsSecond = new List<Bullet>();

        public static int Count { get { return bulletsFirst.Count; } }

        public static void Add(Bullet entity)
        {
            if (useFirst)
            {
                bulletsFirst.Add(entity);

                if (bulletsFirst.Count > 30)
                {
                    foreach (var bullet in bulletsFirst)
                    {
                        if (bullet.visible == true)
                        {
                            bulletsSecond.Add(bullet);
                        }
                    }

                    bulletsFirst.Clear();
                    useFirst = false;
                }
            }

            else
            {
                bulletsSecond.Add(entity);

                if (bulletsSecond.Count > 30)
                {
                    foreach (var bullet in bulletsSecond)
                    {
                        if (bullet.visible == true)
                        {
                            bulletsFirst.Add(bullet);
                        }
                    }

                    bulletsSecond.Clear();
                    useFirst = true;
                }
            }


        }

        public static void Update()
        {
            if (useFirst == true)
            {
                foreach (var entity in bulletsFirst)
                    entity.Update();
            }
            else
            {
                foreach (var entity in bulletsSecond)
                    entity.Update();
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (useFirst == true)
            {
                foreach (var entity in bulletsFirst)
                    entity.Draw();
            }
            else
            {
                foreach (var entity in bulletsSecond)
                    entity.Draw();
            }


        }

        public static void HitCheck(EnemyWall enemyWall)
        {
            float left = enemyWall.FindLeftInvader();
            float right = enemyWall.FindRightInvader();
            float top = enemyWall.GetHighestY();
            float bot = enemyWall.GetLowestY();

            if (useFirst == true)
            {
                for (int i = 0; i < enemyWall.enemyCountY; i++)
                {
                    for (int j = 0; j < enemyWall.enemyCountX; j++)
                    {
                        Enemy currEnemy = enemyWall.GetEnemy(i, j);
                        if (currEnemy.IsAlive())
                        {
                            Rectangle rectE = new Rectangle((int)currEnemy.GetX(), (int)currEnemy.GetY(), (int)currEnemy._width, (int)currEnemy._height);
                            foreach (var bullet in bulletsFirst)
                            {
                                if (bullet.X > left && bullet.X < right
                                   && bullet.Y > top && bullet.Y < bot && bullet.visible)
                                {
                                    Rectangle rectB = new Rectangle((int)bullet.X, (int)bullet.Y, (int)bullet._width, (int)bullet._height);
                                    if (rectE.Intersects(rectB))
                                    {
                                        currEnemy.Kill();
                                        bullet.visible = false;
                                    }

                                }
                            }
                        }
                            
                    }
                }
            }
            else
            {
                for (int i = 0; i < enemyWall.enemyCountY; i++)
                {
                    for (int j = 0; j < enemyWall.enemyCountX; j++)
                    {
                        Enemy currEnemy = enemyWall.GetEnemy(i, j);
                        if (currEnemy.IsAlive())
                        {
                            Rectangle rectE = new Rectangle((int)currEnemy.GetX(), (int)currEnemy.GetY(), (int)currEnemy._width, (int)currEnemy._height);
                            foreach (var bullet in bulletsSecond)
                            {
                                if (bullet.X > left && bullet.X < right
                                   && bullet.Y > top && bullet.Y < bot && bullet.visible)
                                {
                                    Rectangle rectB = new Rectangle((int)bullet.X, (int)bullet.Y, (int)bullet._width, (int)bullet._height);
                                    if (rectE.Intersects(rectB))
                                    {
                                        currEnemy.Kill();
                                        bullet.visible = false;
                                    }

                                }
                            }
                        }
                        
                    }
                }
            }
            
        }
    }
}
