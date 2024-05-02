using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class RadialPanel : MonoBehaviour
{
    public GameObject radialPanel;
    private Vector3 panelScale = new Vector3(1f, 1f, 0f);

    private void Awake()
    {
        //HidePanel();
        //radialPanel.SetActive(false);
        //radialPanel.SetActive(true);
        ShowPanel();    
    }

    public void ShowPanel()
    {
        radialPanel.SetActive(true);
        
        // Convert mouse position to world space
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Offset the Y position
        worldMousePos.y += 3f; // Adjust the offset as needed

        // Show the interaction panel with Dotween animation
        radialPanel.transform.localScale = Vector3.zero;
        radialPanel.transform.DOScale(panelScale, 0.3f).SetEase(Ease.OutBack);

        // Set the position of the radial panel to the converted mouse position
        radialPanel.transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0f);
    }

    public void HidePanel()
    {
        radialPanel.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() => radialPanel.SetActive(false));
    }
}


   
