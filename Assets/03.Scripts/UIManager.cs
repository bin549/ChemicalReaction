using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
 
public class UIManager : MonoBehaviour {
    [SerializeField] private Image bgImage;
    [SerializeField] private Button startButton;
    [SerializeField] private Button endButton;
    [SerializeField] private GameObject[] rulePanels;
    [SerializeField] private GameObject tipPanel;
    [SerializeField] private GameObject[] tipTexts;
    [SerializeField] private GameObject concludePanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject bannerPanel;
    [SerializeField] private GameObject footPanel;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    public Button submitButton;
    [SerializeField] private GameObject testDetailPanel;

    private AudioManager audioManager;
    private LabManager labManager; 
    private int currentRulePanelIndex = 0;
    public ErrorUI errorUI;

    private void Awake() {
        this.audioManager = FindObjectOfType<AudioManager>();
        this.labManager = FindObjectOfType<LabManager>();
    }
    
    private void Start() {
        UpdateTimeDisplay("00:00");
        UpdateScoreDisplay(100);
        Invoke(nameof(PlayStartAudio), 0.1f);
    }

    public void PlayStartAudio() {
        this.audioManager.PlayStartClip();
    }

    public void OnStartButtonClicked() {
        this.bgImage.gameObject.SetActive(false);
        this.startButton.gameObject.SetActive(false);
        this.ShowRulePanel(currentRulePanelIndex);
        this.audioManager.PlayRuleClip(currentRulePanelIndex);
    }

    public void OnRulePanelButtonClicked() {
        currentRulePanelIndex++;
        this.ShowRulePanel(currentRulePanelIndex);
        this.audioManager.PlayRuleClip(currentRulePanelIndex);
        if (currentRulePanelIndex == this.audioManager.RuleAudioClips.Length) {
            this.ShowBanelPanel();
            this.ShowTipPanel();
            this.ShowFootPanel();
            if (GameManager.Instance != null) {
                GameManager.Instance.StartTimer();
            }
            this.labManager.NextStep();
            this.labManager.IsWorking = true;
        }
    }

    public void ShowRulePanel(int index) {
        if (rulePanels == null) return;
        for (int i = 0; i < rulePanels.Length; i++) {
            rulePanels[i].SetActive(i == index);
        }
        if (index >= 0 && index < rulePanels.Length) {
            currentRulePanelIndex = index;
        }
    }

    public void ShowTipText(int index) {
        if (tipTexts == null) return;
        for (int i = 0; i < tipTexts.Length; i++) {
            tipTexts[i].SetActive(i == index);
        }
    }

    public void ShowConcludePanel() {
        if (GameManager.Instance != null) {
            GameManager.Instance.StopTimer();
            if (finalTimeText != null) {
                finalTimeText.text = "用时: " + GameManager.Instance.GetFormattedTime();
            }
            if (finalScoreText != null) {
                finalScoreText.text = "得分: " + GameManager.Instance.GetScore();
            }
        }
        this.bannerPanel.gameObject.GetComponent<Animator>().SetTrigger("hide");
        this.footPanel.gameObject.GetComponent<Animator>().SetTrigger("hide");
        this.concludePanel.SetActive(true);
    }

    public void ShowEndButton() {
        this.audioManager.PlayEndClip();
        this.concludePanel.SetActive(false);
        this.endButton.gameObject.SetActive(true);
    }
    
    public void OnEndButtonClicked() {
        this.endButton.gameObject.SetActive(false);
        this.finishPanel.SetActive(true);
        this.audioManager.PlayFinishClip();
    }
    
    public void OnFinishButtonClicked() {
        if (GameManager.Instance != null) {
            GameManager.Instance.ResetGame();
        }
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
    
    public void UpdateTimeDisplay(string timeString) {
        if (timeText != null) {
            timeText.text = timeString;
        }
    }
    
    public void UpdateScoreDisplay(int score) {
        if (scoreText != null) {
            scoreText.text = score.ToString();
        }
    }

    public void ShowTipPanel() {
        this.tipPanel.SetActive(true);
    }

    public void ShowBanelPanel() {
        this.bannerPanel.SetActive(true);
    }

    public void ShowFootPanel() {
        this.footPanel.SetActive(true);
    }
    
    public void HideSubmitButton() {
        this.submitButton.gameObject.SetActive(false);
    }
    
    public void ShowTestDetailPanel() {
        this.testDetailPanel.SetActive(true);
    }
    
    public void HideTestDetailPanel() {
        this.testDetailPanel.gameObject.GetComponent<Animator>().SetTrigger("hide");
    }
}