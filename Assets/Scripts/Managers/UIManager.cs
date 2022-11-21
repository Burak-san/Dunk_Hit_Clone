using System.Threading.Tasks;
using Controllers.UI;
using Enums;
using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI gainScoreText;
        [SerializeField] private TextMeshProUGUI comboText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreStartPanel;
        [SerializeField] private TextMeshProUGUI highScoreFailPanel;
        [SerializeField] private TextMeshProUGUI maxComboScoreStartPanel;
        [SerializeField] private TextMeshProUGUI maxComboScoreFailPanel;
        [SerializeField] private UIPanelController uıPanelController;
        [SerializeField] private GamePanelController gamePanelController;
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onSetScoreText += OnSetScoreText;
            UISignals.Instance.onSetGainScoreText += OnSetGainScoreText;
            UISignals.Instance.onSetHighScoreText += OnSetHighScoreText;
            UISignals.Instance.onSetTimeSliderValue += OnSetTimeSliderValue;
            UISignals.Instance.onCheckClickable += OnCheckClickable;
            UISignals.Instance.onSetMaxComboScore += OnSetMaxComboScore;
            
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;

        }
        private void UnSubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onSetScoreText -= OnSetScoreText;
            UISignals.Instance.onSetGainScoreText -= OnSetGainScoreText;
            UISignals.Instance.onSetHighScoreText -= OnSetHighScoreText;
            UISignals.Instance.onSetTimeSliderValue -= OnSetTimeSliderValue;
            UISignals.Instance.onCheckClickable -= OnCheckClickable;
            UISignals.Instance.onSetMaxComboScore -= OnSetMaxComboScore;
                
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            
        }

        private void OnCheckClickable()
        {
            gamePanelController.OnCheckClickable();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void OnSetTimeSliderValue()
        {
            gamePanelController.GainTimeSliderValue();
        }
        
        private void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.GamePanel);
        }
        
        

        private void OnSetScoreText(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        
        private async void OnSetGainScoreText(int gainScore,int Combo)
        {
            gainScoreText.gameObject.SetActive(true);
            
            if (gainScore == 8)
            {
                comboText.gameObject.SetActive(true);
                comboText.text = "Combo: " + Combo.ToString();
                gainScoreText.text = "PERFECT SHOT!!!!!!!!!: +" + gainScore.ToString();
            }
            else if (gainScore == 4)
            {
                gainScoreText.text = "AMAZING!!!!: +" + gainScore.ToString();
                comboText.gameObject.SetActive(false);
            }
            else if (gainScore == 2)
            {
                gainScoreText.text = "NICE: +" + gainScore.ToString();
                comboText.gameObject.SetActive(false);
            }
            else
            {
                gainScoreText.text = "+" + gainScore.ToString();
                comboText.gameObject.SetActive(false);
            }
            await Task.Delay(1000);
            gainScoreText.gameObject.SetActive(false);
        }

        private void OnSetMaxComboScore(int score)
        {
            maxComboScoreFailPanel.text = "Max Combo: " + score.ToString();
            maxComboScoreStartPanel.text = "Max Combo: " + score.ToString();
        }
        
        private void OnSetHighScoreText(int score)
        {
            highScoreStartPanel.text = "High Score: " + score.ToString();
            highScoreFailPanel.text = "High Score: " + score.ToString();
        }
        
        private void OnOpenPanel(UIPanels panel)
        {
            uıPanelController.OpenPanel(panel);
        }

        private void OnClosePanel(UIPanels panel)
        {
            uıPanelController.ClosePanel(panel);
        }

        public void PlayButton()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        public void RestartButton()
        {
            CoreGameSignals.Instance.onReset?.Invoke();
        }
        
        private void OnReset()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.GamePanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.FailPanel);
            
            gamePanelController.SetGamePanel();
            comboText.gameObject.SetActive(false);
        }
    }
}