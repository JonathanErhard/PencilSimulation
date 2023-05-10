using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polePlacement : Controller
{
    [SerializeField] private Rigidbody rbStift;
    [SerializeField] private float[] K;
    [SerializeField] private float[] B;
    void Start()
    {
        filter = GameObject.Find("Filter").GetComponent<FilterInterface2D>();
        rbCube = GameObject.Find("Cube").GetComponent<Rigidbody>();
        rbStift = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
        //B = new float[] { 0, 1, 0, 1 / rbStift.centerOfMass.y };
        //K = new float[] { 0, -0.1f, 10.7910f, -6.2832f }; 2m pencil
        K = new float[] { 0, -0.1f, 10.7910f, -2.1991f };
        x = new float[4];
        a = 0;
        //Debug.Log("L = " + rbStift.centerOfMass.y);
    }

    void Update()
    {
        u = K[0] * x[0] + K[1] * x[1] + K[2] * x[2] + K[3] * x[3];
    }
   
}
