using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventReq/AmenityReq")]
public class AmenityReq : EventReq{

	[SerializeField] Amenity amenity;

	public override bool IsReady() {
		return Ready(amenity.count);
	}
}
