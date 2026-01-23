using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PuzzleBozur[] pieces;
    public GameObject winText;

    void Start()
    {
        if(winText != null) winText.SetActive(false);
    }

    public void CheckVictory()
    {
        bool allCorrect = true;
        foreach (var piece in pieces)
        {
        if (!piece.isCorrect)
        {
            allCorrect = false;
            break;
        }
    }

        if (allCorrect)
        {
            if(winText != null) winText.SetActive(true);
        }
    }
}