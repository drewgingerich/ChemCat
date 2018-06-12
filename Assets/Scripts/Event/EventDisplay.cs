using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDisplay : MonoBehaviour {

	[SerializeField] EventDriver driver;
	[SerializeField] Text placeholderText;
	[SerializeField] Text titleText;
	[SerializeField] Text effectText;
	[SerializeField] Text flavorText;
	[SerializeField] Text countdownText;
	
	void Update () {
		if (driver.activeEvent == null)
			ClearDisplay();
		else
			UpdateDisplay();
	}

	void ClearDisplay() {
		placeholderText.gameObject.SetActive(true);
		titleText.text = "";
		effectText.text = "";
		flavorText.text = "";
		countdownText.text = "";
	}

	void UpdateDisplay() {
		placeholderText.gameObject.SetActive(false);
		titleText.text = driver.activeEvent.title;
		effectText.text = driver.activeEvent.effect;
		flavorText.text = driver.activeEvent.flavor;
		countdownText.text = Mathf.FloorToInt(driver.presentationTime - driver.timer).ToString();
	}
}
