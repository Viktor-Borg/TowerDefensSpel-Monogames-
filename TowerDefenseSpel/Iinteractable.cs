using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseSpel
{
    /// <summary>
    /// interface which is used on all objects who will have some sort of interaction with other objects in the game.
    /// </summary>
    interface Iinteractable
    {
        public void Oninteract();
    }
}
