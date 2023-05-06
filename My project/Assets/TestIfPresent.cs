using UnityEngine;
using UnityEngine.XR;

public class TestIfPresent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Device active: " + XRSettings.isDeviceActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
