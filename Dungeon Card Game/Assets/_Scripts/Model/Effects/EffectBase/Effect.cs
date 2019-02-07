using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName="New Effect",menuName="Card Game/Effects/<name>")]
public abstract class Effect : ScriptableObject {

	//Variables
	[SerializeField]
	private string strDescription;

	//Properties
	public string Description{
		get{
			return strDescription;
		}
	}

	//Functions
	public abstract void Activate (Game pGame);

}
