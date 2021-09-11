using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 30, 0f) * Time.deltaTime);
    }
}
