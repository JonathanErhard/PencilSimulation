using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour,ControllerInterface2D
{
    [SerializeField] private Rigidbody rbCube;
    [SerializeField] private FilterInterface2D filter;
    [SerializeField] private float[] x;
    [SerializeField] private float u;

    public void publish(float u)
    {
        rbCube.velocity += new Vector3(u * Time.deltaTime, 0, 0);
    }
    public void updateState(float[] x)
    {

    }
}
