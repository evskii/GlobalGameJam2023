using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.UI;
using TMPro;

using UnityEngine;

public class TreeUIObject : MonoBehaviour
{
    public TreeInformation myTree;

    public TMP_Text price;
    public TMP_Text name;
    public Image treeImage;

    private void Start() {
        price.text = myTree.lifeEssenceCost.ToString();
        name.text = myTree.treeName;
        treeImage.sprite = myTree.thumbnailSprite;
    }

    public void TreePicked() {
        GetComponentInParent<TreePickerController>().PickTree(myTree);
    }
}
