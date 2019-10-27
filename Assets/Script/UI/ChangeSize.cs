using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSize : MonoBehaviour {

    public float smoothTime = 0.2f;
    public Vector3 largeScale;
    public Transform canvas;

    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private Vector3 largePosition;

    public GameObject particle;

    private bool isMax = false;
    private bool isComplete = false;
    public bool hideScreen;
	void Start () {
        defaultPosition = canvas.GetComponent<RectTransform>().position;
        defaultScale = canvas.GetComponent<RectTransform>().localScale;
    }
	
	// Update is called once per frame
	void Update () {
        if(isMax && Input.GetButtonDown("Cancel"))
        {
            SwitchView();
        }
	}

    private void SwitchView()
    {
        //Debug.Log("Switch");
        if (!isComplete)
        {
            if (isMax)
            {
                isMax = false;
                if (hideScreen)
                {
                    canvas.gameObject.SetActive(false);
                }
                iTween.MoveTo(canvas.gameObject, defaultPosition, smoothTime);
                iTween.ScaleTo(canvas.gameObject, defaultScale, smoothTime);
                canvas.GetComponent<Canvas>().sortingOrder = 1;
                Cursor.visible = false;
            }
            else
            {
                isMax = true;
                if (hideScreen)
                {
                    canvas.gameObject.SetActive(true);
                }
                //gameObject.GetComponent<RectTransform>().SetPositionAndRotation(largePosition, Quaternion.identity);
                largePosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0.0f);
                iTween.MoveTo(canvas.gameObject, largePosition, smoothTime);
                iTween.ScaleTo(canvas.gameObject, largeScale, smoothTime);
                canvas.GetComponent<Canvas>().sortingOrder = 10;
                Cursor.visible = true;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (isMax)
        {
            SwitchView();
        }
    }
    public void Show()
    {
        if (!isMax)
        {
            SwitchView();
        }
    }
    public void Hide()
    {
        if (isMax)
        {
            SwitchView();
        }
    }

    public void Complete()
    {
        if (isMax)
        {
            SwitchView();
            Destroy(particle);
            isComplete = true;
        }
    }
    public void SetMax()
    {
        isMax = true;
        canvas.localScale = largeScale;
    }


}
