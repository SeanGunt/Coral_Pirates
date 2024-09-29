using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool teleports;
    [SerializeField] private GameObject teleportLocation;
    [SerializeField] private int camerPosIndex;
    private GameObject player;
    private Camera mainCamera;
    private float distanceToPlayer;
    private bool closeToDoor;

    private void Start()
    {
        mainCamera = Camera.main;
        player = GameManager.instance.player;
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);
        if (distanceToPlayer <= 5f)
        {
            closeToDoor = true;
        }
        else
        {
            closeToDoor = false;
        }
    }

    public void OnDoorClick()
    {
        StartCoroutine(TestNumerator());
    }

    private Vector3 TeleportPlayer()
    {
        return teleportLocation.transform.position;
    }

    private IEnumerator TestNumerator()
    {
        while (!closeToDoor)
        {
            Debug.Log("Player moving to door");
            yield return null;
        }
        Debug.Log("Player Reached Door!");
        if (teleports)
        {
            player.GetComponent<PlayerPointClick>().WarpPlayer(TeleportPlayer());
            mainCamera.transform.position = new Vector3(CameraPositions.instance.positions[camerPosIndex].position.x, CameraPositions.instance.positions[camerPosIndex].position.y, -10f);
        }
    }
}
