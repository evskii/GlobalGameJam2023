using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUIObject : MonoBehaviour
{
    public GameObject myTree;

    public void TreePicked() {
        GetComponentInParent<TreePickerController>().PickTree(myTree);
    }
}
