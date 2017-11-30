using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisTools : EditorWindow
{
    [MenuItem("ChrisTools/Remove Components Window")]
    public static void Init()
    {
        var window = (ChrisTools)GetWindow(typeof(ChrisTools));
        window.Show();

    }
    void OnGUI()
    {
        var clicked = GUILayout.Button("Click Me!");
        if (clicked)
        {
            Debug.ClearDeveloperConsole();
            Debug.Log("You clicked the button!");
        }
    }
}