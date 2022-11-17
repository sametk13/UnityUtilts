using UnityEditor;
using UnityEngine;

namespace SKUtils.ScriptableSystem
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ScriptableAction))]
    public class ScriptableActionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ScriptableAction action = (ScriptableAction)target; // Parsing out the value that has been transferred

            if (GUILayout.Button("Call Action")) // Turning the context menu 'call action' into a button
            {
                action.CallAction();
            }
        }
    }
#endif
}
