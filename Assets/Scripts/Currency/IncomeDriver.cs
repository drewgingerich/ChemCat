using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class IncomeDriver : MonoBehaviour {

	[SerializeField] List<Currency> currencies;

	Button button;

	void Awake() {
		button = GetComponent<Button>();
		button.onClick.AddListener(Click);
	}

	void Update() {
		Tick();
	}

	void Click() {
		foreach(Currency currency in currencies) {
			currency.Click();
		}
	}

	void Tick() {
		foreach(Currency currency in currencies) {
			currency.Tick();
		}
	}
}
