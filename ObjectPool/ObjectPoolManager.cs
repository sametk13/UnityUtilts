using System.Collections.Generic;
using UnityEngine;

namespace SKUtils.ObjectPool
{
    public class ObjectPoolManager : MonoBehaivourSingleton<ObjectPoolManager>
    {
        public Dictionary<string, ObjectPooler> objectPoolerPairs;

        public void AddObject(string poolerName, GameObject go)
        {
            NewObjectPooler(poolerName);
            objectPoolerPairs[poolerName].AddObject(go);
        }

        public GameObject GetObject(string poolerName)
        {
            if (!objectPoolerPairs.ContainsKey(poolerName))
                Debug.LogError($"There is no object pooler named: {poolerName}");
            return objectPoolerPairs[poolerName].GetPooledObject();
        }

        public List<GameObject> GetAllPooledObjects(string poolerName)
        {
            if (!objectPoolerPairs.ContainsKey(poolerName))
                Debug.LogError($"There is no object pooler named: {poolerName}");
            return objectPoolerPairs[poolerName].GetAllPooledObjects();
        }

        void NewObjectPooler(string poolerName)
        {
            if (!objectPoolerPairs.ContainsKey(poolerName))
                objectPoolerPairs.Add(poolerName, new ObjectPooler());
        }
    }
}