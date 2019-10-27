using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chese : MonoBehaviour {
    private ChesePiece[] pieces;
    public Interactive interactive;
    public int requiredValue;
    public ChangeSize changeSize;
	// Use this for initialization
	void Start () {
        pieces = GetComponentsInChildren<ChesePiece>();
        Debug.Log(pieces.Length);
	}
	
	// Update is called once per frame
	void Update () {
        CheckValue();
	}

    private void CheckValue()
    {
        foreach(ChesePiece piece in pieces) { if (piece.value != requiredValue) { return; } }
        interactive.Activate();
        changeSize.Complete();
    }
}
