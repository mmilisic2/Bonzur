using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideButtonScript : MonoBehaviour
{
    public GameObject infoPanel;
    public void OtvoriInfoPanel()
    {
        infoPanel.SetActive(true);
    }
    public void goBack(){
        SceneManager.LoadScene("SampleScene");
    }
}
