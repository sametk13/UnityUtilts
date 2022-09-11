using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public UnityEvent ProgressBarUpdated;

    [SerializeField] Image progressBarFilledImage;
    [SerializeField] float filledTime = .15f;

    [Header("Optionally")]
    [SerializeField] TextMeshProUGUI progressPercentText;
    [SerializeField] string percentPrefix, percentSuffix;
    [SerializeField] TextMeshProUGUI currentValueText;
    [SerializeField] string currentValuePrefix, currentValueSuffix;

    Tween currentTween;

    public void UpdateProgressBar(float _currentValue, float _maxValue)
    {
        ProgressBarUpdated?.Invoke();

        if (currentTween != null)
        {
            currentTween.Kill();
            currentTween = null;
        }

        float _fillAmount = progressBarFilledImage.fillAmount;

        currentTween = DOTween.To(() => _fillAmount, x => _fillAmount = x, Mathf.InverseLerp(0, _maxValue, _currentValue), filledTime).OnUpdate(() =>
        {
            progressBarFilledImage.fillAmount = _fillAmount;
        });

        if (progressPercentText != null)
        {
            progressPercentText.SetText($"{percentPrefix}{_fillAmount}{percentSuffix}");
        }
        if (currentValueText != null)
        {
            currentValueText.SetText($"{currentValuePrefix}{_currentValue}{currentValueSuffix}");
        }
    }

    public void ResetProgressBar()
    {
        gameObject.SetActive(true);
        progressBarFilledImage.fillAmount = 1f;
    }
    public void HideProgressBar()
    {
        gameObject.SetActive(false);
    }

}
