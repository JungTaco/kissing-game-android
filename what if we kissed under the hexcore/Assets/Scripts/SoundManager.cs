using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private Slider volumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Save()
    {
		PlayerPrefs.SetFloat("volume", volumeSlider.value);
	}

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
	}
}
