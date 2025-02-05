using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Texture2D PointerCursor;

	public void OnPointerClick(PointerEventData eventData)
	{
		Application.OpenURL("www.instagram.com/iroismart");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Cursor.SetCursor(PointerCursor, Vector2.zero, CursorMode.Auto);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
