using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Currency")]
public class Currency : ScriptableObject {

	new public string name;

	[SerializeField] int startingAmount;
	[SerializeField] bool enforceMaximum;
	[SerializeField] int max;
	[SerializeField] float startClickIncome;
	[SerializeField] float startPassiveIncome;
	[SerializeField] List<Amenity> clickAmenities;
	[SerializeField] List<Amenity> passiveAmenities;

	[NonSerialized] public float baseClickIncome;
	[NonSerialized] public float basePassiveIncome;
	[NonSerialized] public int count;

	float passiveRemainder;

	void OnEnable() {
		count = startingAmount;
		baseClickIncome = startClickIncome;
		basePassiveIncome = startPassiveIncome;
	}

	public void Click() {
		float income = baseClickIncome + GetIncome(clickAmenities);
		int rounded = Mathf.CeilToInt(income);
		ChangeCount(rounded);
	}

	public void Tick() {
		float income = basePassiveIncome + GetIncome(passiveAmenities);
		income *= Time.deltaTime;
		income += passiveRemainder;
		int rounded = Mathf.FloorToInt(income);
		passiveRemainder = income - rounded;
		ChangeCount(rounded);
	}

	public void ChangeCount(int change) {
		count += change;
		if (enforceMaximum && count > max)
			count = max;
	}

	float GetIncome(List<Amenity> amenityList) {
		float income = 0;
		foreach(Amenity amenity in amenityList) {
			income += amenity.income * amenity.count;
		}
		return income;
	}
}
