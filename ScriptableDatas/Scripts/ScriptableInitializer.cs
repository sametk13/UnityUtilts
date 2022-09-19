using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SKUtils.ScriptableSystem
{
    public class ScriptableInitializer : MonoBehaviour
    {
        private void Start()
        {
            var scriptableDatas = Resources.FindObjectsOfTypeAll<ScriptableData>();
            foreach (var sd in scriptableDatas)
            {
                sd.Initialize();
            }
        }
    }
}