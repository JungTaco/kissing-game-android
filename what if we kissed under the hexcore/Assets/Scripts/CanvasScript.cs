using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public SpriteRenderer JayvikIdleRenderer;
	public SpriteRenderer JayvikKissRenderer;
	public SpriteRenderer HexcoreCalm;
	public SpriteRenderer HexcoreAggitated;
	public SpriteRenderer HeimerdingerFront;
	public SpriteRenderer HeimerdingerBack;
	public SpriteRenderer HeimerdingerAttention;
	public SpriteRenderer HeimerdingerHandsDown;
	public GameObject Win;
	public GameObject Lose;

	private float maxPoints = 100f;
	private float currentPoints;
	private float targetTimeTalking;
	private float targetTimeAttention = 0.5f;
	private float targetTimeTurned;
	private float targetTimeHandsDown;
	private float[] targetTimeTalkingArray;
	private float[] targetTimeTurnedArray;
	private int level = 0;
	private bool kissing = false;
	private bool turned = false;

	void Start()
	{
		targetTimeTalkingArray = new float[3];
		targetTimeTalkingArray[0] = UnityEngine.Random.Range(3f, 4f);
		targetTimeTalkingArray[1] = UnityEngine.Random.Range(3f, 3.5f);
		targetTimeTalkingArray[2] = UnityEngine.Random.Range(2f, 3f);
		targetTimeTalking = targetTimeTalkingArray[level];

		targetTimeTurnedArray = new float[3];
		targetTimeTurnedArray[0] = UnityEngine.Random.Range(3f, 4f);
		targetTimeTurnedArray[1] = UnityEngine.Random.Range(2.5f, 3f);
		targetTimeTurnedArray[2] = UnityEngine.Random.Range(2f, 2.5f);
		targetTimeTurned = targetTimeTurnedArray[level];
		targetTimeHandsDown = 0.3f;
		currentPoints = 0.0f;
	}

	void Update()
    {	
		if (currentPoints >= maxPoints)
		{
			if (level < 2)
				WinLevel();
			else
				WinGame();
		}

		if(kissing && !turned)
		{
			LoseGame();
		}

		if (!Win.activeInHierarchy && !Lose.activeInHierarchy)
		{
			if (Input.GetMouseButton(0))
			{
				StartKissing();
				SetPoints();
			}
			else
			{
				EndKissing();
			}

			targetTimeTalking -= Time.deltaTime;
			if (targetTimeTalking <= 0.0f)
			{
				TalkingTimerEnded();
				AttentionTimerStarted();
				TurnedTimerStarted();
			}
		}
	}

	public void Continue()
	{
		Win.SetActive(false);
		UIHandler.instance.ShowUI();
	}

	public void Restart()
	{
		Lose.SetActive(false);
		UIHandler.instance.ShowUI();
		//ResetSprites();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	void TalkingTimerEnded()
	{
		turned = true;
		HeimerdingerFront.enabled = false;
		HeimerdingerAttention.enabled = true;
		HexcoreCalm.enabled = false;
		HexcoreAggitated.enabled = true;
	}

	void AttentionTimerStarted()
	{
		targetTimeAttention -= Time.deltaTime;
		if (targetTimeAttention <= 0.0f)
		{
			AttentionTimerEnded();
		}
	}

	void AttentionTimerEnded()
	{
		HeimerdingerAttention.enabled = false;
		HeimerdingerBack.enabled = true;
	}

	void TurnedTimerStarted()
	{
		targetTimeTurned -= Time.deltaTime;
		if (targetTimeTurned <= 0.0f)
		{
			TurnedTimerEnded();
		}
	}

	void TurnedTimerEnded()
	{
		HeimerdingerBack.enabled = false;
		HeimerdingerHandsDown.enabled = true;
		HandsDownTimerStarted();
	}

	void HandsDownTimerStarted()
	{
		targetTimeHandsDown -= Time.deltaTime;
		if (targetTimeHandsDown <= 0.0f)
		{
			turned = false;
			HeimerdingerHandsDown.enabled = false;
			HeimerdingerFront.enabled = true;
			HexcoreAggitated.enabled = false;
			HexcoreCalm.enabled = true;
			ResetTimers();
		}
	}

	void ResetTimers()
	{
		targetTimeTalking = targetTimeTalkingArray[level];
		targetTimeTurned = targetTimeTurnedArray[level];
		targetTimeAttention = 0.5f;
		targetTimeHandsDown = 0.3f;
	}

	void ResetSprites()
	{
		//TO DO
	}

	void Reset()
	{
		currentPoints = 0;
		UIHandler.instance.SetHealthValue(0/100);
		ResetTimers();
	}

	void StartKissing()
	{
		kissing = true;
		JayvikIdleRenderer.enabled = false;
		JayvikKissRenderer.enabled = true;
	}

	void EndKissing()
	{
		kissing = false;
		JayvikIdleRenderer.enabled = true;
		JayvikKissRenderer.enabled = false;
	}

	void WinLevel()
	{
		Win.SetActive(true);
		if (level < 2)
		{
			level++;
		}
		Reset();
		UIHandler.instance.HideUI();
	}

	void WinGame()
	{
		Reset();
	}

	void LoseGame()
	{
		Lose.SetActive(true);
		level = 0;
		Reset();
		UIHandler.instance.HideUI();
	}

	void SetPoints()
	{
		if (currentPoints < maxPoints)
		{
			currentPoints += 0.05f;
		}
		UIHandler.instance.SetHealthValue(currentPoints / maxPoints);
	}
}
