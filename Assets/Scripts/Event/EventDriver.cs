using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDriver : MonoBehaviour {

	public NarrativeEvent activeEvent;
	[System.NonSerialized] public float presentationTime = 15;
	[System.NonSerialized] public float searchDelay = 7;
	[System.NonSerialized] public float timer;

	[SerializeField] Button button;
	[SerializeField] List<NarrativeEvent> possibleEvents;

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
		if (activeEvent.CanTrigger)
			button.interactable = true;
		else
			button.interactable = false;

		timer += Time.deltaTime;
		if (timer >= presentationTime) {
			activeEvent.Pass();
		}
	}

	void TiggerEvent() {
		activeEvent.Trigger();
	}

	void FindNextEvent() {
		timer += Time.deltaTime;
		if (timer < searchDelay)
			return;

		while (activeEvent == null) {
			float rand = Random.Range(0, 1f);
			int randIndex = Random.Range(0, possibleEvents.Count);
			NarrativeEvent selectedEvent= possibleEvents[randIndex];
			if (!selectedEvent.CanAppear)
				continue;
			if (rand < selectedEvent.appearanceWeight) {
				activeEvent = selectedEvent;
				timer = 0;
				return;
			}	
		}
	}
}
