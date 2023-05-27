using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour,ControllerInterface2D
{
    [SerializeField] private Rigidbody rbCube;
    [SerializeField] private FilterInterface2D filter;
    public void initialize()
    {
        filter = GameObject.Find("Filter").GetComponent<FilterInterface2D>();
        rbCube = GameObject.Find("Cube").GetComponent<Rigidbody>();
    }
    public void publish(float u)
    {
        rbCube.velocity += new Vector3(u*Time.deltaTime, 0, 0);
        Debug.Log(rbCube.velocity.x);
    }
    public void updateState(float[] x)
    {
        x[0] = filter.getZ();
        x[1] = filter.getD_z();
        x[2] = filter.getPhi();
        x[3] = filter.getD_phi();
    }
}
