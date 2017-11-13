using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ExInt))]
public class ExIntDrawer : PropertyDrawer
{
    //float valuePercent = 100;
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var baseRect = new Rect(position.x + position.width * 0.5f, position.y, position.width*0.5f, position.height);
        var actualRect = new Rect(position.x , position.y, position.width * 0.5f, position.height);
        //var sliderRect = new Rect(position.x + position.width * 0.25f, position.y, position.width * 0.25f, position.height);
        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(baseRect, property.FindPropertyRelative("baseValue"), GUIContent.none);
        //valuePercent = EditorGUI.Slider(sliderRect, valuePercent, 0, 100);
        if (EditorGUI.EndChangeCheck())
        {
            //float dividedValue = property.FindPropertyRelative("baseValue").intValue * (valuePercent * 0.01f);
            //property.FindPropertyRelative("varValue").intValue = Mathf.RoundToInt(dividedValue);
            property.FindPropertyRelative("varValue").intValue = property.FindPropertyRelative("baseValue").intValue;
        }
        EditorGUI.LabelField(actualRect,property.FindPropertyRelative("varValue").intValue+"");
        //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("varValue"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(ExFloat))]
public class ExFloatDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var baseRect = new Rect(position.x + position.width * 0.5f, position.y, position.width * 0.5f, position.height);
        var actualRect = new Rect(position.x, position.y, position.width * 0.5f, position.height);
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(baseRect, property.FindPropertyRelative("baseValue"), GUIContent.none);
        //valuePercent = EditorGUI.Slider(sliderRect, valuePercent, 0, 100);
        if (EditorGUI.EndChangeCheck())
        {
            property.FindPropertyRelative("varValue").floatValue = property.FindPropertyRelative("baseValue").floatValue;
        }
        EditorGUI.LabelField(actualRect, property.FindPropertyRelative("varValue").floatValue + "");
        //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("varValue"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}