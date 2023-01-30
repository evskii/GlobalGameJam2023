using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private Tree myTree;

    private void Awake() {
        myTree = GetComponent<Tree>();
    }

    private void Update() {
        myTree.Think();
    }
}
