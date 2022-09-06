using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKUtils.UpgradeSystem
{
    [CreateAssetMenu(menuName = "SkUtils/UpgradeSystem/UpgradeData")]
    public class UpgradeData : ScriptableObject
    {
        public Sprite ButtonSprite;
        public string ButtonTitleText;
    }
}