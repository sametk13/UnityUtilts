using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using SKUtils.ScriptableSystem;

namespace SKUtils.UpgradeSystem
{
    [Serializable]
    public class UpgradableField
    {
        public UpgradeData UpgradeData;

        public ScriptableInt CurrentLevel;
        public ScriptableFloat Value;

        [Header("Value Base Settings")]
        public float BaseValue;
        public float PerLevelIncreaseValue;
        public int BaseCost;

        public UnityEvent OnUpgrade;


        public void Upgrade()
        {
            CurrentLevel.IncreaseValue(1);

            OnUpgrade?.Invoke();

            Value.UpdateValue(CalculateUpgradableValueAtLevel(CurrentLevel.GetValue()));
        }

        public int CalculateCost()
        {
            var currentLevel = CurrentLevel.GetValue();
            return (int)(BaseCost + (Mathf.Pow(currentLevel, 1.5f) * BaseCost / 10f));
        }

        public float CalculateUpgradableValueAtLevel(int level)
        {
            return BaseValue + PerLevelIncreaseValue * level;
        }
    }
}

