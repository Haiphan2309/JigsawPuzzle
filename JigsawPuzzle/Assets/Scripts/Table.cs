using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table Instance { get; private set; }
    [SerializeField] float matchDistance;
    public List<TablePiece> tablePieces = new List<TablePiece>();
    private void Awake()
    {
        Instance = this;
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
    public TablePiece CheckMatch(Vector3 pos, PuzzlePieceInfo info)
    {
        foreach(TablePiece tablePiece in tablePieces)
        {
            if (tablePiece.info.pieceId == info.pieceId && tablePiece.info.rotateAngle == info.rotateAngle && (tablePiece.transform.position - pos).magnitude < matchDistance)
                return tablePiece;
        }
        return null;
    }
}
