using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

	// make game manager public static so can access this from other scripts
	public static GameManager gm;
	public SpawnBlocks sb;

	public float startTime = 5.0f;
	public float countDtime = 3.0f;
	public Text mainTimerDisplay;
	public Text countDownTimer;
	public Text levelText;
	int levelNum = 1;
	public bool gameIsOver = false;
	private float currentTime;

	public GameObject GameOver;
	public GameObject ResetGame;
	public GameObject ExitGame;
	

	AudioSource music; 

	void Awake ()
	{
		music = GetComponent<AudioSource> ();
		countDownTimer.text = countDtime.ToString();
		levelText.text = "Level: " + levelNum;
		GameOver.SetActive (false);
		ResetGame.SetActive (false);
		ExitGame.SetActive (false);
	}

	// setup the game
	void Start ()
	{
		// set the current time to the startTime specified
		currentTime = startTime + 2.0f;
		// get a reference to the GameManager component for use by other scripts
		if (gm == null)
			gm = this.gameObject.GetComponent<GameManager> ();
		
	}

	// this is the main game event loop
	void Update ()
	{
		if (countDtime > 0) {
			countDtime -= Time.deltaTime;
			countDownTimer.text = countDtime.ToString ("0");
		} else { 
			countDownTimer.text = null;

			if (!gameIsOver) {
				if (GameObject.FindGameObjectWithTag ("Block") == null) {  // check to see if beat game
					BeatLevel ();
				} else if (currentTime < 0) { // check to see if timer has run out
					mainTimerDisplay.text = "0.00";
					EndGame ();
				} else { // game playing state, so update the timer
					currentTime -= Time.deltaTime;
					mainTimerDisplay.text = currentTime.ToString ("0.00");
				}
			}
		}
	}

	public void EndGame ()
	{
		// game is over
		gameIsOver = true;
		music.pitch = 0.5f;
		GameOver.SetActive (true);
		ResetGame.SetActive (true);
		ExitGame.SetActive (true);
		//mainTimerDisplay.text = "0.00";
		//return to menu

	}

	public void BeatLevel ()
	{
		sb.MakeBlocksSpawn ();
		levelNum++;
		levelText.text = "Level: " + levelNum;
		if (levelNum % 5 == 0)
		{	
			currentTime = startTime - (0.2f * levelNum) + 2.5f;
		}
		else
		{
			currentTime = startTime - (0.2f * levelNum);
		}
		mainTimerDisplay.text = currentTime.ToString ("0.00");
			
	}
		
	public void ResetLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
		
	// public function that can be called to exit the game
	public void ReturnToMainMenu ()
	{
		
		SceneManager.LoadScene ("MainMenu");

	}			
}