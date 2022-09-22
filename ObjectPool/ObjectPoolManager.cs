using System.Collections.Generic;
using UnityEngine;

namespace SKUtils.ObjectPool
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        public Dictionary<string, ObjectPooler> objectPoolerPairs;

        private void Awake()
        {
            objectPoolerPairs = new Dictionary<string, ObjectPooler>();
        }
        public void AddObject(string poolerName, GameObject go)
        {
            NewObjectPooler(poolerName);
            objectPoolerPairs[poolerName].AddObject(go);
            go.SetActive(false);
        }

        public GameObject GetObject(string poolerName)
        {
            if (!objectPoolerPairs.ContainsKey(poolerName))
            {
                Debug.LogError($"There is no object pooler named: {poolerName}");
                return null;
            }
            GameObject go = objectPoolerPairs[poolerName].GetPooledObject();
            if (go != null) go.SetActive(true);
            return go;
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
