using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LQR2D : MonoBehaviour
{
    [SerializeField] private FilterInterface2D filter;
    [SerializeField] private float[] rlamda_R = { 1f, 1f ,0.1f,0.01f}; //Reziprok der Eigenwerte von R (Aussage, welche Elemente des Statevectors wichtiger sind
    [SerializeField] private float p = 1; //Aussage, wie agressiv gesteuert werden darf
    [SerializeField] private float[] B; //Wie geht unser controller in den statevector ein
    [SerializeField] private Rigidbody rbStift; //rb des Stifts (wird für x[] nicht verwendet, weil es irl auch nicht so wäre
    [SerializeField] private Rigidbody rbCube;
    [SerializeField] private float[] k; //"Matrix" K. 
    [SerializeField] private float a; //beschleunigung (ausgabe des lqr)
    [SerializeField] private float[] x;
    void Start()
    {
        filter = GameObject.Find("Filter").GetComponent<FilterInterface2D>();
        rbStift = GameObject.Find("pencil Variant(Clone)").GetComponent<Rigidbody>();
        rbCube = GameObject.Find("Cube").GetComponent<Rigidbody>();
        B = new float[] { 0, 1, 0, 1 /rbStift.position.y};
        k = new float[4];
        x = new float[4];
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

    private float dotProduct(float[] v1,float[] v2)
    {
        float[] products = naivCrossProduct(v1, v2);
        float ret = 0;
        foreach (float p in products) ret += p;
        return ret;
    }
    // Update is called once per frame
    void Update()
    {
        k = naivCrossProduct(rlamda_R, B);
        setX();
        a = -dotProduct(k, x);
        publish(a);
    }

    private void publish(float a)
    {
        rbCube.velocity += new Vector3(0,0,a)*Time.deltaTime;
    }

    private void setX()
    {
        x[0] = filter.getZ();
        x[1] = filter.getD_z();
        x[2] = filter.getPhi();
        x[3] = filter.getD_phi();
    }
}
