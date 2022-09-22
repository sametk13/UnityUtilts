using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMonoSingleton : MonoSingleton<DontDestroyMonoSingleton>
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
