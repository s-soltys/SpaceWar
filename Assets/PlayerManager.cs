using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public bool Deploying;
	public SpaceshipColor ChoosenColor;

	public Direction ChoosenDirection;


	public string ChoosenPattern;
	
//	public Spaceship ChoosenShip;
	
	public SpaceshipSpawn Yes;



	public void Desploying(){
		Deploying = true;
	}
	



	public void ChoosenBlue(){

		ChoosenColor = SpaceshipColor.Blue;
		Deploying = true;
		}

	public void ChoosenRed(){
		
		ChoosenColor = SpaceshipColor.Red;
		Deploying = true;
	}

	public void ChoosenYellow(){

		ChoosenColor = SpaceshipColor.Yellow;
		Deploying = true;
		}



//
//	public void Startthis(Spaceship now){
//		now.color = ChoosenColor;
//
//		Instantiate (now);
//		now.Deploy();
//		}




	public void ChooseColor(){



	}






	public void ChooseStraight(){
		
		ChoosenPattern = "STRAIGHT";
		
	}

	public void ChooseDiagonalUp(){
		
		ChoosenPattern = "DIAGONALUP";
	
	}
	
	public void ChooseDiagonalDown(){

		ChoosenPattern = "DIAGONALDOWN";

	}



	public void Player1Planet1(){

		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 0);
		Deploying = false;
	}
	public void Player1Planet2(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 1);
		Deploying = false;
	}
	public void Player1Planet3(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 2);
		Deploying = false;
	}
	public void Player1Planet4(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 3);
		Deploying = false;
	}
	public void Player1Planet5(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 4);
		Deploying = false;
	}
	public void Player1Planet6(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 5);
		Deploying = false;
	}
	public void Player1Planet7(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 6);
		Deploying = false;
	}











	public void Player2Planet1(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 0);
		Deploying = false;
	}
	public void Player2Planet2(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 1);
		Deploying = false;
	}
	public void Player2Planet3(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 2);
		Deploying = false;
	}
	public void Player2Planet4(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 3);
		Deploying = false;
	}
	public void Player2Planet5(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 4);
		Deploying = false;
	}
	public void Player2Planet6(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 5);
		Deploying = false;
	}
	public void Player2Planet7(){
		
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Left, 7, 6);
		Deploying = false;
	}






}
