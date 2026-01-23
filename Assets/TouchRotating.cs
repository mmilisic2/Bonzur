using UnityEngine;
using UnityEngine.EventSystems;

public class TouchRotating : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameController.isGameWon){
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
