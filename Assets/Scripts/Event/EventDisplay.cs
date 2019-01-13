using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDisplay : MonoBehaviour {

	[SerializeField] EventDriver driver;
	[SerializeField] GameObject placeholderText;
	[SerializeField] GameObject countdownDivider;
	[SerializeField] GameObject countdownLabelText;
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
		placeholderText.SetActive(true);
		titleText.text = "";
		effectText.text = "";
		flavorText.text = "";
		countdownDivider.SetActive(false);
		countdownLabelText.SetActive(false);
		countdownText.text = "";
	}

	void UpdateDisplay() {
		placeholderText.gameObject.SetActive(false);
		titleText.text = driver.activeEvent.title;
		flavorText.text = driver.activeEvent.description;
		countdownDivider.SetActive(true);
		countdownLabelText.SetActive(true);
		countdownText.text = Mathf.FloorToInt(driver.presentationTime - driver.timer).ToString();
	}
}
