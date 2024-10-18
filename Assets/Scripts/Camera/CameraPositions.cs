using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPositions : MonoBehaviour
{
    public static CameraPositions instance;
    public CinamachineConfiner2DFixed confiner2D;
    public List<Transform> positions = new List<Transform>();

    public void Awake()
    {
        instance = this;
    }
}
