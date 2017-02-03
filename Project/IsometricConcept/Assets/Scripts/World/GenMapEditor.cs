using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapGen))]
public class GenMapEditor : Editor {

    public override void OnInspectorGUI(){
        MapGen mapG = (MapGen)target;

        if (DrawDefaultInspector ()){
            if (mapG.autoUpdate){
                mapG.GenAllMap();
            }
        }

        if (GUILayout.Button("Generate")){
            mapG.GenAllMap();
        }
    }
}
