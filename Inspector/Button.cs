using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace Common.Inspector
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!(attribute is ButtonAttribute buttonAttribute)) return;
            var target = property.serializedObject.targetObject;
            var type = target.GetType();
            var method = type.GetMethod(buttonAttribute.MethodName);
            
            if (method == null)
            {
                GUI.Label(position, "Method could not be found. Is it public?");
            }
            else if (method.GetParameters().Length > 0)
            {
                GUI.Label(position, "Method cannot have parameters."); ;
            }
            else if (GUI.Button(position, property.displayName))
            {
                method.Invoke(target, null);
            }
        }
    }
#endif

    public class ButtonAttribute : PropertyAttribute
    {
        public string MethodName { get; }

        public ButtonAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}
