using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ReSpawn1))]
public class PlaceRe : Editor
{
    private void OnSceneGUI()
    {
        ReSpawn1 a = (ReSpawn1)target;
        
        a.Respawn_point = Handles.PositionHandle(a.Respawn_point,Quaternion.identity);


    }
}
