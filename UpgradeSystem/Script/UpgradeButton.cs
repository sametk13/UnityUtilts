using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SKUtils.UpgradeSystem;
using DG.Tweening;
using System;

namespace SKUtils.UpgradeSystem
{
    //need DoTween asset
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI costText;

        float cost;

        [Header("Shake Settings")]
        [SerializeField] Vector3 punch = new Vector3(0.07f, 0.07f, 0.07f);
        [SerializeField] float duration = 0.3f;
        [SerializeField] int vibrato = 10;
        [SerializeField] float elasticity = 10;

        private Tweener tweener;

        private void OnEnable()
        {
            UpgradeManager.Instance.goldController.OnUpdateGold += SetInteractable;
            SetInteractable();
        }
        private void OnDisable()
        {
            UpgradeManager.Instance.goldController.OnUpdateGold -= SetInteractable;
        }

        public void Setup(UpgradableField upgradableField)
        {
            cost = upgradableField.CalculateCost();

            image.sprite = upgradableField.UpgradeData.ButtonSprite;

            titleText.SetText(upgradableField.UpgradeData.ButtonTitleText);

            levelText.SetText($"LV. {upgradableField.CurrentLevel}");

            costText.text = cost + "$";


            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (UpgradeManager.Instance.TryUpgrade(upgradableField))
                {
                    Debug.Log($"Upgrade: {upgradableField.UpgradeData.ButtonTitleText}");
                    PunchScale(() =>
                    {
                        UpgradeManager.OnBuildUpgradePanel?.Invoke();
                    });
                }
            });
            SetInteractable();
        }

        void SetInteractable()
        {
            if (UpgradeManager.Instance.goldController.IsEnoughtGold(cost))
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }

        public void PunchScale(Action completed = null)
        {
            if (tweener != null)
            {
                tweener.Kill(true);
            }

            tweener = transform.DOPunchScale(punch, duration, vibrato, elasticity).OnComplete(()=> completed?.Invoke());
        }
    }
}
