using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInitTable : MonoBehaviour
{
    public void Suffer()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            int rand = Random.Range(0, i);
            Transform tempChild = transform.GetChild(rand);
            transform.GetChild(i).SetSiblingIndex(rand);
            tempChild.SetSiblingIndex(i);
        }    
    }    
}
