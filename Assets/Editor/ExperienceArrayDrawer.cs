using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ExperienceArrayDrawer))]
public class ExperienceArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Получаем сериализованное свойство _maxLevel
        var maxLevelProperty = property.serializedObject.FindProperty("_maxLevel");

        if (maxLevelProperty != null)
        {
            int maxLevel = maxLevelProperty.intValue;

            // Показываем текущий лимит в label
            string newLabel = $"{label.text} (Max: {maxLevel})";
            EditorGUI.PropertyField(position, property, new GUIContent(newLabel), true);

            // Автоматически ограничиваем размер
            if (property.isArray && property.arraySize > maxLevel)
            {
                property.arraySize = maxLevel;
                property.serializedObject.ApplyModifiedProperties();
            }
        }
        else
        {
            // Стандартное отображение если не нашли _maxLevel
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}
