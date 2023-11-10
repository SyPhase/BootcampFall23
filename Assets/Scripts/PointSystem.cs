using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] GUIStyle _pointStyle;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), _score.ToString(), _pointStyle);
    }

    public void AddPoint()
    {
        _score++;
    }
}