using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class BoardManager : MonoBehaviour
{
    #region CONSTANTS
    public const int BOARD_SIZE = 8;
    public const float BOARD_SPACING = 0.5f;
    #endregion
    [SerializeField] private List<BoardTile> tileList;


    public static BoardManager instance { get; private set;}

    private void Awake()
    {
        if (instance != null) {
            Debug.LogError("There is more than 1 instance of BoardManager");
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<BoardTile>();
        CreateBoard();
    }

    private void CreateBoard() {
        for (int y = 0; y < BOARD_SIZE; y++) {
                        
            for (int x = 0; x < BOARD_SIZE; x++) {
                
                CreateTile(GameAssets.Instance.tileColorSprite[(x+y)%2],new Vector2(x+BOARD_SPACING,y+BOARD_SPACING));
            }
        }
    }

    private GameObject CreateTile(Sprite spriteColor, Vector2 gridPos) {

        GameObject tileGameObject = new GameObject("Tile", typeof(SpriteRenderer), typeof(BoxCollider2D));
        SpriteRenderer tileSpriteRenderer = tileGameObject.GetComponent<SpriteRenderer>();
        tileSpriteRenderer.sortingOrder = -1;
        tileSpriteRenderer.sprite = spriteColor;
        BoxCollider2D tileCollider = tileGameObject.GetComponent<BoxCollider2D>();
        tileCollider.isTrigger = true;
        tileCollider.size = Vector2.one;

        tileGameObject.transform.position = gridPos;
        tileGameObject.transform.parent = gameObject.transform;

        BoardTile newTile = tileGameObject.AddComponent<BoardTile>();

        tileList.Add(newTile);
        return tileGameObject;
    }

    public bool IsTileBusy(Piece piece) {
        
        //We search the tile
        foreach (var tile in tileList)
        {
            //We found a free tile
            if ((tile.GetTileGridPosition() == piece.GetPieceGridPosition()) && !tile.IsBusy()){
                piece.Setup(tile);
                tile.SetTileBusy();
                return true;
            }
        }
        return false; //We dont found a free tile
        
    }
    
    public bool AllTilesBusy() {
        foreach (BoardTile tile in tileList) {
            if (!tile.IsBusy()) {
                return false;
            }
        }
        return true;
    }

    public void SetupAllTIles(Piece piece) {
        foreach (BoardTile tile in tileList)
        {
            tile.Setup(piece);
        }
    }
}
