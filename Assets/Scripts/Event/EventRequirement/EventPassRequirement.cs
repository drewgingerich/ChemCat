using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventRequirement/EventPassRequirement")]
public class EventPassRequirement : ValueRequirement {

	[SerializeField]
	private NarrativeEvent e;

	public override bool IsMet {
		get {
			return CheckRequirements(e.timesPassed);
		}
	}
}
