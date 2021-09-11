using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMover : MonoBehaviour
{
    private float movementX = 5;
    private float movementZ = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
    }
}
