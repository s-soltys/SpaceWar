using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public bool Deploying;
	public float ChossenColor;
	public Spaceship ChossenPattern;
	public Planet ChossenPlanet;
	
	
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ChossenColor != 0)
						Deploying = true;
		
	}
	
	public void Desploying(){
		Deploying = true;
	}


	public void Ship1Choosen(){
		ChossenColor = 1;
		}

	public void Ship2Choosen(){
		ChossenColor =  2;
		}

	public void Ship3Choosen(){
		ChossenColor =  3;
		}


	public void ChooseShip(int colornumber){
		ChossenColor = colornumber;

		}








}
