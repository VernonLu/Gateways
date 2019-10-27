using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceItem : MonoBehaviour {

    public int value = 0;
    public int maxValue = 4;
    public BalanceItem[] affectItems;
    private Text text;

    public Image[] batteryImages;
    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(Affect);
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < maxValue; i++)
        {
            batteryImages[i].color = new Color(0, 0, 0, 0);
            if (i ==( value - 1)) 
            {
                batteryImages[i].color = new Color(255, 255, 255, 255);
            }
        }
    }
    private void AddValue()
    {
        value = (value + 1) % (maxValue + 1);
    }
    private void Affect()
    {
        for(int i = 0; i < affectItems.Length; i++)
        {
            affectItems[i].AddValue();
        }
    }
}
