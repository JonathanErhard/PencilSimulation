using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class ControllerScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private GameObject player; //debugging
    [SerializeField] private GameObject pencil;
    [SerializeField] private SpawnPencil spawner;
    [SerializeField] private float p = 10;
    //[SerializeField] private bool hasSpawned = false;

    //[SerializeField] private float velocity = 10;
    UnityEngine.Quaternion q;
    public float v_x, v_z, v_y = 0; //vlt einfach in einem vector3d speichern? TODO

    private float adjustValues(float value) //veraltet
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
        /*UnityEngine.Quaternion p = new UnityEngine.Quaternion ( 0f, 0f, 1f, 0f );
        System.Numerics.Quaternion pS;
        q = pencil.transform.rotation;
        pS = System.Numerics.Quaternion.Multiply(new System.Numerics.Quaternion(q.x, q.y, q.z, q.w), new System.Numerics.Quaternion(p.x, p.y, p.z, p.w)); //TODO selber diese Methode implementieren, damit man nicht die ganze zeit Werte durch die Gegend kopiert.
        //p.w = pS.W;
        //p.x = pS.X;
        //p.y = pS.Y;
        //p.z = pS.Z;
        p = q * p * (new UnityEngine.Quaternion(-q.x, -q.y, -q.z, q.w));
        if(pS.X == p.x && pS.Y == p.y && pS.Z == p.z && pS.W == p.w)
        Debug.Log("war Gleich");
        rb.velocity = new UnityEngine.Vector3(v_x, v_y, v_z);*/
    }
}