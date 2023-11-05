using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardTile
{
    private Vector2 tileGridPosition;
    private bool isBusy;
    private GameObject tileGameObject;

    public BoardTile(Vector2 tileGridPosition, Sprite sprite)
    {
        tileGameObject = new GameObject("Tile", typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Rigidbody2D));
        SpriteRenderer tileSpriteRenderer = tileGameObject.GetComponent<SpriteRenderer>();
        tileSpriteRenderer.sortingOrder = -1;
        tileSpriteRenderer.sprite = sprite;
        BoxCollider2D tileCollider = tileGameObject.GetComponent<BoxCollider2D>();
        tileCollider.isTrigger = true;
        tileCollider.size = Vector2.one;
        tileGameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        tileGameObject.transform.position = tileGridPosition;
        this.tileGridPosition = tileGridPosition;
        this.isBusy = false;
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

    public void SetParent(Transform parent)
    {
        tileGameObject.transform.parent = parent;
    }
}
