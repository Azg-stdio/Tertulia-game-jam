﻿using UnityEngine;
using System.Collections;
using UnityEditor;
[CanEditMultipleObjects]
[CustomEditor(typeof(XTweenRotationTransform))]
public class XTweenRotationTransformEditor : Editor 
{
	/// <summary>
	/// Changes the inspector
	/// </summary>
	public override void OnInspectorGUI ()
	{
		XTweenRotationTransform myTarget = (XTweenRotationTransform)target;
		
		myTarget.from = EditorGUILayout.Vector3Field("From", myTarget.from);
		myTarget.to = EditorGUILayout.Vector3Field("To", myTarget.to);

		myTarget.isLocal = EditorGUILayout.Toggle("is Local", myTarget.isLocal);

		DrawTweener(myTarget);
		EditorUtility.SetDirty(myTarget);
	}

	/// <summary>
	/// Tweener values that belong in the inspector
	/// </summary>
	public void DrawTweener(XTweenRotationTransform myTarget)
	{
		myTarget.playStyle =(XTweener.Style)EditorGUILayout.EnumPopup("Play Style", myTarget.playStyle);
		myTarget.animationCurve = 			EditorGUILayout.CurveField("Animationcurve", myTarget.animationCurve);
		myTarget.duration = 				EditorGUILayout.FloatField("Duration", myTarget.duration);
		myTarget.startDelay = 				EditorGUILayout.FloatField("Start Delay", myTarget.startDelay);
		myTarget.ignoreTimescale = 			EditorGUILayout.Toggle("Ignore Timescale", myTarget.ignoreTimescale);
	}
}
