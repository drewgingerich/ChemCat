using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventReq/PassedReq")]
public class PassedReq : EventReq {

	[SerializeField] Event e;

	public override bool IsReady() {
		return Ready(e.timesPassed);
	}
}
