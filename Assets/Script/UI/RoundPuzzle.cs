using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPuzzle : MonoBehaviour {

    public float stepRotation = 60f;
    public float rotateTime = 0.2f;
    public float startAngle;
    public float currentAngle;
	// Use this for initialization
	void Start () {
        //transform.rotation = Quaternion.Euler(0f, 0f, startAngle);
        currentAngle = startAngle;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("Round"));

            if (hit.collider!=null)
            {
                Debug.Log("Target Position: " + hit.collider.gameObject.name);
                hit.collider.transform.Rotate(new Vector3(0, 0, stepRotation/3));
            }
        }
        currentAngle = transform.rotation.eulerAngles.z;
    }
    public int GetAngle()
    {
        return (int)currentAngle;
    }

}
