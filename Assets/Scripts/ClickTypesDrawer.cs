using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(ClickTypesAttribute))]
public class ClickTypesDrawer: PropertyDrawer {
    GUIContent[] clickTypes;
    int clickTypesIndex = -1;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if(clickTypesIndex == -1){
            getClickTypesArray(property);
        }

        int oldIndex = clickTypesIndex;
        clickTypesIndex = EditorGUI.Popup(position,label,clickTypesIndex,clickTypes);

        if(oldIndex != clickTypesIndex){
            property.stringValue = clickTypes[clickTypesIndex].text;
        }
    }

    private void getClickTypesArray(SerializedProperty property){
        clickTypes = new GUIContent[Enum.GetValues(typeof(ClickTypes)).Length];
        Array clickTypesArray = Enum.GetValues(typeof(ClickTypes));
        for(int i = 0;i < clickTypesArray.Length;++i){
            Debug.Log(clickTypesArray.GetValue(i));
            clickTypes[i] = new GUIContent(clickTypesArray.GetValue(i).ToString());
        }

        if(!string.IsNullOrEmpty(property.stringValue)){
            bool nameFound = false;

            for(int i = 0;i<clickTypes.Length;++i){
                if(clickTypes[i].text == property.stringValue){
                    clickTypesIndex = i;
                    nameFound = true;
                    break;
                }
            }

            if(nameFound == false){
                clickTypesIndex = 0;
            }

        }   
        else{
            clickTypesIndex = 0;
        }

        property.stringValue = clickTypes[clickTypesIndex].text;
    }
}