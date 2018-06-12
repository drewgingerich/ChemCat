using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Amenity")]
public class Amenity : ScriptableObject {


	new public string name;
	public string effect;
	[TextArea] public string description;
	public float income;
	public Currency buyCurrency;

	[NonSerialized] public int cost;
	[NonSerialized] public int count;

	[SerializeField] int baseCost;


	public void Buy() {
		buyCurrency.count -= cost;
		count++;
	}

	public void CalculateCost() {
		cost = baseCost * (count + 1);
	}

	public bool Available() {
		return (buyCurrency.count >= cost);
	}
}
