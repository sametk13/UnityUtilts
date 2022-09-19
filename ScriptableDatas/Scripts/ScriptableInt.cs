using System;
using UnityEngine;


namespace SKUtils.ScriptableSystem
{
    [CreateAssetMenu(menuName = "SkUtils/ScriptableData/ScriptableInt")]
    public class ScriptableInt : ScriptableData
    {
        public Action<int> OnValueIncreased;
        public Action<int> OnValueDecreased;

        [SerializeField] int minValue;
        [SerializeField] int maxValue;
        [SerializeField] int value;

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
                this.value = (int)value;
            }
        }

        public override object DefaultValue
        {
            get
            {
                return DefaultValue;
            }
        }

        public int GetValue()
        {
            return (int)value;
        }

        public override void IncreaseValue(object _value)
        {
            if (maxValue <= this.value + (int)_value)
            {
                OnValueIncreased?.Invoke(Mathf.Abs(maxValue - this.value));
                this.value = maxValue;
                UpdateValue(this.value);
                return;
            }
            OnValueIncreased?.Invoke((int)_value);
            this.value += (int)_value;
            UpdateValue(this.value);
        }

        public override void DecreaseValue(object _value)
        {
            if (minValue >= this.value - (int)_value)
            {
                this.value = minValue;
                OnValueDecreased?.Invoke(Mathf.Abs(this.value - minValue));
                UpdateValue(this.value);
                return;
            }
            OnValueDecreased?.Invoke((int)_value);
            this.value -= (int)_value;
            UpdateValue(this.value);
        }

        public override void Initialize()
        {
            if (saveData && HasKey())
            {
                var data = JsonSave<int>.LoadData(saveKey);
                UpdateValue(data);
            }
            else
                UpdateValue(DefaultValue);

        }
    }
}

