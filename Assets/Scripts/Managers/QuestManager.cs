using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<SerializableDictionary<string, bool>> objectives = new List<SerializableDictionary<string, bool>>();
    private void Awake()
    {
        instance = this;
        SerializableDictionary<string, bool> ffPlacedDictionary = new SerializableDictionary<string, bool>()
        {
            {"FFPlaced", false}
        };
        objectives.Add(ffPlacedDictionary);
    }
}
