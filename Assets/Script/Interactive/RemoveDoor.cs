using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDoor : Interactive {
    
    public override void Activate()
    {
        gameObject.SetActive(false);
    }
}
