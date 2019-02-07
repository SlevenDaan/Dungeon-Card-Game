using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EffectType_Arena{
	Summon,Cast,Defeat,Victory
}

[CreateAssetMenu(fileName="New Arena",menuName="Card Game/Arena")]
public class Card_Arena : Card {

	//Variables
	private const int EFFECT_AMOUNT = 4;
	[SerializeField]
	[Tooltip("0: Summon\n1: Cast\n2: Defeat\n3: Victory")]
	private Effect[] arrEffects = new Effect[EFFECT_AMOUNT];

	//Properties
	public override string Description{
		get{
			string strOutput = "";
			for (int intE = 0; intE < EFFECT_AMOUNT; intE++) {
				if (arrEffects[intE] != null) {
					if (strOutput != "") {
						strOutput += "\n";
					}
					strOutput += "<b>" + ((EffectType_Arena)intE).ToString () + ":</b> " + arrEffects[intE].Description;
				}
			}
			return strOutput;
		}
	}

	//Functions
	private Effect GetEffect(EffectType_Arena pType){
		return arrEffects[(int)pType];
	}

	public void ActivateEffect(EffectType_Arena pType,Game pGame){
		if (GetEffect (pType) != null) {
			GetEffect (pType).Activate (pGame);
		}
	}

	//Extra
	void OnValidate(){
		if (arrEffects.Length != EFFECT_AMOUNT) {
			Array.Resize(ref arrEffects, EFFECT_AMOUNT);
		}
	}
}
