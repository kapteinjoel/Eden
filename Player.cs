using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Eden.States
{
    class Player
    {

        Texture2D _skin;

       public Vector2 playerPos { get; set; }

        public Player()
        {
            playerPos = new Vector2(100, 100);
            
        }

    }
}
