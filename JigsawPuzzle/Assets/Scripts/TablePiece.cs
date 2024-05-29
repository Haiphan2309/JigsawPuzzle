using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePiece : MonoBehaviour
{
    public PuzzlePieceInfo info;
    public void Setup()
    {
        info.id = transform.GetSiblingIndex();
        info.pieceId = GetComponent<SpriteRenderer>().sprite.ToString();
        info.rotateAngle = (int)transform.localRotation.eulerAngles.z;
    }
}
