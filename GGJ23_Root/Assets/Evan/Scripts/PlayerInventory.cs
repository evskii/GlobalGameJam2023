using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public static PlayerInventory instance;

	private void Awake() {
		instance = this;
	}

	private int lifeEssence;

	private void Start() {
		lifeEssence = 0;
	}

	public int GetLifeEssenceBalance() {
		return lifeEssence;
	}

	public void UpdateLifeEssenceBalance(int amount) {
		lifeEssence += amount;
		lifeEssence = lifeEssence < 0 ? 0 : lifeEssence;
		
	}
}
