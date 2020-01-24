using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.MapGeneration
{
    class Powersource: Tile
    {
        private int   amountOfEnergy;
        private float doameter;

        public Powersource(int size, Type type, Vector2 position) : base(size, type, position) { }

       
        #region Attributes

        public int   AmountOfEnergy { get { return amountOfEnergy; } set { amountOfEnergy = value; } }
        public float Diameter { get { return Diameter; } }

        #endregion
    }
}
