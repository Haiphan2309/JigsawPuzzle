using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public PuzzlePieceInfo info;
    [SerializeField] Vector2 defaultPos;
    public void SetDefaultPos(Vector2 pos)
    {
        defaultPos = pos;
    }
    public void Setup()
    {
        info.id = transform.GetSiblingIndex();
        info.pieceId = GetComponent<SpriteRenderer>().sprite.ToString();
        info.rotateAngle = (int)transform.localRotation.eulerAngles.z;
    }
    private void OnMouseDown()
    {
        TablePiece tablePiece = Table.Instance.CheckMatch(transform.position, info, false);
        if (tablePiece != null)
        {
            tablePiece.SetCurrentPiece(null);
        }
    }
    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
    private void OnMouseUp()
    {
        TablePiece tablePiece = Table.Instance.CheckMatch(transform.position, info, true);
        if (tablePiece != null)
        {
            transform.position = tablePiece.transform.position;
            tablePiece.SetCurrentPiece(this);
            Table.Instance.CheckWin();
        }
        else
        {
            transform.DOMove(defaultPos, 0.5f);
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