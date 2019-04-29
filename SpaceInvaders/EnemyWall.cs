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
        public int enemyCountX { get; set; }
        public int enemyCountY { get; set; }
        private float X;
        private float Y;


        //в конструктор передается ширина экрана для расчета координат отрисовки, чтобы все враги были по центру.
        public EnemyWall(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {

            enemyCountX = 20;
            enemyCountY = 5;
            X = x/2 - gameContent.imgInvader.Width * (enemyCountX - 1);
            Y = y;
            
            Enemies = new Enemy[enemyCountY, enemyCountX];
            float enemyX = X;
            float enemyY = Y;
            Color color = Color.White;

            for (int i = 0; i < enemyCountY; i++)
            {
                
                enemyY = Y + i * 2*gameContent.imgInvader.Height;

                for (int j = 0; j < enemyCountX; j++)
                {
                    enemyX = X + j * 2 *gameContent.imgInvader.Width;
                    Enemy enemy = new Enemy(enemyX, enemyY, color, spriteBatch, gameContent);
                    Enemies[i, j] = enemy;
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < enemyCountY; i++)
            {
                for (int j = 0; j < enemyCountX; j++)
                {
                    Enemies[i, j].Draw();
                }
            }
        }
    }
}
