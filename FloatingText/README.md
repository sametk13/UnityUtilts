# How to use
1) Add Billboard, MonoSingleton and ObjectPool from this repo.
2) Create empty and attach ObjectPoolManager.
3) Add FloatingTextManager prefab to hierarchy
4) 

```
            ObjectPoolManager.Instance.AddObject("First Pool", itemsToPool);
            ObjectPoolManager.Instance.GetObject("First Pool");
            ObjectPoolManager.Instance.GetAllPooledObjects("First Pool");
```
