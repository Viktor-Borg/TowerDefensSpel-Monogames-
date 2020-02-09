using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    class ObjectPooling<T> where T : VisibleGameobject
    {
        private List<T> storedObjects;
        private List<T> activeObjects;
        
        public ObjectPooling(T[] collection)
        {
            this.storedObjects = new List<T>();
            this.activeObjects = new List<T>();
            for(int i = 0; i<collection.Length; i++)
            {
                storedObjects.Add(collection[i]);
            }
            
        }

        public void DeactivateObject(T objectToDeactivate)
        {
            activeObjects.Remove(objectToDeactivate);
        }

        public void ActivateObject(T objecToActivate, Texture2D texture)
        {
            objecToActivate.Texture = texture;
            activeObjects.Add(objecToActivate);
        }

        public void AddStoredObject(T[] objectsToAdd)
        {
            for (int i = 0; i < objectsToAdd.Length; i++)
            {
                storedObjects.Add(objectsToAdd[i]);
            }
        }

        public void RemoveStoredObjects(T[] objectsToRemove)
        {
            for(int i = 0; i < objectsToRemove.Length; i++)
            {
                storedObjects.Remove(objectsToRemove[i]);
            }
        }

        public T GrabObject(int index)
        {
            return storedObjects[index];
        }

        public T[] GetAllStored()
        {
            return storedObjects.ToArray();
        }

        public T[] ActiveObjects { get { return activeObjects.ToArray(); } }
    }
}
