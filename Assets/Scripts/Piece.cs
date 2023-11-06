using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piece
{
    private Vector2 pieceGridPosition;
    private GameObject pieceGameObject;
    private List<Vector2> availableMoveList = new List<Vector2>();
    private BoardTile currentTile;

    public Piece() {
        SpawnPiece();
    }

    public void SpawnPiece(){
        //Search for an free tile
        do
        {
            pieceGridPosition = SpawnRandomGridPosition();
        } while (!BoardManager.instance.IsTileBusy(this));

        //Spawn object in the free tile
        pieceGameObject = new GameObject("Piece");
        SpriteRenderer foodSpriteRenderer = pieceGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.pieceSprite;
        pieceGameObject.transform.position = new Vector3(pieceGridPosition.x, pieceGridPosition.y, 0);
    }

    private Vector2 SpawnRandomGridPosition() {
        return new Vector2(Random.Range(0,BoardManager.BOARD_SIZE) + BoardManager.BOARD_SPACING, Random.Range(0,BoardManager.BOARD_SIZE)+BoardManager.BOARD_SPACING);
    }

    public Vector2 GetPieceGridPosition() {
        return pieceGridPosition;
    }

    public void MoveToPosition(BoardTile tile) {

        if (IsValidMove(tile.GetTileGridPosition()) ){
            currentTile.SetTileFree(); //previous tile set free
            
            pieceGridPosition = tile.GetTileGridPosition();
            pieceGameObject.transform.position = pieceGridPosition;
            
            currentTile = tile;
            currentTile.SetTileBusy();
        }
    }

    private bool IsValidMove(Vector2 gridPosition)
    {
        //Queen valid moves = same row || same column || diagonal move
        if (gridPosition.x == pieceGridPosition.x || gridPosition.y == pieceGridPosition.y || (Mathf.Abs(gridPosition.x-pieceGridPosition.x)== Mathf.Abs(gridPosition.y - pieceGridPosition.y))) {
            return true;
        }
        return false;
    }

    public void Setup(BoardTile tile) {
        this.currentTile = tile;
    }
}
