using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventRequirement : ScriptableObject {

	public abstract bool IsMet {
		get;
	}
}
