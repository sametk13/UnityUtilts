# How To Use
1) Add JsonSaveSystem from this repo.
2) Add ScriptableInitializer prefab to hierarchy.
3) Create SkUtils/ScriptableSystem/...
4) If you want to save set Save Data and Save Key.

# Example
```
        ScriptableFloat scriptableValue;

        scriptableValue.IncreaseValue(1f);
        scriptableValue.DecreaseValue(1f);
        var _value = scriptableValue.GetValue();

        scriptableValue.OnValueUpdated += Updated;
        scriptableValue.OnValueIncreased += Increased;
        scriptableValue.OnValueDecreased += Decreased;			
```
