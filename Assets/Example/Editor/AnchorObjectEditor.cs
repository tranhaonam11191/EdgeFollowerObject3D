using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(AnchorObject))]
public class AnchorObjectEditor : Editor
{    
    public override void OnInspectorGUI()
    {        
        base.OnInspectorGUI();
        AnchorObject m_AnchorObject = (AnchorObject)target;
        if (GUILayout.Button("Set offset with rectTransform"))
        {
            m_AnchorObject.SetLocalPointRefToObject();
        }
    }
}
