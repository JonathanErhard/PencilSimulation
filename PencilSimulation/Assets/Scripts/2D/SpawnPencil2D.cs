using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPencil2D : MonoBehaviour
{

    private bool hasSpawned;
    [SerializeField] private GameObject pencil;
    void Awake()
    {
        GameObject newPencil = Instantiate(pencil, Vector3.zero, Quaternion.Euler(0, 0, UnityEngine.Random.Range(-0.001f, 0.001f)));
        newPencil.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY;
        newPencil.GetComponent<Rigidbody>().centerOfMass = new Vector3( 0, 0.7f, 0);
        newPencil.SetActive(true);
        hasSpawned = true;
    }
    void Update()
    {

    }
}
