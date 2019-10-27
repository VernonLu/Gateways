using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour {
    public RoundPuzzle[] items;
    public ChangeSize changeSize;
    public Interactive interactive;
	
	void Update () {
		foreach(RoundPuzzle item in items)
        {
            if(item.GetAngle() != 0)
            {
                return;
            }
        }
        interactive.Activate();
        changeSize.Complete();
    }
}
