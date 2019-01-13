using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueRequirement : EventRequirement {

	[SerializeField]
	private bool requireMin;
	[SerializeField]
	private int min;
	[SerializeField]
	private bool requireMax;
	[SerializeField]
	private int max;

	protected bool CheckRequirements(int value) {
		if (requireMin && value <= min)
			return false;
		else if (requireMax && value >= max)
			return false;
		else
			return true;
	}
}
