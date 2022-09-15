# How to use
1) Import dotween asset to project from asset store
2) Add ProgressBarCanvas in Prefabs folder to hierarchy.
3) Optionally create progress percent text mesh pro and attach to progress bar controller 
4) Optionally create current value text mesh pro and attach to progress bar controller 
5) Use UpdateProgressBar for to update progress bar
6) Use ResetProgressBar for to reset progress bar
7) Use HideProgressBar for to hide progress bar

```		
            UpdateProgressBar(_currentValue,_maxValue);
            ResetProgressBar();
            HideProgressBar();
```
