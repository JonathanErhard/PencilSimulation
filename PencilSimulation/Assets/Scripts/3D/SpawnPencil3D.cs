using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SpawnPencil : MonoBehaviour
{
    [SerializeField] private GameObject pencil;
    public float w, x, y, z;
    public float iw, ix, iy, iz;
    public bool hasSpawned;
    void Awake()
    {
        w = UnityEngine.Random.Range(-1f,1f);
        x = UnityEngine.Random.Range(-0.001f, 0.001f);
        y = UnityEngine.Random.Range(-0.001f, 0.001f);
        z = UnityEngine.Random.Range(-0.001f, 0.001f);
        GameObject newPencil=Instantiate(pencil, Vector3.zero, new Quaternion(x, y, z, w).normalized);
        newPencil.SetActive(true);
        hasSpawned = true;
    }
    void Update()
    {
        
    }
}