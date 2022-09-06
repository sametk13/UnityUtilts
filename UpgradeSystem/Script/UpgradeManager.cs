using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKUtils.UpgradeSystem;
namespace SKUtils.UpgradeSystem
{
    [RequireComponent(typeof(GoldController))]
    public class UpgradeManager : MonoBehaivourSingleton<UpgradeManager>
    {
        public List<UpgradableField> UpgradableList = new List<UpgradableField>();
        [HideInInspector]public GoldController goldController;

        public static Action OnBuildUpgradePanel;

        private void Awake()
        {
            goldController = GetComponent<GoldController>();
        }

        private void Start()
        {
            OnBuildUpgradePanel?.Invoke();
        }

        public bool TryUpgrade(UpgradableField upgradableField)
        {
            var cost = upgradableField.CalculateCost();

            if (goldController.IsEnoughtGold(cost))
            {
                goldController.DecreaseMoney(cost);

                upgradableField.Upgrade();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
