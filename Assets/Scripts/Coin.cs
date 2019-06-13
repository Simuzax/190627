using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    float rotationSpeed = 180;
    float degrees = 90;

    // Use this for initialization
    void Start()
    {
        Vector3 to = new Vector3(degrees, 0, 0);

        transform.eulerAngles = to;
    }



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
    }
}
