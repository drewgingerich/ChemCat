using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventRequirement/EventSuccessRequirement")]
public class EventSuccessRequirement : ValueRequirement {

	[SerializeField] NarrativeEvent e;

	public override bool IsMet {
		get {
			return CheckRequirements(e.timesTriggered);
		}
	}
}
