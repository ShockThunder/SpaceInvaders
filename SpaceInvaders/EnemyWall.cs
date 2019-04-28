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
    public class EnemyWall
    {
        private Enemy[,] Enemies { get; set; }

        public EnemyWall(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Enemies = new Enemy[3, 7];
            float enemyX = x;
            float enemyY = y;
            Color color = Color.White;

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Orange;
                        break;
                    case 2:
                        color = Color.Yellow;
                        break;
                    case 3:
                        color = Color.Green;
                        break;

                }

                enemyY = y + i * 2*(gameContent.imgInvader.Height+10);

                for (int j = 0; j < 7; j++)
                {
                    enemyX = x + j * 2*(gameContent.imgInvader.Width+10);
                    Enemy enemy = new Enemy(enemyX, enemyY, color, spriteBatch, gameContent);
                    Enemies[i, j] = enemy;
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Enemies[i, j].Draw();
                }
            }
        }
    }
}
