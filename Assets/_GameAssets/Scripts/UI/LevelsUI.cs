using System;
using DG.Tweening;
using MaskTransitions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUI : MonoBehaviour
{
   public static LevelsUI Instance;

   [Header("References")]
   [SerializeField] private Button[] _buttonList;
   [SerializeField] private Button _levelsbutton;
   [SerializeField] private Button _exitButton;
   [SerializeField] private Button _nextPageButton;
   [SerializeField] private Button _beforePageButton;
   [SerializeField] private Animator _levelsAnimator;

   [SerializeField] private RectTransform[] _pageList;

   private int _currentPage = 1;

   private void Update() 
   {
      Debug.Log(_currentPage);   
   }
   private void Awake() 
   {
      Instance = this;

        foreach(Button e in _buttonList)
        {
           e.onClick.AddListener(() => 
           { 
              var level =  e.gameObject.GetComponentInChildren<TMP_Text>().text;
              OpenLevel(int.Parse(level));
           });
        } 
      _exitButton.onClick.AddListener(CloseLevelUI);
      _levelsbutton.onClick.AddListener(OpenLevelsUI);
      _nextPageButton.onClick.AddListener(NextPageButtonClicked);
      _beforePageButton.onClick.AddListener(BeforePageButtonClicked);
      SetButtonInteractable();
   }

    private void BeforePageButtonClicked()
    {
       if(_currentPage != 1)
       {
         _pageList[_currentPage - 1].DOScale(0f, 0.3f).SetEase(Ease.InBack);
         _currentPage--;
         _pageList[_currentPage - 1].DOScale(1f, 0.3f).SetEase(Ease.OutBack);
       }
    }

    private void NextPageButtonClicked()
    {
       if(_currentPage != 3)
       {
         _pageList[_currentPage - 1].DOScale(0f, 0.3f).SetEase(Ease.InBack);
         _currentPage++;
         _pageList[_currentPage - 1].DOScale(1f, 0.3f).SetEase(Ease.OutBack);
       }
    }

    public void SetButtonInteractable()
   {
     var a = PlayerPrefs.GetInt(Conts.Prefs.GLOBAL_LEVEL);
     for(int i = 0; i < a; i++)
     {
         _buttonList[i].interactable = true;
     }

     foreach (Button e in _buttonList)
     {
        if(e.interactable != true)
        {
          e.interactable = false;
        }
     }
   }

   private void OpenLevel(int level)
   {
      AudioManager.Instance.Play(SoundType.ButtonClickSound);

      PlayerPrefs.SetInt("levels", level);  
      PlayerPrefs.SetInt("PathOfStart", 1);
      
      TransitionManager.Instance.LoadLevel("GameScene");
   }

   public void OpenLevelsUI()
   {
      AudioManager.Instance.Play(SoundType.TransitionSound);

      _levelsAnimator.SetBool("Work", true);
      _levelsAnimator.SetBool("isOpen", true);
   }

   public void CloseLevelUI()
   {
      AudioManager.Instance.Play(SoundType.TransitionSound);

      _levelsAnimator.SetBool("Work", true);
      _levelsAnimator.SetBool("isOpen", false);
   }
}
