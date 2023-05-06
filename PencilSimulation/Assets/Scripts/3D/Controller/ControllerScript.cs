using UnityEngine;
//using System.Numerics;

public class ControllerScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private GameObject player; //debugging
    [SerializeField] private GameObject pencil;
    [SerializeField] private SpawnPencil spawner;
    [SerializeField] private float factor = 10;
    //[SerializeField] private bool hasSpawned = false;

    //[SerializeField] private float velocity = 10;
    UnityEngine.Quaternion q;
    public Vector3 v; //vlt einfach in einem vector3d speichern? TODO

    private float adjustValues(float value) //veraltet
    {
        if (value > 180) value = value - 360;
        return value;
    }
    void Start()
    {
        pencil = GameObject.Find("pencil Variant(Clone)");
        rb = GameObject.Find("Cube").GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 euler = pencil.transform.rotation.eulerAngles;
        float phi, theta, psi;
        phi = euler.x;
        theta = euler.y;
        psi = euler.z;
        v.x = factor*(-cos(phi) * sin(psi) - sin(phi) * cos(theta) * cos(psi));
        v.z = factor*(sin(theta) * cos(psi));
        Debug.Log("Orientation: " + euler.x + " " + euler.y + " " + euler.z + " Velocity: " + v.x + " " + v.z);
        //v.x = -factor* Mathf.Sin(euler.z)* Mathf.Cos(euler.y);
        //v.z = factor* Mathf.Sin(euler.z) * Mathf.Sin(euler.y);
        rb.velocity = v;
    }
    float cos(float angle)
    {
        return Mathf.Cos(angle);
    }
    float sin(float angle)
    {
        return Mathf.Sin(angle);
    }
}