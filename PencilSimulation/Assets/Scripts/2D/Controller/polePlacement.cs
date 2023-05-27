using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polePlacement : Controller
{
    //[SerializeField] private Rigidbody rbStift;
    [SerializeField] private float[] K;
    //[SerializeField] private float[] B;
    [SerializeField] private float u;
    [SerializeField] private float[] x;
    [SerializeField] private float integral_count = 100;
    [SerializeField] private float integral_value;
    void Start()
    {
        initialize();
        //rbStift = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
        //B = new float[] { 0, 1, 0, 1 / rbStift.centerOfMass.y };
        K = new float[] { -0.2f, -0.0485f, 15.905f, -2.2352f }; //0 0 pi 0
        //K = new float[] { 0, 0.0483f, 33.2566f, -9.3029f }; //10 0 pi 0
        //K = new float[] { 0, -0.0244f, 10.8365f, -2.2171f }; //lambda = 0.5
        //K = new float[] { 0, -0.0724f, 10.9524f, -2.2534f }; //lambda = 1.5
        x = new float[4];
        u = 0;
        //Debug.Log("L = " + rbStift.centerOfMass.y);
    }
    float running_avg(float avg, float next_value)
    {
        avg += (next_value - avg) / 20;
        return avg;
    }

    void Update()
    {
        updateState(x);
        integral_value = running_avg(integral_value, x[2]);
        u = -(K[0] * x[0] + K[1] * x[1] + K[2] * x[2] + K[3] * x[3] + integral_value*0.0f);
        Debug.Log(x[0]+" u="+u);
        publish(u);
    }
   
}
