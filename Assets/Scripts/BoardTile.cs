using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardTile : MonoBehaviour
{
    private Vector2 tileGridPosition;
    private bool isBusy;
    private Piece piece;

    private void Awake()
    {
        this.tileGridPosition = transform.position;
        this.isBusy = true;
    }

    public bool IsBusy()
    {
        return this.isBusy;
    }

    public void SetTileBusy()
    {
        this.isBusy = true;
    }

    public void SetTileFree() {
        this.isBusy = false;
    }

    public Vector2 GetTileGridPosition()
    {
        return this.tileGridPosition;
    }

    public void Setup(Piece piece) {
        this.piece = piece;
    }

    private void OnMouseDown()
    {
        piece = GetComponent<Piece>();
        piece.MoveToPosition(this);
    }
}
