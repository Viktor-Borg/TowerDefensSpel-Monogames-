using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel
{
    abstract class Controller
    {
        public static T Singelton { get; private set; }

        protected override void Initialize()
        {
            Singelton = (T)this;
            
        }
        
             
        

       
    }
}
