using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool teleports;
    [SerializeField] private GameObject teleportLocation;
    [SerializeField] private PolygonCollider2D nextCameraConfiner;
    [SerializeField] private int cameraPosIndex;
    [SerializeField] private float cameraXOffset;
    [SerializeField] private float cameraYOffset;
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
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
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
            //Debug.Log("Player moving to door");
            yield return null;
        }
        Debug.Log("Player Reached Door!");
        if (teleports)
        {
            float timeTillTeleport = 0.6f;
            GameManager.instance.transitionBackground.GetComponent<Animator>().SetTrigger("Transition");
            while (timeTillTeleport >= 0)
            {
                timeTillTeleport -= Time.deltaTime;
                yield return null;
            }
            player.GetComponent<PlayerPointClick>().WarpPlayer(TeleportPlayer());
            mainCamera.transform.position = new Vector3(CameraPositions.instance.positions[cameraPosIndex].position.x + cameraXOffset, CameraPositions.instance.positions[cameraPosIndex].position.y + cameraYOffset, -10f);
            CameraPositions.instance.confiner2D.m_BoundingShape2D = nextCameraConfiner;
        }
    }
}
