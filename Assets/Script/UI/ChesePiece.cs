using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChesePiece : MonoBehaviour {

    public ChesePiece[] affectedPieces;
    public Sprite[] sprite;
    public int value = 0;

	void Start () {
        GetComponent<Button>().onClick.AddListener(Affect);
	}
    void Update()
    {
        GetComponent<Image>().sprite = sprite[value];
    }

    public void ChangeValue() {
        value = 1 - value;
    }
    public void Affect()
    {
        foreach(ChesePiece piece in affectedPieces) { piece.ChangeValue(); }
    }

}
