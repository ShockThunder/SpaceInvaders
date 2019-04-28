using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders
{
    public class GameContent
    {
        public Texture2D imgInvader { get; set; }

        public GameContent(ContentManager Content)
        {
            imgInvader = Content.Load<Texture2D>("Invader");
        }
    }
}
