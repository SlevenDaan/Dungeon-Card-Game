using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EffectType_Monster{
	Birth,Afterlife,Abandon,Triumph,Grief
}

[CreateAssetMenu(fileName="New Monster",menuName="Card Game/Monster")]
public class Card_Monster : Card {

	//Variables
	[SerializeField]
	private int intDamage;
	[SerializeField]
	private int intDefense;

	private const int EFFECT_AMOUNT = 5;
	[SerializeField]
	[Tooltip("0: Birth\n1: Afterlife\n2: Abandon\n3: Triumph\n4: Grief")]
	private Effect[] arrEffects = new Effect[EFFECT_AMOUNT];
	
	//Properties
	public int Damage{
		get
		{
			return intDamage;
		}
  	}
	public int Defense{
		get
		{
			return intDefense;
		}
	}
	
	public override string Description{
		get{
			string strOutput = "";
			for (int intE = 0; intE < EFFECT_AMOUNT; intE++) {
				if (arrEffects[intE] != null) {
					if (strOutput != "") {
						strOutput += "\n";
					}
					strOutput += "<b>" + ((EffectType_Monster)intE).ToString () + ":</b> " + arrEffects[intE].Description;
				}
			}
			return strOutput;
		}
	}

	//Functions
	private Effect GetEffect(EffectType_Monster pType){
		return arrEffects[(int)pType];
	}

	public void ActivateEffect(EffectType_Monster pType,Game pGame){
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
