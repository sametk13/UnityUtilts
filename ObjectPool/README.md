# How to use
1) Add MonoSingleton from this repo.
2) Create a new empty GameObject.
3) Attach the ObjectPoolManager to the new created GameObject.


```
            ObjectPoolManager.Instance.AddObject("First Pool", itemsToPool);
            ObjectPoolManager.Instance.GetObject("First Pool");
            ObjectPoolManager.Instance.GetAllPooledObjects("First Pool");
```
