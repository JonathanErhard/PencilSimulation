using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private GameObject player; //debugging
    [SerializeField] private GameObject pencil;
    [SerializeField] private SpawnPencil spawner;
    //[SerializeField] private bool hasSpawned = false;

    //[SerializeField] private float velocity = 10;
    Vector3 euler;
    public float v_x, v_z, v_y = 0; //vlt einfach in einem vector3d speichern? TODO

    private float adjustValues(float value)
    {
        if (value > 180) value = value - 360;
        return value;
    }
    void Start()
    {
        //while (!hasSpawned) hasSpawned = spawner.hasSpawned
        pencil = GameObject.Find("pencil Variant(Clone)"); 
        player = GameObject.Find("Cube"); // only for debugging
        rb = GameObject.Find("Cube").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        euler = pencil.transform.rotation.eulerAngles;
        v_x = euler.y;
        v_y = euler.x;
        v_x = 10*adjustValues(v_x);
        v_y = 10*adjustValues(v_y);
        rb.velocity = new Vector3(v_x, v_y, v_z);
    }
}