using DG.Tweening;
using MaskTransitions;
using UnityEngine;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
    public static LosePopup Instance;
    [Header("References")]
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _tryAgainButton;

    private void Awake() 
    {
        Instance = this;
        _mainMenuButton.onClick.AddListener(MainMenuButtonClicked);    
        _tryAgainButton.onClick.AddListener(TryAgainButtonClicked);    
    }

    private void TryAgainButtonClicked()
    {
       AudioManager.Instance.Play(SoundType.ButtonClickSound);
       LevelManager.Instance.SetLevel();
    }

    private void MainMenuButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);

        TransitionManager.Instance.LoadLevel("MainMenuScene");
    }

    public void OpenLosePopup()
    {
        this.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
        AudioManager.Instance.Play(SoundType.LoseSound);
    }

    public void CloseLosePopup()
    {
       this.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack);
    }
}
