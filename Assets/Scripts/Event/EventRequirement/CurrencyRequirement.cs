using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventRequirement/CurrencyRequirement")]
public class CurrencyRequirement : ValueRequirement {

	[SerializeField] Currency currency;

	public override bool IsMet {
		get {
			return CheckRequirements(currency.count);
		}
	}
}
