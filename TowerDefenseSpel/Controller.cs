using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel
{
    abstract class Controller<T>: Game where T : Controller<T>
    {
        public static T Singelton { get; private set; }

        protected override void Initialize()
        {
            Singelton = (T)this;
        }

       
    }
}
