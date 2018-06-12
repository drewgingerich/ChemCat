using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event")]
public class Event : ScriptableObject {

	[Header("Info")]
	public string title;
	public string effect;
	[TextArea] public string flavor;

	[Header("Meta")]
	[Range(0, 1)] public float probability;
	public bool triggerOnExpire;
	public bool reoccuring;
	[System.NonSerialized] public int timesSucceeded;
	[System.NonSerialized] public int timesPassed;

	[SerializeField] List<EventReq> appreanceReqs;
	[SerializeField] List<EventReq> triggerReqs;
	[SerializeField] List<EventEffect> effects;


	public bool CheckIfCanAppear() {
		foreach (EventReq req in appreanceReqs) {
			if (!req.IsReady())
				return false;
		}
		return true;
	}

	public bool CheckIfCanTrigger() {
		foreach (EventReq req in triggerReqs) {
			if (!req.IsReady())
				return false;
		}
		return true;
	}

	public void TriggerOutcome() {
		foreach(EventEffect effect in effects) {
			effect.Trigger();
		}
	}
}
