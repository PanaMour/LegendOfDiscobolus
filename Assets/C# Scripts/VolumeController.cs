using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        if (volumeSlider != null)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1.0f);
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }
    void Update() 
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && volumeSlider == null)
        {
            volumeSlider = GameObject.Find("PauseCanvas").transform.Find("VolumeSettings").transform.Find("Volume").transform.Find("VolumeSlider").transform.GetComponent<Slider>();
            GameObject.Find("PauseCanvas").SetActive(false);
            AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1.0f);
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
            
    }
    void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}
