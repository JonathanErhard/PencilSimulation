using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankLQR2D : MonoBehaviour
{
    float degToRad = 0.01745329251f; // 1/180
    [SerializeField] private float t = 0.5f;
    [SerializeField] private float z, theta;
    [SerializeField] private float[] rlamda_R = { 1f, 1f, 0.1f, 0.01f }; //Reziprok der Eigenwerte von R (Aussage, welche Elemente des Statevectors wichtiger sind
    [SerializeField] private float p = 0.001f; //Aussage, wie agressiv gesteuert werden darf
    [SerializeField] private float[] B; //Wie geht unser controller in den statevector ein
    [SerializeField] private Rigidbody rbStift; //rb des Stifts (wird für x[] nicht verwendet, weil es irl auch nicht so wäre
    [SerializeField] private Rigidbody rbCube;
    [SerializeField] private float[] k; //"Matrix" K. 
    [SerializeField] private float a; //beschleunigung (ausgabe des lqr)
    [SerializeField] private float[] x;
    void Start()
    {
        rbStift = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
        rbCube = GameObject.Find("Cube").GetComponent<Rigidbody>();
        B = new float[] { 0, 1, 0, 1 / rbStift.centerOfMass.y };
        k = new float[4];
        x = new float[4];
        Debug.Log(B[3]);
        x[2] = rbStift.rotation.eulerAngles.z*degToRad;
        x[0] = rbCube.position.x;
    }
    private float[] naivCrossProduct(float[] v1, float[] v2)
    {
        //if(v1.Length != v2.Length)
        //    throw new exce ... i tust myself
        float[] ret = new float[v1.Length];
        for (int i = 0; i < v1.Length; i++)
            ret[i] = v1[i] * v2[i];
        return ret;
    }

    private float dotProduct(float[] v1, float[] v2)
    {
        float[] products = naivCrossProduct(v1, v2);
        float ret = 0;
        foreach (float p in products) ret += p;
        return ret;
    }
    // Update is called once per frame
    void Update()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
            setX();
        }
        else
        {
            /*k = naivCrossProduct(rlamda_R, B);
            setX();
            a = -dotProduct(k, x);
            publish(a);*/
            publish(1);
        }
    }

    public void publish(float a)
    {
        rbCube.velocity += new Vector3(a*Time.deltaTime, 0, 0);
    }

    private void setX()
    {

        x[3] = -rbStift.angularVelocity.z * degToRad;
        x[2] = -rbStift.rotation.eulerAngles.z * degToRad;
        x[1] = (z - rbCube.position.x) / Time.deltaTime;
        x[0] = rbCube.position.x;
        /*x[3] = (theta - rbStift.rotation.eulerAngles.z)*R2PI / Time.deltaTime;
        x[2] = rbStift.rotation.eulerAngles.z*R2PI;
        x[1] = (z - rbCube.position.x)/Time.deltaTime;
        x[0] = rbCube.position.x;*/
    }
}
