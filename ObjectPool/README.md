# How to use
1) Create a new empty GameObject.
2) Attach the ObjectPoolManager to the new created GameObject.


```
            ObjectPoolManager.Instance.AddObject("First Pool", itemsToPool);
            ObjectPoolManager.Instance.GetObject("First Pool");
            ObjectPoolManager.Instance.GetAllPooledObjects("First Pool");

```
