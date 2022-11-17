using UnityEngine;
using UnityEngine.Events;

namespace SKUtils.ScriptableSystem
{
    public class ScriptableActionSetter : MonoBehaviour
    {
        [SerializeField] UnityEvent unityAction;
        [SerializeField] ScriptableAction scriptableAction;

        private void OnEnable()
        {
            scriptableAction.ActionEvent.AddListener(CallAction); // Invoking unityAction when calling Scriptable Action
        }
        private void OnDisable()
        {
            scriptableAction.ActionEvent.RemoveListener(CallAction);
        }

        public void CallAction()
        {
            unityAction?.Invoke();
        }
    }
}
