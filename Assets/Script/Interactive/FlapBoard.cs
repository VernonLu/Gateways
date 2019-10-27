using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapBoard : Interactive {
    public Vector2 margin;
    public float moveTIme = 10f;
    public float delayTime = 0.5f;
    
    private bool isMovingUp = true;


	void Start () {
        isActivated = false;
	}
	
	void FixedUpdate () {
        
        if (isActivated)
        {
            if (transform.position.y>=margin.y && isMovingUp)
            {
                iTween.MoveTo(this.gameObject, iTween.Hash("y", margin.x, "time", moveTIme, "delay", delayTime, "EaseType", iTween.EaseType.linear));
                isMovingUp = false;
            }
            else if(transform.position.y<=margin.x && !isMovingUp)
            {
                iTween.MoveTo(this.gameObject, iTween.Hash("y", margin.y, "time", moveTIme, "delay", delayTime, "EaseType", iTween.EaseType.linear));
                isMovingUp = true;
            }
        }
	}
    public override void Activate()
    {
        isActivated = true;
        iTween.MoveTo(this.gameObject, iTween.Hash("y", margin.y, "time", moveTIme, "delay", delayTime, "EaseType", iTween.EaseType.linear));
    }
}
