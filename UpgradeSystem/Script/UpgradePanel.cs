using UnityEngine;
using SKUtils.UpgradeSystem;

namespace SKUtils.UpgradeSystem
{
    public class UpgradePanel : MonoBehaviour
    {
        [SerializeField] GameObject upgradeButtonPrefab;


        private void OnEnable()
        {
            UpgradeManager.OnBuildUpgradePanel += BuildUpgradables;
        }

        private void OnDisable()
        {
            UpgradeManager.OnBuildUpgradePanel += BuildUpgradables;
        }
        public void BuildUpgradables()
        {
            ClearChilds();

            foreach (var upgradableField in UpgradeManager.Instance.UpgradableList)
            {
                var go = Instantiate(upgradeButtonPrefab);
                go.transform.SetParent(transform, false);

                go.GetComponent<UpgradeButton>().Setup(upgradableField);
            }
        }

        private void ClearChilds()
        {
            for (int i = transform.childCount - 1; i >= 0; --i)
            {
                Transform child = transform.GetChild(i);

                if (child.gameObject.activeSelf)
                    Destroy(child.gameObject);
            }
        }
    }
}