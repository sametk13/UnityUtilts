using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKUtils.ObjectPool
{
    public class ObjectPooler
    {
        public List<GameObject> itemsToPool;

        public ObjectPooler()
        {
            itemsToPool = new List<GameObject>();
        }

        public GameObject GetPooledObject()
        {
            if (itemsToPool.Count > 0)
            {
                var go = itemsToPool[0];
                itemsToPool.Remove(go);
                return go;
            }
            Debug.LogError($"Object Pool is Emty");
            return null;
        }

        public List<GameObject> GetAllPooledObjects()
        {
            return itemsToPool;
        }


        public void AddObject(GameObject go)
        {
            GameObject item = go;
            itemsToPool.Add(item);
        }
    }
}