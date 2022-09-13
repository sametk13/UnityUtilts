using SKUtils.ScriptableSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SKUtils.UpgradeSystem
{
    public class GoldController : MonoBehaviour
    {
        public  ScriptableFloat Gold;

        public void IncreaseMoney(float amount)
        {
            Gold.IncreaseValue(amount);
        }

        public void DecreaseMoney(float amount)
        {
            Gold.DecreaseValue(amount);
        }

        public bool IsEnoughtGold(float _value)
        {
            if (Gold.GetValue() - _value >= 0)
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