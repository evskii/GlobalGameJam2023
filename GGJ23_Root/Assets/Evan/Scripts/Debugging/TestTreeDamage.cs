using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTreeDamage : MonoBehaviour
{
    [ContextMenu("TETS")]
    public void TestDamage() {
        FindObjectOfType<TreeController>().GetComponent<IDamageable>().TakeDamage(10);
    }
}
