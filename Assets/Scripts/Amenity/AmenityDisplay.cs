using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmenityDisplay : MonoBehaviour {

	[SerializeField] Amenity amenity;
	[SerializeField] Button buyButton;
	[SerializeField] Text titleText;
	[SerializeField] Text effectText;
	[SerializeField] Text flavorText;
	[SerializeField] Text costText;
	[SerializeField] Text countText;


	void Awake() {
		buyButton.onClick.AddListener(amenity.Buy);
		Display();
	}

	void Update() {
		amenity.CalculateCost();
		if (amenity.Available())
			buyButton.interactable = true;
		else
			buyButton.interactable = false;
		Display();
	}

	void Display() {
		titleText.text = amenity.name;
		effectText.text = amenity.effect;
		flavorText.text = amenity.description;
		costText.text = string.Format("Costs {0} {1}", amenity.cost.ToString(), amenity.buyCurrency.name);
		countText.text = string.Format("Have: {0}", amenity.count.ToString());
	}
}
