using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreePickerController : MonoBehaviour
{
    public GameObject treeMenu;
    public GameObject treeMenuOpenButton;

    public GameObject treeCreationController;

    private void Start() {
        treeMenu.SetActive(false);
        treeMenuOpenButton.SetActive(true);
        treeCreationController.SetActive(false);
    }

    public void ToggleMenu() {
        treeMenuOpenButton.SetActive(!treeMenuOpenButton.activeSelf);
        
        treeMenu.SetActive(!treeMenuOpenButton.activeSelf);

        if (treeMenu.activeSelf) {
            treeCreationController.SetActive(false);
        }
    }

    public void ToggleMenu(bool isOn) {
        treeMenu.SetActive(isOn);
        
        treeMenuOpenButton.SetActive(!isOn);
        
        treeCreationController.SetActive(!isOn);
    }

    public void PickTree(GameObject treeToPick) {
        StartCoroutine(Test(treeToPick));

    }

    private IEnumerator Test(GameObject treeToPick) {
        yield return new WaitForSeconds(0.25f);
        
        ToggleMenu(false);

        TreeCreationController.instance.SpawnPlacementModel(treeToPick);
        treeCreationController.SetActive(true);
    }
}
