using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public RectTransform spawnArea; 
    public GameObject objectToSpawn; 
    public RectTransform parentObject; 

    public void SpawnObjects()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            // Random position within the spawn area's local space
            float x = Random.Range(0, spawnArea.rect.width);
            float y = Random.Range(0, spawnArea.rect.height);
            Vector2 localPos = new Vector2(x, y);

            // Convert local position to world position
            Vector2 worldPos = spawnArea.TransformPoint(localPos);

            // Instantiate the object and set it as a child of the parentObject
            GameObject obj = Instantiate(objectToSpawn, worldPos, Quaternion.identity, parentObject);
            
            // Optionally reset local position (useful for consistent placement)
            obj.GetComponent<RectTransform>().anchoredPosition = localPos;
            Debug.Log("Spawned at: " + localPos + " inside area: " + spawnArea.rect);
        }
    }
}
