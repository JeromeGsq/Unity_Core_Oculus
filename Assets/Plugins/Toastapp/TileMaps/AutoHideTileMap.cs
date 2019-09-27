using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoHideTileMap : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Tilemap>().color = new Color(0, 0, 0, 0);
    }
}
