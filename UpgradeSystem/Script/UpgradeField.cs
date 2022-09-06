using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SKUtils.UpgradeSystem
{
    [Serializable]
    public class UpgradableField
    {
        public UpgradeData UpgradeData;

        public int CurrentLevel;
        public float Value;

        [Header("Value Base Settings")]
        public float BaseValue;
        public float PerLevelIncreaseValue;
        public int BaseCost;

        public UnityEvent OnUpgrade;


        public void Upgrade()
        {
            CurrentLevel += 1;

            OnUpgrade?.Invoke();

            Value = CalculateUpgradableValueAtLevel(CurrentLevel);

        }

        public int CalculateCost()
        {
            var currentLevel = CurrentLevel;
            return (int)(BaseCost + (Mathf.Pow(currentLevel, 1.5f) * BaseCost / 10f));
        }

        public float CalculateUpgradableValueAtLevel(int level)
        {
            return BaseValue + PerLevelIncreaseValue * level;
        }
    }


}

