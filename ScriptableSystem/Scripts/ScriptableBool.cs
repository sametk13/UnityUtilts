using System;
using UnityEngine;


namespace SKUtils.ScriptableSystem
{
    [CreateAssetMenu(menuName = "SkUtils/ScriptableData/ScriptableBool")]
    public class ScriptableBool : ScriptableData
    {
        [SerializeField] bool value;


        private void OnValidate()
        {
            OnValueUpdated?.Invoke();   
        }

        public override object Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = (bool)value;
            }
        }

        public override object DefaultValue
        {
            get
            {
                return DefaultValue;
            }
        }

        public bool GetValue()
        {
            return (bool)Value;
        }

        public override void Initialize()
        {
            if (saveData && HasKey())
            {
                var data = JsonSave<bool>.LoadData(saveKey);
                UpdateValue(data);
            }
            else
                UpdateValue(DefaultValue);

        }

    }
}

