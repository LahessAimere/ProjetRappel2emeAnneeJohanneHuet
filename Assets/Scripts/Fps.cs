using System;
using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour
{
    private float count;
    private GUIStyle guiStyle = new GUIStyle();

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    private void OnGUI()
    {
        guiStyle.fontSize = 100;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(5, 40, 100, 25), "FPS: " + Mathf.Round(count), guiStyle);
    }
}
