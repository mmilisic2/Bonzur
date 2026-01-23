using UnityEngine;

public class IzlazIzInfoPanela : MonoBehaviour
{
    public GameObject infoPanel;
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}
