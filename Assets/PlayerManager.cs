using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	// it doesnt work well
	public bool Deploying;
	public SpaceshipColor ChoosenColor;


	// tags for player 1 and 2 to decide in the start function which ChoosenDirection should be choosen
//	public Direction ChoosenDirection;

	public string ChoosenPattern;

	
	public SpaceshipSpawn Yes;



	public float shootCooldown;

	public float shootingRate = 1f;

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}

	void Start () {
		
		shootCooldown = 0f;
	}

	public void Update (){
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}

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
		if (CanAttack) {
		shootCooldown = shootingRate;
		Yes.Spawn (ChoosenColor,ChoosenPattern,Direction.Right, 0, 0);
		Deploying = false;
			}
	}
	public void Player1Planet2(){
		if (CanAttack) {
		shootCooldown = shootingRate;
		Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Right, 0, 1);
		Deploying = false;
				}
	}
	public void Player1Planet3(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Right, 0, 2);
						Deploying = false;
				}
	}
	public void Player1Planet4(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Right, 0, 3);
						Deploying = false;
				}
	}
	public void Player1Planet5(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Right, 0, 4);
						Deploying = false;
				}
	}
	public void Player1Planet6(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Right, 0, 5);
						Deploying = false;
				}
	}
	public void Player1Planet7(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Right, 0, 6);
						Deploying = false;
				}
	}











	public void Player2Planet1(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 0);
						Deploying = false;
				}
	}
	public void Player2Planet2(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 1);
						Deploying = false;
				}
	}
	public void Player2Planet3(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 2);
						Deploying = false;
				}
	}
	public void Player2Planet4(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 3);
						Deploying = false;
				}
	}
	public void Player2Planet5(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 4);
						Deploying = false;
				}
	}
	public void Player2Planet6(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 5);
						Deploying = false;
				}
	}
	public void Player2Planet7(){
		if (CanAttack) {
						shootCooldown = shootingRate;
						Yes.Spawn (ChoosenColor, ChoosenPattern, Direction.Left, 9, 6);
						Deploying = false;
				}
	}






}
