using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RPS_game : MonoBehaviour {
	public Button ROCK, PAPER, SCISSORS;
	public Text CPU_MOVE, P_WIN, C_WIN;

	private int p_win = 0, c_win = 0, cpu_move;
	private int N = 0, i = -1, j;

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
		P_WIN.text = p_win.ToString();
		C_WIN.text = c_win.ToString();
	}
	
	void player_move(int next_move){
		N++;
		j = next_move;

		if(i == -1){
			CPU_MOVE.text = "ROCK";
			cpu_move = 0;
		}

/*		
		//HERE WE DEFINE THE BAYESIAN Network
		//int i, j;
		N++;
		if(move == Prediction) NSuccess++;
		if((AB[0] == Punch) && (AB[1] == Punch)) i = 0;
		if((AB[0] == Punch) && (AB[1] == LowKick)) i = 1;
		if((AB[0] == Punch) && (AB[1] == HighKick)) i = 2;
		if((AB[0] == LowKick) && (AB[1] == Punch)) i = 3;
		if((AB[0] == LowKick) && (AB[1] == LowKick)) i = 4;
		if((AB[0] == LowKick) && (AB[1] == HighKick)) i = 5;
		if((AB[0] == HighKick) && (AB[1] == Punch)) i = 6;
		if((AB[0] == HighKick) && (AB[1] == LowKick)) i = 7;
		http://ebooks.servegame.com/oreaiforgamdev475b/ch13_sect1_005.htm (3 of 6)7/24/05 1:26:16 AM
		AI for Game Developers
		if((AB[0] == HighKick) && (AB[1] == HighKick)) i = 8;
		if(move == Punch) j = 0;
		if(move == LowKick) j = 1;
		if(move == HighKick) j = 2;
		NAB[i]++;
		NCAB[i][j]++;
		AB[0] = AB[1];
		AB[1] = move;
		if((AB[0] == Punch) && (AB[1] == Punch)) i = 0;
		if((AB[0] == Punch) && (AB[1] == LowKick)) i = 1;
		if((AB[0] == Punch) && (AB[1] == HighKick)) i = 2;
		if((AB[0] == LowKick) && (AB[1] == Punch)) i = 3;
		if((AB[0] == LowKick) && (AB[1] == LowKick)) i = 4;
		if((AB[0] == LowKick) && (AB[1] == HighKick)) i = 5;
		if((AB[0] == HighKick) && (AB[1] == Punch)) i = 6;
		if((AB[0] == HighKick) && (AB[1] == LowKick)) i = 7;
		if((AB[0] == HighKick) && (AB[1] == HighKick)) i = 8;
		ProbPunch = (double) NCAB[i][0] / (double) NAB[i];
		ProbLowKick = (double) NCAB[i][1] / (double) NAB[i];
		ProbHighKick = (double) NCAB[i][2] / (double) NAB[i];
		if((ProbPunch > ProbLowKick) &&
		(ProbPunch > ProbHighKick))
		return Punch;
		if((ProbLowKick > ProbPunch) &&
		(ProbLowKick > ProbHighKick))
		return LowKick;
		if((ProbHighKick > ProbPunch) &&
		(ProbHighKick > ProbLowKick))
		return HighKick;
		return (TStrikes) rand() % 3; // Last resort
			
		Example 13-3. Global variables
		int NAB[9];
		int NCAB[9][3];
		TStrikes AB[2];
		double ProbPunch;
		double ProbLowKick;
		double ProbHighKick;
		TStrikes Prediction;
		TStrikes RandomPrediction;
		int N;
		int NSuccess;
*/	
		eval_move(next_move,cpu_move);

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
