using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Effect",menuName="Card Game/Effects/Debug")]
public class Effect_Debug : Effect {

	[SerializeField]
	private string strDebugMessage;

	public override void Activate (Game pGame)
	{
		Debug.Log (strDebugMessage);
	}

}
