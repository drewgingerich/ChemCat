using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour {

	[SerializeField] Currency currency;
	[SerializeField] Text currencyNameText;
	[SerializeField] Text currencyAmountText;

	void Awake() {
		currencyNameText.text = string.Format("{0}:", currency.name);
	}

	void LateUpdate () {
		currencyAmountText.text = currency.count.ToString();
	}
}
