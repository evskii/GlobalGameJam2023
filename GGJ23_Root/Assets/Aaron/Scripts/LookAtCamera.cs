using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        if (cam == null)
        {
            cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        }
    }

    void Update()
    {
        Vector3 rot = Quaternion.LookRotation(cam.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }
}
