using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPositions : MonoBehaviour
{
    public static CameraPositions instance;
    public CinemachineConfiner2D confiner2D;
    public List<Transform> positions = new List<Transform>();

    public void Awake()
    {
        instance = this;
    }
}
