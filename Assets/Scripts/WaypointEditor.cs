// using UnityEngine;
// using UnityEditor;
// using System.Collections;
// using System.Collections.Generic;
//
// [CustomEditor(typeof(Waypoint))]
//
// public class WaypointEditor: Editor
// {
//     // Start is called before the first frame update
//    Waypoint Waypoint => target as Waypoint;
//    private void OnSceneGUI()
//    {
//     Handles.color = Color.green;
//     for (int i = 0; i < Waypoint.Points.Length;i++)
//     {
//         EditorGUI.BeginChangeCheck();
//
//         //Create Handles
//         Vector3 currentWaypointPoint = Waypoint.CurrentPosition + Waypoint.Points[i];
//         Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint,Quaternion.identity,0.5f,
//         new Vector3(0.3f,0.3f,0.3f),Handles.SphereHandleCap);
//
//
//         //Create Text
//         GUIStyle textStyle = new GUIStyle();
//         textStyle.fontStyle = FontStyle.Bold;
//         textStyle.fontSize = 16;
//         textStyle.normal.textColor = Color.white;
//         Vector3 textAlignment = Vector3.down * 0.35f + Vector3.right * 0.35f;
//         Handles.Label(Waypoint.CurrentPosition + Waypoint.Points[i] + textAlignment, $"{i + 1}",textStyle);
//
//         EditorGUI.EndChangeCheck();
//
//         if (EditorGUI.EndChangeCheck())
//         {
//             Undo.RecordObject(target,"Move Waypoint");
//             Waypoint.Points[i] = newWaypointPoint - Waypoint.CurrentPosition;
//
//         }
//     }
//    }
// }
