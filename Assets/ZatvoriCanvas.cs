using UnityEngine;

public class ZatvoriCanvas : MonoBehaviour
{
    public GameObject canvasObj;
    public void Zatvori()
    {
        if(canvasObj != null)
        {
            canvasObj.SetActive(false);
        }
    }
}
