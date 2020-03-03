using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    class ObjectPooling<T> where T : VisibleGameobject
    {
        private Queue<T> storedObjects;
        private List<T> activeObjects;
        
        public ObjectPooling(T[] collection)
        {
            this.storedObjects = new Queue<T>();
            this.activeObjects = new List<T>();
            for(int i = 0; i<collection.Length; i++)
            {
                storedObjects.Enqueue(collection[i]);
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
                storedObjects.Enqueue(objectsToAdd[i]);
            }
        }

        public void RemoveStoredObjects(int amountOfObjects)
        {
            for(int i = 0; i < amountOfObjects; i++)
            {
                storedObjects.Dequeue();
            }
        }

        public T GrabObject()
        {
            T temp = storedObjects.Dequeue();
            activeObjects.Add(temp);
            return temp;
        }

        public T[] GetAllStored()
        {
            return storedObjects.ToArray();
        }

        public T[] ActiveObjects { get { return activeObjects.ToArray(); } }
    }
}
