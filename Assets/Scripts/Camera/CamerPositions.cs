using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    public static CameraPositions instance;
    public List<Vector3> positions = new List<Vector3>();

    public void Awake()
    {
        instance = this;
    }
}
