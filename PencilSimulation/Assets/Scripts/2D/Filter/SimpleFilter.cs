using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFilter : MonoBehaviour,FilterInterface2D
{
    private float phi,d_phi,z,d_z;
    private float degToRad = 0.01745329251f;
    private float twoPi = Mathf.PI*2;
    private float pi = Mathf.PI;
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
        return z;
    }

    public float getD_z()
    {
        return d_z;
    }

    void Start()
    {
        rb = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
    }

    float selectivlyBreed(float ang)
    {
        return ang < pi ? ang : ang - twoPi;
    }

    void Update()
    {
        //d_phi = (phi - rb.rotation.eulerAngles.z) / Time.deltaTime*degToRad; //funktioniert nicht ):
        d_phi = rb.angularVelocity.z*degToRad;
        phi = selectivlyBreed(rb.rotation.eulerAngles.z* degToRad);
        //d_z = (z-rb.position.z) / Time.deltaTime;
        d_z = rb.velocity.x;
        z = rb.position.x;
    }
}
