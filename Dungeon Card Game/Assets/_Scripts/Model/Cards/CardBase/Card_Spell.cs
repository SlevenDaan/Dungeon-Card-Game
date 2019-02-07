using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Spell",menuName="Card Game/Spell")]
public class Card_Spell : Card {

	//Variables
	[SerializeField]
	private Effect cardEffect;

	//Properties
	public override string Description{
		get{
			return cardEffect.Description;
		}
	}

	//Functions
	public Effect GetEffect(){
		return cardEffect;
	}
}
