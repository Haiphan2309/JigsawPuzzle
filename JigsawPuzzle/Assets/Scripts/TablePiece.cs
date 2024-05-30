using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePiece : MonoBehaviour
{
    public PuzzlePieceInfo info;
    public PuzzlePiece currentPiece;
    public void Setup()
    {
        info.id = transform.GetSiblingIndex();
        info.pieceId = GetComponent<SpriteRenderer>().sprite.ToString();
        info.rotateAngle = (int)transform.localRotation.eulerAngles.z;
    }
    public void SetCurrentPiece(PuzzlePiece piece)
    {
        currentPiece = piece;
    }
    public bool CheckMatchTrue()
    {
        if (currentPiece == null) return false;
        if (info.id == currentPiece.info.id) return true;
        return false;
    }
}
