using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventEffect/AmenityEffect")]
public class AmenityEffect : EventEffect {

	public Amenity amenity;
	public int change;

	public override void Trigger() {
		amenity.count += change;
	}
}
