using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinamachineConfiner2DFixed : CinemachineConfiner2D
{
    public Collider2D m_InitialBoundingShape2D;
    protected override void Awake()
    {
        base.Awake();
        m_BoundingShape2D = m_InitialBoundingShape2D;
    }
}
