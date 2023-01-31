using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

using Unity.VisualScripting;

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

    private void Start() {
        
    }

    private void Update() {
        //Translate our mouse position to a ground position
        var rawMousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var gridMousePosWorld = new Vector3(Mathf.Round(rawMousePosWorld.x), 0, Mathf.Round(rawMousePosWorld.z));
            
        if (Input.GetMouseButtonDown(0)) {
            //Place our tree if we are in the "placement" state
            if (currentState == CreationState.Placement) {
                var cellData = GridController.instance.GetCell((int)gridMousePosWorld.x, (int)gridMousePosWorld.z);
                if (!cellData.isOccupied && cellData.canBeOccupied) {
                    var placedTree = Instantiate(treePrefab, gridMousePosWorld, Quaternion.identity);
                    placedTree.GetComponent<TreeController>().enabled = true;

                    cellData.isOccupied = true;
                    cellData.currentOwner = placedTree;

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
        
        var rawMousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var gridMousePosWorld = new Vector3(Mathf.Round(rawMousePosWorld.x), 0, Mathf.Round(rawMousePosWorld.z));
        
        placeholderTree = placeholderTree ? placeholderTree : Instantiate(placementPrefab, gridMousePosWorld, Quaternion.identity);
        placeholderTree.GetComponent<TreeController>().enabled = false;
                
        
    }
}
