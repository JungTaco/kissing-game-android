using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
	public static MenuControl instance { get; private set; }
	public GameObject Menu;

	private void Awake()
	{
		instance = this;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void HideMenu() => Menu.SetActive(false);
}
