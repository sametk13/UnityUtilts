using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using SKUtils.ObjectPool;

namespace SKUtils.FloatingText
{
    public class FloatingTextManager : MonoBehaviourSingleton<FloatingTextManager>
    {
        [SerializeField] GameObject floatingTextPrefab;

        public void AddFloatingText(Vector3 spawnPos, string floatingTextValue)
        {
            GameObject go = ObjectPoolManager.Instance.GetObject("FloatingText");

            if (go != null)
            {
                GameObject floatingText = go;
                floatingText.SetActive(true);
                floatingText.transform.position = spawnPos;
                floatingText.GetComponentInChildren<TextMeshPro>().SetText(floatingTextValue);
            }
            else
            {
                GameObject floatingTextObject = Instantiate(floatingTextPrefab, spawnPos, Quaternion.identity);
                floatingTextObject.GetComponentInChildren<TextMeshPro>().SetText(floatingTextValue);
            }
        }
    }
}