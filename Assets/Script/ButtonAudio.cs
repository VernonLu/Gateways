using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour , IPointerEnterHandler,IPointerClickHandler{

    public AudioClip enterClip;
    public AudioClip clickClip;
    public AudioSource source; 

    public void OnPointerEnter(PointerEventData eventData)
    {
        source.clip = enterClip;
        source.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        source.clip = clickClip;
        source.Play();
    }
}
