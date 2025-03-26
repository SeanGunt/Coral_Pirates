using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Utility instance;

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> GetListOfObjectsByScriptType(string scriptName)
    {
        Type scriptType = Type.GetType(scriptName);
        if (scriptType != null)
        {
            MonoBehaviour[] allScripts = FindObjectsOfType(scriptType) as MonoBehaviour[];

            // Filter for active objects
            List<GameObject> activeObjects = new List<GameObject>();
            foreach (MonoBehaviour script in allScripts)
            {
                activeObjects.Add(script.gameObject);
            }
            return activeObjects;
        }
        else
        {
            return null;
        }
    }
}
