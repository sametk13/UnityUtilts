using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgressBar 
{
    public void UpdateProgressBar(float _currentValue, float _maxValue);

    public void ResetProgressBar();

    public void HideProgressBar();

}
