using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventRequirement/AmenityRequirement")]
public class AmenityRequirement : ValueRequirement {

	[SerializeField]
	private Amenity amenity;

	public override bool IsMet {
		get {
			return CheckRequirements(amenity.count);
		}
	}
}
