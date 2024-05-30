using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table Instance { get; private set; }
    [SerializeField] float matchDistance;
    public List<TablePiece> tablePieces = new List<TablePiece>();
    public bool isWin;
    [SerializeField] PiecesController pieceController;
    [SerializeField] GameObject winObj;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            for(int i=0;i <tablePieces.Count-1; i++)
            {
                PuzzlePiece piece = pieceController.puzzlePieces[i];
                piece.transform.position = tablePieces[piece.info.id].transform.position;
                tablePieces[piece.info.id].SetCurrentPiece(piece);
            }
        }
    }
    [NaughtyAttributes.Button]
    void SetInfo()
    {
        tablePieces.Clear();
        for(int i=0;i<transform.childCount; i++)
        {
            TablePiece tablePiece = transform.GetChild(i).GetComponent<TablePiece>();
            tablePiece.Setup();
            tablePieces.Add(tablePiece);
        }
    }
    public TablePiece CheckMatch(Vector3 pos, PuzzlePieceInfo info, bool isCheckCurrent = false)
    {
        foreach(TablePiece tablePiece in tablePieces)
        {
            if (tablePiece.info.pieceId == info.pieceId && tablePiece.info.rotateAngle == info.rotateAngle && (tablePiece.transform.position - pos).magnitude < matchDistance)
            {
                if (isCheckCurrent)
                {
                    if (tablePiece.currentPiece == null)
                        return tablePiece;
                }
                else
                {
                    return tablePiece;
                }
                
            }
        }
        return null;
    }
    public void CheckWin()
    {
        foreach (TablePiece tablePiece in tablePieces)
        {
            if (tablePiece.CheckMatchTrue() == false) return;
        }
        isWin = true;
        winObj.SetActive(true);
    }
}
