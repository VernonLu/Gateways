using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenFloor : Interactive {

    public float rotateTime = 1f;
    public float laserLength;
    public Transform generator;
    public Transform target;
    private LineRenderer laser;

    public Material laserMat;
    public Color laserColor;
    public float laserWidth;

    public Interactive addDoor;
	// Use this for initialization
	void Start ()
    {
        laser = GetComponentInChildren<LineRenderer>();
        isActivated = false;
	}
	
    public override void Activate()
    {
        iTween.RotateTo(this.gameObject, new Vector3(0, 0, 180f), rotateTime);
        StartCoroutine("CastLaser");
    }

    IEnumerator CastLaser()
    {
        yield return new WaitForSeconds(rotateTime);
        addDoor.Activate();
        //Debug.Log("Draw");
        //设置材质  
        laser.material = new Material(Shader.Find("Particles/Additive"));
        //laser.material = laserMat;
        //设置颜色  
        laser.startColor = laserColor;
        laser.endColor = laserColor;
        //设置宽度  
        laser.startWidth = laserWidth;
        laser.endWidth = laserWidth;
        laser.SetPosition(0, generator.position);
        laser.SetPosition(1, target.position);
    }
    
}
