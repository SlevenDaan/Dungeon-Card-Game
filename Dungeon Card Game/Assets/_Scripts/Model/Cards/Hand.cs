using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour{

	//Variables
	public const int MAX_HAND_SIZE = 7;
	private List<Card> arrCards = new List<Card>();

	public delegate void OnHandChange(Hand pNewHand);
	private OnHandChange onHandChange;

	//Properties
	public int Size{
		get{
			return arrCards.Count;
		}
	}

	//Events
	public event OnHandChange HandChanged{
		add{
			onHandChange+=value;
		}
		remove{
			onHandChange-=value;
		}
	}
	private void CallHandChanged(){
		if (onHandChange != null) {
			onHandChange (this);
		}
	}

	//Functions
	public bool Add(Card pCard){
		if (arrCards.Count >= MAX_HAND_SIZE) {
			return false;
		} else {
			arrCards.Add (pCard);
			CallHandChanged ();
			return true;
		}
	}
	public bool Remove(int pIndex){
		if (arrCards.Count > pIndex) {
			arrCards.RemoveAt (pIndex);
			CallHandChanged ();
			return true;
		} else {
			return false;
		}
	}

	public Card Get(int pIndex){
		if (arrCards.Count > pIndex) {
			return arrCards[pIndex];
		} else {
			return null;
		}
	}
	public Card Play(int pIndex){
		if (arrCards.Count > pIndex) {
			Card pCard = arrCards [pIndex];
			Remove(pIndex);
			return pCard;
		} else {
			return null;
		}
	}
}
