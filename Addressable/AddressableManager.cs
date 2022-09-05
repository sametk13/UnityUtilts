using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class AddressableManager : MonoBehaviour
{


    private static AddressableManager instance;

    public static AddressableManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("instance is null");
            }
            return instance;
        }
    }

    [SerializeField] Slider downloadPercentSlider;
    [SerializeField] Canvas downloadProgressCanvas;

    [SerializeField] AssetReferenceGameObject objectToLoaded;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        Debug.Log("Initializing Addressables...");

        var handler = LoadGameObjet(objectToLoaded);
        handler.Completed += AddressableGameObjectLoaded;

        StartCoroutine(IEDownloadProgress(handler));
       
    }

    AsyncOperationHandle<GameObject> LoadGameObjet(AssetReferenceGameObject assetReferenceGameObject)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(assetReferenceGameObject);
        return handle;
    }


    private void AddressableGameObjectLoaded(AsyncOperationHandle<GameObject> _obj)
    {

        switch (_obj.Status)
        {
            case AsyncOperationStatus.Succeeded:
                {
                    var obj = _obj.Result;
                    Debug.Log($"Loaded object : {obj.name}");
                }
                break;
            case AsyncOperationStatus.Failed:
                {
                    Debug.LogError($"AssetReference {_obj.DebugName} failed to load.");
                }
                break;
        }
    }

    private IEnumerator IEDownloadProgress(AsyncOperationHandle<GameObject> _handle)
    {
        var isDone = false;


        _handle.Completed += (operation) =>
        {
            isDone = true;
            downloadPercentSlider.value = downloadPercentSlider.maxValue;
        };

        while (!isDone)
        {
            downloadPercentSlider.value = _handle.PercentComplete;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitUntil(() => isDone);
    }

}

