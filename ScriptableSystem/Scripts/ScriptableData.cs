using System;
using UnityEngine;

namespace SKUtils.ScriptableSystem
{
    public abstract class ScriptableData : ScriptableObject
    {
        public Action OnValueUpdated;

        public abstract object DefaultValue { get; }
        public abstract object Value { get; set; }

        [Header("Save Settings")]
        [SerializeField] protected bool saveData;
        [SerializeField] protected string saveKey;
        private void OnValidate()
        {
            OnValueUpdated?.Invoke();
        }

        protected bool HasKey()
        {
            if (saveKey.Length <= 0)
            {
                Debug.LogError(" SaveKey is empty");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Save()
        {
            if (HasKey())
            {
                JsonSave<object>.SaveData(saveKey, Value);
            }
        }
        public abstract void Initialize();


        public void UpdateValue(object _value)
        {
            if (Value == _value) return;

            Value = _value;

            OnValueUpdated?.Invoke();

            if (saveData)
                Save();
        }

        public virtual void IncreaseValue(object _value) { }
        public virtual void DecreaseValue(object _value) { }
    }
}