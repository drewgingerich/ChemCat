using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventEffect/CurrencyEffect")]
public class CurrencyEffect : EventEffect {

	[SerializeField] Currency currency;
	[SerializeField] int change;

	public override void Trigger() {
		currency.ChangeCount(change);
	}
}
