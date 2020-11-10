using UnityEngine;
using System.Collections;
using UnityEditor;
[CanEditMultipleObjects]
[CustomEditor(typeof(XTweenText))]
public class XTweenTextEditor : Editor {
    /// <summary>
    /// Changes the inspector
    /// </summary>
    public override void OnInspectorGUI() {
        XTweenText myTarget = (XTweenText)target;

        var serializedObject = new SerializedObject(myTarget);
        var property = serializedObject.FindProperty("values");
        serializedObject.Update();
        EditorGUILayout.PropertyField(property, true);
        serializedObject.ApplyModifiedProperties();

        DrawTweener(myTarget);
    }

    /// <summary>
    /// Tweener values that belong in the inspector
    /// </summary>
    public void DrawTweener(XTweenText myTarget) {
        myTarget.playStyle = (XTweener.Style)EditorGUILayout.EnumPopup("Play Style", myTarget.playStyle);
        myTarget.animationCurve = EditorGUILayout.CurveField("Animationcurve", myTarget.animationCurve);
        myTarget.duration = EditorGUILayout.FloatField("Duration", myTarget.duration);
        myTarget.startDelay = EditorGUILayout.FloatField("Start Delay", myTarget.startDelay);
        myTarget.ignoreTimescale = EditorGUILayout.Toggle("Ignore Timescale", myTarget.ignoreTimescale);
    }
}