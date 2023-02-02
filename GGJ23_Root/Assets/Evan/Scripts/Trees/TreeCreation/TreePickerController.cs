using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.UI;

public class TreePickerController : MonoBehaviour
{
    public GameObject treeMenu;
    public GameObject treeMenuOpenButton;

    public GameObject treeCreationController;

    public List<TreeUIObject> allTreeUiObjects;

    private void Start() {
        treeMenu.SetActive(false);
        treeMenuOpenButton.SetActive(true);
        treeCreationController.SetActive(false);

        allTreeUiObjects = FindObjectsOfType<TreeUIObject>().ToList();
        
    }

    public void ToggleMenu() {
        treeMenuOpenButton.SetActive(!treeMenuOpenButton.activeSelf);
        
        treeMenu.SetActive(!treeMenuOpenButton.activeSelf);

        if (treeMenu.activeSelf) {
            treeCreationController.SetActive(false);
            
            allTreeUiObjects = FindObjectsOfType<TreeUIObject>().ToList();
            
            foreach (var tree in allTreeUiObjects) {
                var canAfford = tree.myTree.lifeEssenceCost <= PlayerInventory.instance.GetLifeEssenceBalance();
                tree.GetComponentInChildren<Button>().interactable = canAfford;
                tree.price.color = canAfford ? Color.black : Color.red;
            }
        }
    }

    public void ToggleMenu(bool isOn) {
        treeMenu.SetActive(isOn);
        
        treeMenuOpenButton.SetActive(!isOn);
        
        treeCreationController.SetActive(!isOn);
        
        if (treeMenu.activeSelf) {
            treeCreationController.SetActive(false);
            
            allTreeUiObjects = FindObjectsOfType<TreeUIObject>().ToList();
            
            foreach (var tree in allTreeUiObjects) {
                var canAfford = tree.myTree.lifeEssenceCost <= PlayerInventory.instance.GetLifeEssenceBalance();
                tree.GetComponentInChildren<Button>().interactable = canAfford;
                tree.price.color = canAfford ? Color.black : Color.red;
            }
        }
    }

    public void PickTree(TreeInformation treeToPick) {
        StartCoroutine(Test(treeToPick));

    }

    private IEnumerator Test(TreeInformation treeToPick) {
        yield return new WaitForSeconds(0.25f);
        
        ToggleMenu(false);

        TreeCreationController.instance.SpawnPlacementModel(treeToPick.treePrefab);
        treeCreationController.SetActive(true);
        PlayerInventory.instance.UpdateLifeEssenceBalance(- treeToPick.lifeEssenceCost);
    }
}
