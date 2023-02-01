using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TreeCreationController : MonoBehaviour
{
    public static TreeCreationController instance;

    private void Awake() {
        instance = this;
    }


    //Tree Stuff
    public GameObject treePrefab;
    public enum CreationState {
        None,
        Placement
    }
    public CreationState currentState;
    public GameObject placeholderTree;

    public LayerMask layerMask;
    private Vector3 rawMousePosWorld;
    private Vector3 gridMousePosWorld = Vector3.zero;

    private void Update() {
        //Translate our mouse position to a ground position
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            rawMousePosWorld = hit.point;
            // Debug.Log(hit.point);
        }

        var x = Mathf.Round(rawMousePosWorld.x);
        x = x % 2 == 0 ? x + 1 : x;

        var z = Mathf.Round(rawMousePosWorld.z);
        z = z % 2 == 0 ? z + 1 : z;
        
        // gridMousePosWorld = new Vector3(Mathf.Round(rawMousePosWorld.x), 0, Mathf.Round(rawMousePosWorld.z));
        gridMousePosWorld = new Vector3(x, 0, z);

        if (Input.GetMouseButtonDown(0)) {
            //Place our tree if we are in the "placement" state
            if (currentState == CreationState.Placement) {
                var cellData = GridController.instance.GetCell((int)gridMousePosWorld.x, (int)gridMousePosWorld.z);
                if (!cellData.isOccupied && cellData.canBeOccupied) {
                    var placedTree = Instantiate(treePrefab, gridMousePosWorld, Quaternion.identity);
                    placedTree.GetComponent<TreeController>().enabled = true;

                    cellData.isOccupied = true;
                    cellData.currentOwner = placedTree;
                    GridController.instance.UpdateGridMesh();

                    Destroy(placeholderTree);
                    currentState = CreationState.None;
                    gameObject.SetActive(false);
                }
                
            }
        }

        if (placeholderTree) {
            placeholderTree.transform.position = gridMousePosWorld;
            // GridController.instance.HighlightSingleCell((int) gridMousePosWorld.x, (int) gridMousePosWorld.z);
        }
    }

    public void SpawnPlacementModel(GameObject placementPrefab) {
        currentState = CreationState.Placement;
        treePrefab = placementPrefab;
        
        Debug.Log(currentState);
        
        
        placeholderTree = placeholderTree ? placeholderTree : Instantiate(placementPrefab, gridMousePosWorld, Quaternion.identity);
        placeholderTree.GetComponent<TreeController>().enabled = false;
                
        
    }
}
