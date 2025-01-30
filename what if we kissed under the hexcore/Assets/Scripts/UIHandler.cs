using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
	public static UIHandler instance { get; private set; }

	private VisualElement bar;
	private VisualElement barBackground;

	private void Awake()
	{
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		UIDocument uiDocument = GetComponent<UIDocument>();
		bar = uiDocument.rootVisualElement.Q<VisualElement>("Bar");
		barBackground = uiDocument.rootVisualElement.Q<VisualElement>("BarBackground");
		SetHealthValue(0f);
	}

	public void SetHealthValue(float percentage)
	{
		bar.style.width = Length.Percent(100 * percentage);
	}

	public void HideUI()
	{
		barBackground.visible = false;
		bar.visible = false;
	}

	public void ShowUI()
	{
		barBackground.visible = true;
		bar.visible = true;
	}
}
