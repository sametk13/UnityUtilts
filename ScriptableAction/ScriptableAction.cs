using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SKUtils.ScriptableSystem
{
    [CreateAssetMenu(menuName = "SkUtils/ScriptableSystem/ScriptableAction")]
    public class ScriptableAction : ScriptableObject
    {
        [ReadOnly] public UnityEvent ActionEvent;

        [ContextMenu("Call Action")] // Utilised to create a button
        public void CallAction() 
        {
            ActionEvent?.Invoke(); 
        }
    } 
}