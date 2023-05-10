using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFilter : MonoBehaviour,FilterInterface2D
{
    private float phi,d_phi,z,d_z;
    Rigidbody rb;
    public float getPhi()
    {
        return phi;
    }

    public float getD_phi()
    {
        return d_phi;
    }

    public float getZ()
    {
        return getZ();
    }

    public float getD_z()
    {
        return d_z;
    }

    void Start()
    {
        rb = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
    }

    void Update()
    {
        d_phi = (phi - rb.rotation.eulerAngles.z) / Time.deltaTime;
        phi = rb.rotation.eulerAngles.z;
        d_z = (z-rb.position.z) / Time.deltaTime;
        z = rb.position.z;
    }
}
