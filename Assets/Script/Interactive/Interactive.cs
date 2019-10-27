using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour {
    public bool isActivated = false;
    public abstract void Activate();
}
