using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
	public static UIHandler instance { get; private set; }

	private VisualElement bar;

	private void Awake()
	{
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		UIDocument uiDocument = GetComponent<UIDocument>();
		bar = uiDocument.rootVisualElement.Q<VisualElement>("Bar");
		SetHealthValue(0f);
	}

	public void SetHealthValue(float percentage)
	{
		bar.style.width = Length.Percent(100 * percentage);
	}
}
