using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

using Unity.VisualScripting;

using UnityEngine;

public class TreeCreationController : MonoBehaviour
{
    //Tree Stuff
    public GameObject treePrefab;
    public enum CreationState {
        None,
        Placement
    }
    public CreationState currentState;
    public GameObject placeholderTree;

    private void Start() {
        currentState = CreationState.None;
    }

    private void Update() {
        var rawMousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var gridMousePosWorld = new Vector3(Mathf.Round(rawMousePosWorld.x), 0, Mathf.Round(rawMousePosWorld.z));
            
        if (Input.GetMouseButtonDown(0)) {
            if (currentState == CreationState.None) {

                placeholderTree = placeholderTree ? placeholderTree : Instantiate(treePrefab, gridMousePosWorld, Quaternion.identity);
                placeholderTree.GetComponent<TreeController>().enabled = false;
                
                currentState = CreationState.Placement;
            }else {
                var placedTree = Instantiate(treePrefab, gridMousePosWorld, Quaternion.identity);
                placedTree.GetComponent<TreeController>().enabled = true;
                Destroy(placeholderTree);
                currentState = CreationState.None;
            }
        }

        if (placeholderTree) {
            placeholderTree.transform.position = gridMousePosWorld;
        }
    }
}
