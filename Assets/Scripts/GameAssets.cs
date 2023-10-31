using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    public Sprite pieceSprite;
    public Sprite [] tileColorSprite; //[0] Green [1] White 

    private void Awake()
    {
        //Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }
}
