using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Slider susSlider;
    [SerializeField]
    private Slider demonicSlider;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (pauseMenu.activeSelf)
        {
            susSlider.value = PlayerStats.SuspicionPercent();
            demonicSlider.value = PlayerStats.DemonPercent();
        }
    }
}
