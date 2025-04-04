using MaskTransitions;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _levelsButton;
    [SerializeField] private Button _quitButton;

    private void Awake() 
    {
        _startButton.onClick.AddListener(StartButtonClicked);    
        _levelsButton.onClick.AddListener(LevelsButtonClicked);    
        _quitButton.onClick.AddListener(QuitButtonClicked);    
    }

    private void QuitButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        Application.Quit();
    }

    private void LevelsButtonClicked()
    {
        LevelsUI.Instance.OpenLevelsUI();
        return;
    }

    private void StartButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);
        PlayerPrefs.SetInt("PathOfStart", 0);
        TransitionManager.Instance.LoadLevel("GameScene");
    }
}
