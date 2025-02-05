using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Hyperlink : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		TMP_Text text = GetComponent<TMP_Text>();
		int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, Camera.main);
		if (linkIndex != -1)
		{
			Application.OpenURL("www.instagram.com/iroismart");
		}
	}
}
