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
        static List<Bullet> entities = new List<Bullet>();

        static bool isUpdating;
        static List<Bullet> addedEntities = new List<Bullet>();

        public static int Count { get { return entities.Count; } }

        public static void Add(Bullet entity)
        {
            if (!isUpdating)
                entities.Add(entity);
            else
                addedEntities.Add(entity);
        }

        public static void Update()
        {
            isUpdating = true;

            foreach (var entity in entities)
                entity.Update();

            isUpdating = false;

            foreach (var entity in addedEntities)
                entities.Add(entity);

            addedEntities.Clear();

            // remove any expired entities.
            entities = entities.Where(x => x.visible == true).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in entities)
                entity.Draw();
        }
    }
}
