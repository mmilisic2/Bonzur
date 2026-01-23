using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform[] puzzlePieces;

    [SerializeField]
    private GameObject winText;

    public static bool isGameWon = false;

    void Start()
    {
        winText.SetActive(false);
        isGameWon = false;
    }

    void Update(){
        if (puzzlePieces[0].eulerAngles.z % 360 == 0 &&
            puzzlePieces[1].eulerAngles.z % 360 == 0 &&
            puzzlePieces[2].eulerAngles.z % 360 == 0 &&
            puzzlePieces[3].eulerAngles.z % 360 == 0 &&
            puzzlePieces[4].eulerAngles.z % 360 == 0 &&
            puzzlePieces[5].eulerAngles.z % 360 == 0 &&
            puzzlePieces[6].eulerAngles.z % 360 == 0 &&
            puzzlePieces[7].eulerAngles.z % 360 == 0 &&
            puzzlePieces[8].eulerAngles.z % 360 == 0)
        {
            if (!isGameWon)
            {
                isGameWon = true;
                winText.SetActive(true);
            }
        }
    }
}
