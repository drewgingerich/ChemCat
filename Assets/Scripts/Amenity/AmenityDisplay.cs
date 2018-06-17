using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmenityDisplay : MonoBehaviour {

	[SerializeField] Button buyButton;
	[SerializeField] Text titleText;
	[SerializeField] Text effectText;
	[SerializeField] Text flavorText;
	[SerializeField] Text costText;
	[SerializeField] Text countText;

	Amenity amenity;

	void Update() {
		amenity.CalculateCost();
		if (amenity.Available()) {
			buyButton.interactable = true;
			costText.color = Color.green;
		} else {
			buyButton.interactable = false;
			costText.color = Color.red;
		}
		Display();
	}

	void Display() {
		titleText.text = amenity.name;
		effectText.text = amenity.effect;
		flavorText.text = amenity.description;
		costText.text = string.Format("Costs {0} {1}", amenity.cost.ToString(), amenity.buyCurrency.name);
		countText.text = string.Format("x{0}", amenity.count.ToString());
	}

	public void SetAmenity(Amenity amenity) {
		this.amenity = amenity;
		buyButton.onClick.AddListener(amenity.Buy);
		Display();
	}
}
