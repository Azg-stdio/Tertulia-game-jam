using UnityEngine;
using System.Collections;
using UnityEditor;
[CanEditMultipleObjects]
[CustomEditor(typeof(XTweenRectPosition))]
public class XTweenRectPositionEditor : Editor 
{
	/// <summary>
	/// Changes the inspector
	/// </summary>
	public override void OnInspectorGUI ()
	{
		XTweenRectPosition myTarget = (XTweenRectPosition)target;
		
		myTarget.minFrom = EditorGUILayout.Vector2Field("Min From", myTarget.minFrom);
		myTarget.maxFrom = EditorGUILayout.Vector2Field("Max From", myTarget.maxFrom);
		myTarget.minTo = EditorGUILayout.Vector2Field("Min To", myTarget.minTo);
		myTarget.maxTo = EditorGUILayout.Vector2Field("Max To", myTarget.maxTo);
		
		DrawTweener(myTarget);
	}

	/// <summary>
	/// Tweener values that belong in the inspector
	/// </summary>
	public void DrawTweener(XTweenRectPosition myTarget)
	{
		myTarget.playStyle =(XTweener.Style)EditorGUILayout.EnumPopup("Play Style", myTarget.playStyle);
		myTarget.animationCurve = 			EditorGUILayout.CurveField("Animationcurve", myTarget.animationCurve);
		myTarget.duration = 				EditorGUILayout.FloatField("Duration", myTarget.duration);
		myTarget.startDelay = 				EditorGUILayout.FloatField("Start Delay", myTarget.startDelay);
		myTarget.ignoreTimescale = 			EditorGUILayout.Toggle("Ignore Timescale", myTarget.ignoreTimescale);
	}
}
