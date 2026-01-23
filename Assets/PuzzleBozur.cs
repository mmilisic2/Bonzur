using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleBozur : MonoBehaviour, IPointerClickHandler
{
    private float[] possibleRotations = { 0, 90, 180, 270 };
    public bool isCorrect = false;

    void Start()
    {
        // random rotacije na pocetku
        int randomIndex = Random.Range(1, possibleRotations.Length);
        transform.eulerAngles = new Vector3(0, 0, possibleRotations[randomIndex]);
        
        CheckIfCorrect();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // svaki klik rotira za 90 stepeni
        transform.Rotate(0, 0, 90);
        CheckIfCorrect();
    }

    void CheckIfCorrect()
    {
        if (Mathf.Abs(transform.eulerAngles.z) < 0.1f)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
        FindObjectOfType<GameManager>()?.CheckVictory();
    }
}