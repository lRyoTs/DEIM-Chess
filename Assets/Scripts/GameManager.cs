using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    public const int upLimit = 8;
    public const int downLimit = 0;
    public const int leftLimit = 0;
    public const int rightLimit = 8;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than 1 instances of Game Manager");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        Piece piece = new Piece();
    }

    private void OnMouseDown()
    {
       
    }
}
