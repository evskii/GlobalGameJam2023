using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

using TMPro;

using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public static PlayerInventory instance;

	private void Awake() {
		instance = this;
	}

	public int startCurrency = 600;
	private int lifeEssence;
	public TMP_Text lifeEssenceValueText;

	private void Start() {
		lifeEssence = 0;
		UpdateLifeEssenceBalance(startCurrency);
	}


	public int GetLifeEssenceBalance() {
		return lifeEssence;
	}

	public void UpdateLifeEssenceBalance(int amount) {
		lifeEssence += amount;
		lifeEssence = lifeEssence <= 0 ? 0 : lifeEssence;
		lifeEssenceValueText.text = lifeEssence.ToString();

	}
}
