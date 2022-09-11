using SKUtils.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKUtils.FloatingText
{
    public class FloatingTextHandler : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke("AddPool", 1f);
        }
        void AddPool()
        {
            ObjectPoolManager.Instance.AddObject("FloatingText", gameObject);
        }
    }
}
