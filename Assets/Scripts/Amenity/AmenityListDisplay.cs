using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmenityListDisplay : MonoBehaviour {

	[SerializeField] List<Amenity> availableAmenities;
	[SerializeField] GameObject amenityDisplayPrefab;

	void Awake() {
		foreach(Amenity amenity in availableAmenities) {
			var newAmenityDisplayObj = Instantiate(amenityDisplayPrefab);
			newAmenityDisplayObj.transform.SetParent(transform);
			var newAmenityDisplay = newAmenityDisplayObj.GetComponent<AmenityDisplay>();
			newAmenityDisplay.SetAmenity(amenity);
		}
	}
}
