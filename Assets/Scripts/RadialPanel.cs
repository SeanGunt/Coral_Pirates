using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class RadialPanel : MonoBehaviour
{
    public GameObject radialPanel;
    private Vector3 panelScale = new Vector3(1f, 1f, 1f);

    

    public void Start()
    {
        //HidePanel();
        //radialPanel.SetActive(false);
        //radialPanel.SetActive(true);
        ShowPanel();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPanel()
    {
        radialPanel.SetActive(true);
        
        // Convert mouse position to world space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // Adjust the depth to be in front of the camera
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Offset the Y position
        worldMousePos.y += 3f; // Adjust the offset as needed

        // Set the position of the radial panel to the converted mouse position
        radialPanel.transform.position = worldMousePos;

        // Show the interaction panel with Dotween animation
        //
        radialPanel.transform.localScale = Vector3.zero;
        radialPanel.transform.DOScale(panelScale, 0.3f).SetEase(Ease.OutBack);
    }

    public void HidePanel()
    {
        radialPanel.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() => radialPanel.SetActive(false));
    }

    
}


   
