using DG.Tweening;
using MaskTransitions;
using UnityEngine;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
   public static WinPopup Instance;

   [Header("References")]
   [SerializeField] private Button _mainMenuButton;
   [SerializeField] private Button _nextLevelButton;

   private void Awake() 
   {
        Instance = this;
        _mainMenuButton.onClick.AddListener(MainMenuReturnButtonClicked); 
        _nextLevelButton.onClick.AddListener(NextLevelButtonClicked); 
   }

    private void MainMenuReturnButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);

        TransitionManager.Instance.LoadLevel("MainMenuScene");
    }

    private void NextLevelButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        LevelManager.Instance.UpdateNextCurrentLevel();
        LevelManager.Instance.SetLevel();
    }


    public void OpenWinPopup()
    {
        this.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
        AudioManager.Instance.Play(SoundType.WinSound);
        if(LevelManager.Instance.GetCurrentLevel() == 36)
        {
            _nextLevelButton.interactable = false;
        }
        else 
        _nextLevelButton.interactable = true;
    }

    public void CloseWinPopup()
    {
        this.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack);     
    }
}
