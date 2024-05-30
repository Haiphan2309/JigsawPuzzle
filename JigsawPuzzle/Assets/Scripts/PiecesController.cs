using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesController : MonoBehaviour
{
    [SerializeField] PuzzleInitTable puzzleInitTable;
    public List<PuzzlePiece> puzzlePieces = new List<PuzzlePiece>();
    // Start is called before the first frame update
    void Start()
    {
        puzzleInitTable.Suffer();
        StartCoroutine(Cor_Setup());
    }
    [Button]
    void SetupInfo()
    {
        puzzlePieces.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            PuzzlePiece puzzlePiece = transform.GetChild(i).GetComponent<PuzzlePiece>();
            puzzlePiece.Setup();
            puzzlePieces.Add(puzzlePiece);
        }
    }
    IEnumerator Cor_Setup()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector2 puzzleInitPos = puzzleInitTable.transform.GetChild(i).position;
            transform.GetChild(i).GetComponent<PuzzlePiece>().SetDefaultPos(puzzleInitPos);
            transform.GetChild(i).DOMove(puzzleInitPos,0.5f);
        }
    }
}
