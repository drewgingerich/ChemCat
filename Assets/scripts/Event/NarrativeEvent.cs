using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event")]
public class NarrativeEvent : ScriptableObject {

	public string title;
	[TextArea]
	public string description;
	public string quote;

	public bool isTimed;
	public float timer;

	public bool guarenteedAppearance;
	public int appearanceWeight;

	public bool reoccuring;
	public int numberOfAppearances;

	[System.NonSerialized]
	public int timesAppeared;
	[System.NonSerialized]
	public int timesTriggered;
	[System.NonSerialized]
	public int timesPassed;

	[SerializeField]
	private List<EventRequirement> appreanceReqs;
	[SerializeField]
	private List<EventRequirement> triggerReqs;

	[SerializeField]
	private List<EventEffect> appearanceEffects;
	[SerializeField]
	private List<EventEffect> passEffects;
	[SerializeField]
	private List<EventEffect> triggerEffects;



	public bool CanAppear {
		get {
			foreach (EventRequirement req in appreanceReqs) {
				if (!req.IsMet)
					return false;
			}
			return true;
		}
	}

	public bool CanTrigger {
		get {
			foreach (EventRequirement req in triggerReqs) {
				if (!req.IsMet)
					return false;
			}
			return true;
		}
	}

	public void Appear() {
		timesAppeared += 1;
		foreach(EventEffect effect in appearanceEffects) {
			effect.Trigger();
		}
	}

	public void Trigger() {
		timesTriggered += 1;
		foreach(EventEffect effect in triggerEffects) {
			effect.Trigger();
		}
	}

	public void Pass() {
		timesPassed += 1;
		foreach(EventEffect effect in passEffects) {
			effect.Trigger();
		}
	}
}
