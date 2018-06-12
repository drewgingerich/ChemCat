using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventReq/CurrencyReq")]
public class CurrencyReq : EventReq {

	[SerializeField] Currency currency;

	public override bool IsReady() {
		return Ready(currency.count);
	}
}
