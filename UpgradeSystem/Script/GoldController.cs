using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SKUtils.UpgradeSystem
{
    public class GoldController : MonoBehaviour
    {
        [SerializeField]private float Gold;

        public Action<float> OnIncreaseGold;
        public Action<float> OnDecreaseGold;
        public Action OnUpdateGold;

        public void IncreaseMoney(float amount)
        {
            Gold += amount;

            OnUpdateGold?.Invoke();

            OnIncreaseGold?.Invoke(Gold);
        }

        public void DecreaseMoney(float amount)
        {
            Gold -= amount;

            OnUpdateGold?.Invoke();

            OnDecreaseGold?.Invoke(Gold);
        }

        public bool IsEnoughtGold(float _value)
        {
            if (Gold - _value >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}