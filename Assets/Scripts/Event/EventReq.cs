using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventReq : ScriptableObject {

	[SerializeField] protected bool requireMax;
	[SerializeField] protected int max;
	[SerializeField] protected bool requireMin;
	[SerializeField] protected int min;

	public abstract bool IsReady();

	protected bool Ready(int itemCount) {
		if (requireMax && itemCount > max)
			return false;
		if (requireMin && itemCount < min)
			return false;
		return true;
	}
}
