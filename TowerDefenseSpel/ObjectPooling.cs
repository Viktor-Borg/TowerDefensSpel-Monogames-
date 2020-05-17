using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// pools objects so they are preloaded into the game to save on performance. objects must be derived from visibleGameobject.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ObjectPooling<T> where T : VisibleGameobject
    {
        private Queue<T> storedObjects;
        private List<T> activeObjects;
        
        //takes in an array of the object which is suppose to be pooled then enqueues them to the stored objects queue.
        public ObjectPooling(T[] collection)
        {
            this.storedObjects = new Queue<T>();
            this.activeObjects = new List<T>();
            for(int i = 0; i<collection.Length; i++)
            {
                storedObjects.Enqueue(collection[i]);
            }
            
        }
        //removes object from the activeobjcts list.
        public void DeactivateObject(T objectToDeactivate)
        {
            activeObjects.Remove(objectToDeactivate);
        }

        //activates an object and gives them a texture.
        public void ActivateObject(T objecToActivate, Texture2D texture)
        {
            objecToActivate.Texture = texture;
            activeObjects.Add(objecToActivate);
        }
        //adds an array of objects to the stored queue.
        public void AddStoredObjects(T[] objectsToAdd)
        {
            for (int i = 0; i < objectsToAdd.Length; i++)
            {
                storedObjects.Enqueue(objectsToAdd[i]);
            }
        }
        //adds a single object to the stored queue.
        public void AddStoredObject(T objectToAdd)
        {
            storedObjects.Enqueue(objectToAdd);
        }
        //removes a specified amount of objects from the stored queue.
        public void RemoveStoredObjects(int amountOfObjects)
        {
            for(int i = 0; i < amountOfObjects; i++)
            {
                storedObjects.Dequeue();
            }
        }
        // grabs ab object from the stored queue
        public T GrabObject()
        {
            T temp = storedObjects.Dequeue();
            activeObjects.Add(temp);
            return temp;
        }
        // grabs all the stored objects.
        public T[] GetAllStored()
        {
            return storedObjects.ToArray();
        }

        #region Attributes

        public List<T> ActiveObjects { get { return activeObjects; } }

        #endregion

    }
}
