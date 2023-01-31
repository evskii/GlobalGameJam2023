using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDebugging : MonoBehaviour
{
    public Vector3 mousePos;
    public LayerMask layerMask;
    void Update(){
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, layerMask)) {
            mousePos = hit.point;
            Debug.Log(hit.point);
        }
    }
}
