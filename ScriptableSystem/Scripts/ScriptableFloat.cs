using System;
using UnityEngine;


namespace SKUtils.ScriptableSystem
{
    [CreateAssetMenu(menuName = "SkUtils/ScriptableData/ScriptableFloat")]
    public class ScriptableFloat : ScriptableData
    {
        public Action<float> OnValueIncreased;
        public Action<float> OnValueDecreased;

        [SerializeField] float minValue;
        [SerializeField] float maxValue;
        [SerializeField] float value;


        public override object Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = (float)value;
            }
        }

        public override object DefaultValue
        {
            get
            {
                return DefaultValue;
            }
        }

        public float GetValue()
        {
            return (float)Value;
        }

        public override void IncreaseValue(object _value)
        {
            if (maxValue <= this.value + (float)_value)
            {
                OnValueIncreased?.Invoke(Mathf.Abs(maxValue - this.value));
                this.value = maxValue;
                UpdateValue(this.value);
                return;
            }
            OnValueIncreased?.Invoke((float)_value);
            this.value += (float)_value;
            UpdateValue(this.value);
        }

        public override void DecreaseValue(object _value)
        {
            if (minValue >= this.value - (float)_value)
            {
                this.value = minValue;
                OnValueDecreased?.Invoke(Mathf.Abs(this.value - minValue));
                UpdateValue(this.value);
                return;
            }
            OnValueDecreased?.Invoke((float)_value);
            this.value -= (float)_value;
            UpdateValue(this.value);
        }

        public override void Initialize()
        {
            if (saveData && HasKey())
            {
                var data = JsonSave<float>.LoadData(saveKey);
                UpdateValue(data);
            }
            else
                UpdateValue(DefaultValue);

        }
    }
}

