using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour{
	
	//Variables
	private List<Card> arrCards = new List<Card>();

	//Properties
	public int Size{
		get{
			return arrCards.Count;
		}
	}

	//Functions
	public bool AddToBottom(Card pCard){
		arrCards.Add (pCard);
		return true;
	}
	public bool AddToTop(Card pCard){
		arrCards.Insert (0, pCard);
		return true;
	}

	public Card Peek(){
		if (arrCards.Count > 0) {
			return arrCards [0];
		} else {
			return null;
		}
	}
	public Card Draw(){
		if (arrCards.Count > 0) {
			Card pCard = arrCards [0];
			arrCards.RemoveAt (0);
			return pCard;
		} else {
			return null;
		}
	}

	public void Shuffle(){
		int intLength = arrCards.Count;

		while (intLength > 1) {
			intLength--;
			int intRandom = Random.Range (0, intLength + 1);
			Card pCard = arrCards [intRandom];
			arrCards [intRandom] = arrCards [intLength];
			arrCards [intLength] = pCard;
		}
	}
}
