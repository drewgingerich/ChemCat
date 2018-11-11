using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDriver : MonoBehaviour {

	public Event activeEvent;
	[System.NonSerialized] public float presentationTime = 15;
	[System.NonSerialized] public float searchDelay = 7;
	[System.NonSerialized] public float timer;

	[SerializeField] Button button;
	[SerializeField] List<Event> possibleEvents;

	void Awake() {
		button.onClick.AddListener(TiggerEvent);
	}

	void Update() {
		if (activeEvent != null)
			UpdateEventActivity();
		else {
			button.interactable = false;
			FindNextEvent();
		}
	}

	void UpdateEventActivity() {
		if (activeEvent.CheckIfCanTrigger())
			button.interactable = true;
		else
			button.interactable = false;

		timer += Time.deltaTime;
		if (timer >= presentationTime) {
			if (activeEvent.triggerOnExpire) {
				TiggerEvent();
			} else {
				PassEvent();
			}
		}
	}

	void TiggerEvent() {
		activeEvent.TriggerOutcome();
		activeEvent.timesSucceeded += 1;
		if (!activeEvent.reoccuring)
			possibleEvents.Remove(activeEvent);
		PassEvent();
	}

	void PassEvent() {
		activeEvent.timesPassed += 1;
		activeEvent = null;
		timer = 0;
	}

	void FindNextEvent() {
		timer += Time.deltaTime;
		if (timer < searchDelay)
			return;

		while (activeEvent == null) {
			float rand = Random.Range(0, 1f);
			int randIndex = Random.Range(0, possibleEvents.Count);
			Event e = possibleEvents[randIndex];
			if (!e.CheckIfCanAppear())
				continue;
			if (rand < e.probability) {
				activeEvent = e;
				timer = 0;
				return;
			}	
		}
	}
}
