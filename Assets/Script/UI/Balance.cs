using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour {

    public BalanceItem[] balanceItems;
    public int requiredValue;
    private bool isComplete;
    public Interactive interactive;
    public ChangeSize changeSize;
    void FixedUpdate()
    {
        CheckValue();
    }
    public void CheckValue()
    {
        if (null != balanceItems)
        {
            foreach(BalanceItem item in balanceItems)
            {
                if (item.value != requiredValue)
                {
                    return;
                }
            }
        }
        interactive.Activate();
        changeSize.Complete();
        Debug.Log("Complete");
    }

}
