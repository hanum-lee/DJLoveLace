using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpin : MonoBehaviour
{
    Transform thisObj;
    public float rotationspeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        thisObj = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        thisObj.Rotate(0, Time.deltaTime * rotationspeed, 0, Space.World);
    }
}
