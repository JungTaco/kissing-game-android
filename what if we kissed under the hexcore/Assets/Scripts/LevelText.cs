using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
	private TMP_Text text;
	private float targetTimeLevelText;
	private bool fadeOutRunning = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = "Level 1";
		targetTimeLevelText = 1f;
	}

    // Update is called once per frame
    void Update()
    {
		if (!fadeOutRunning && text.color.a >= 1)
		{
			targetTimeLevelText -= Time.deltaTime;
			if (targetTimeLevelText <= 0)
			{
				StartCoroutine(FadeOut(text));
			}
		}
	}

    public void Show()
    {
		StartCoroutine(FadeIn(text));
		ResetTimer();
	}

	public void SetText(string level_text)
	{
		text.text = level_text;
	}

	private IEnumerator FadeIn(TMP_Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
		while (text.color.a <= 1.0f)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime);
			yield return null;
		}
	}

	private IEnumerator FadeOut(TMP_Text text)
	{
		fadeOutRunning = true;
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
		while (text.color.a >= 0.0f)
		{
			
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime);
			yield return null;
		}
		fadeOutRunning = false;
	}

	private void ResetTimer()
	{
		targetTimeLevelText = 1f;
	}
}
