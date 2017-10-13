using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class RPS_game : MonoBehaviour {
	public Button ROCK, PAPER, SCISSORS;
	public Text CPU_MOVE, P_WIN, C_WIN, TURN;

	private int p_win = 0, c_win = 0, cpu_move;
	private int i, j;
	
	// Use this for initialization
	void Start () {
		Button btn1 = ROCK.GetComponent<Button>();
		Button btn2 = PAPER.GetComponent<Button>();
		Button btn3 = SCISSORS.GetComponent<Button>();

		btn1.onClick.AddListener(OnClick);
		btn2.onClick.AddListener(OnClick);
		btn3.onClick.AddListener(OnClick);
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			player_move(0);			
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			player_move(1);			
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			player_move(2);			
		}
		P_WIN.text = p_win.ToString();
		C_WIN.text = c_win.ToString();
		TURN.text = "Turn: " + N;
	}
	
	//0 = rock
	//1 = paper 
	//2 = scissor

	int[] NAB = new int[9], AB = new int[2];
	int[,] NCAB = new int[9,3];
	double ProbRock = 0;
	double ProbPaper = 0;
	double ProbScissors = 0;
	int Prediction = 0;
	int RandomPrediction = 0;
	int N = 0;
	int NSuccess = 0;
	
	void player_move(int move){
		int cpu_move = move_network(move);
		
		string move_text;
		switch (cpu_move){
			case 0:
				move_text = "ROCK";
				break;	
			case 1:
				move_text = "PAPER";
				break;
			case 2:
				move_text = "SCISSOR";
				break;
			default:
				move_text = "";	
				break;
		}
		CPU_MOVE.text = move_text;  

		eval_move(move, cpu_move);			
	}
	int move_network(int move){
		//HERE WE DEFINE THE BAYESIAN Network
		//int i, j;
		N++;
		if(move == Prediction) NSuccess++;

		if((AB[0] == 0) && (AB[1] == 0)) i = 0;
		if((AB[0] == 0) && (AB[1] == 1)) i = 1;
		if((AB[0] == 0) && (AB[1] == 2)) i = 2;
		if((AB[0] == 1) && (AB[1] == 0)) i = 3;
		if((AB[0] == 1) && (AB[1] == 1)) i = 4;
		if((AB[0] == 1) && (AB[1] == 2)) i = 5;
		if((AB[0] == 2) && (AB[1] == 0)) i = 6;
		if((AB[0] == 2) && (AB[1] == 1)) i = 7;
		if((AB[0] == 2) && (AB[1] == 2)) i = 8;

		if(move == 0) j = 0;
		if(move == 1) j = 1;
		if(move == 2) j = 2;

		//Iterate frequency of current move.
		NAB[i]++;
		NCAB[i,j]++;

		//Flips current to previous move
		AB[0] = AB[1];
		
		AB[1] = move;

		//Sets i to the key of individual moves
		if((AB[0] == 0) && (AB[1] == 0)) i = 0;
		if((AB[0] == 0) && (AB[1] == 1)) i = 1;
		if((AB[0] == 0) && (AB[1] == 2)) i = 2;
		if((AB[0] == 1) && (AB[1] == 0)) i = 3;
		if((AB[0] == 1) && (AB[1] == 1)) i = 4;
		if((AB[0] == 1) && (AB[1] == 2)) i = 5;
		if((AB[0] == 2) && (AB[1] == 0)) i = 6;
		if((AB[0] == 2) && (AB[1] == 1)) i = 7;
		if((AB[0] == 2) && (AB[1] == 2)) i = 8;

		ProbRock = (double) NCAB[i,0] / (double) NAB[i];
		ProbPaper = (double) NCAB[i,1] / (double) NAB[i];
		ProbScissors = (double) NCAB[i,2] / (double) NAB[i];
		
		if((ProbRock > ProbPaper) &&
				(ProbRock > ProbScissors))
				return 0;
		if((ProbPaper > ProbRock) &&
				(ProbPaper > ProbScissors))
				return 1;
		if((ProbScissors > ProbRock) &&
				(ProbScissors > ProbPaper))
				return 2;

		System.Random random = new System.Random();
 		return random.Next(0, 2);
		// Last resort
		
	}
	void eval_move(int player, int cpu){
		if(player == cpu){
			return;
		}
		else if(player == 0){
			switch (cpu){
				case 1:
					c_win++;
					break;
				case 2:
					p_win++;
					break;				
			}
		}
		else if(player == 1){
			switch (cpu){		
				case 2:
					c_win++;
					break;
				case 0:
					p_win++;
					break;				
			}
		}
		else if(player == 2){
			switch (cpu){		
				case 0:
					c_win++;
					break;
				case 1:
					p_win++;
					break;				
			}
		}
	}

	void OnClick(){
		switch (EventSystem.current.currentSelectedGameObject.name){
			case "Rock!":
				player_move(0);
				Debug.Log("Rock clicked.");
				break;
			case "Paper!":
				player_move(1);	
				Debug.Log("Paper clicked.");
				break;		
			case "Scissors!":
				player_move(2);
				Debug.Log("Scissors clicked.");	
				break;
		}
	}
}
