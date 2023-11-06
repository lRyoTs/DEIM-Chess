using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    private Piece piece;
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
        //piece = new Piece();
    }
}
