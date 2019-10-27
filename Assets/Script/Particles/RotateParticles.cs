using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParticles : MonoBehaviour {

    private float magicParticlesRotation = 10.0f;
    public float mprSpeed = 1.75f;

	void Update () {
        transform.Rotate(0, mprSpeed, 0 * magicParticlesRotation * Time.deltaTime, 0);
    }
}
