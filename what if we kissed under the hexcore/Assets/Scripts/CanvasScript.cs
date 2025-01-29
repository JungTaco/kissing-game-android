using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

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

	private float maxPoints = 100f;
	private float currentPoints;
	private float targetTimeTalking;
	private float targetTimeAttention = 0.5f;
	private float targetTimeTurned;
	private float targetTimeHandsDown;
	private float[] targetTimeTalkingArray;
	private int level = 0;

	void Start()
	{
		targetTimeTalkingArray = new float[3];
		targetTimeTalkingArray[0] = Random.Range(3f, 4f);
		targetTimeTalkingArray[1] = Random.Range(3f, 3.5f);
		targetTimeTalkingArray[2] = Random.Range(2f, 3f);
		targetTimeTalking = targetTimeTalkingArray[level];
		targetTimeTurned = Random.Range(3f, 4f);
		targetTimeHandsDown = 0.3f;
		currentPoints = 0.0f;
	}

	void Update()
    {	
		if (currentPoints >= maxPoints)
		{
			WinLevel();
		}
		if (!Win.activeInHierarchy)
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

	void TalkingTimerEnded()
	{
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
		targetTimeTurned = Random.Range(3f, 4f);
		targetTimeAttention = 0.5f;
		targetTimeHandsDown = 0.3f;
	}

	void StartKissing()
	{
		JayvikIdleRenderer.enabled = false;
		JayvikKissRenderer.enabled = true;
	}

	void EndKissing()
	{
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
