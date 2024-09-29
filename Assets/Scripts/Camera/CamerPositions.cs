using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    public static CameraPositions instance;
    public List<Transform> positions = new List<Transform>();

    public void Awake()
    {
        instance = this;
    }
}
