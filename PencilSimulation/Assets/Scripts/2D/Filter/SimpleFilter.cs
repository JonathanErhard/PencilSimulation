using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFilter : MonoBehaviour
{
    private float phi;
    Rigidbody rb;
    public float getPhi()
    {
        return phi;
    }

    

    void Start()
    {
        rb = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
    }

    void Update()
    {
        phi = rb.rotation.eulerAngles.z;
    }
}
