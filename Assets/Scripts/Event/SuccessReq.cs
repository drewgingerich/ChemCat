using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventReq/SuccessReq")]
public class SuccessReq : EventReq {

	[SerializeField] Event e;

	public override bool IsReady() {
		return Ready(e.timesSucceeded);
	}
}
