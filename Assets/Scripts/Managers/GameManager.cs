using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public GameObject player;
    [HideInInspector] public GameObject transitionBackground;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        transitionBackground = GameObject.FindGameObjectWithTag("TransitionBackground");
        transitionBackground.SetActive(true);
    }
}
