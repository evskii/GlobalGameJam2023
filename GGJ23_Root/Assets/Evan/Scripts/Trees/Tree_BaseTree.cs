using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_BaseTree : Tree
{
	public override void Fire() {
		base.Fire();
	}

	public override void Think() {
		base.Think();
		
		Debug.Log("I AM TREE: " + name);
	}
}
