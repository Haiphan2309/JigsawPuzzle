using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public PuzzlePieceInfo info;
    public void Setup()
    {
        info.id = transform.GetSiblingIndex();
        info.pieceId = GetComponent<SpriteRenderer>().sprite.ToString();
        info.rotateAngle = (int)transform.localRotation.eulerAngles.z;
    }
    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
    private void OnMouseUp()
    {
        TablePiece tablePiece = Table.Instance.CheckMatch(transform.position, info);
        if (tablePiece != null)
        {
            transform.position = tablePiece.transform.position;
        }
    }
}
[Serializable]
public struct PuzzlePieceInfo
{
    public int id;
    public string pieceId;
    public int rotateAngle;
}