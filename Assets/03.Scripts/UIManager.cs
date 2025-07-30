using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }
    
    [SerializeField] private Image bgImage;

    [SerializeField] private Button startButton;
    [SerializeField] private Button endButton;

    [SerializeField] private GameObject[] rulePanels;
    [SerializeField] private GameObject questionSystemPanel;
    [SerializeField] private GameObject[] tipTexts;
    private AudioManager audioManager;
    private LabManager labManager; 
    private int currentRulePanelIndex = 0;
    [SerializeField] private GameObject concludePanel;
    [SerializeField] private GameObject finishPanel;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        this.audioManager = FindObjectOfType<AudioManager>();
        this.labManager = FindObjectOfType<LabManager>();
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
        this.concludePanel.SetActive(true);
    }

    public void ShowEndButton() {
        this.audioManager.StopPlayAudio();
        this.concludePanel.SetActive(false);
        this.endButton.gameObject.SetActive(true);
    }
    
    public void OnEndButtonClicked() {
        this.endButton.gameObject.SetActive(false);
        this.finishPanel.SetActive(true);
        this.audioManager.PlayFinishClip();
    }

    public void ShowQuestionSystem() {
        if (questionSystemPanel != null) {
            questionSystemPanel.SetActive(true);
        }
    }

    public void HideQuestionSystem() {
        if (questionSystemPanel != null) {
            questionSystemPanel.SetActive(false);
        }
    }

    public void ToggleQuestionSystem() {
        if (questionSystemPanel != null) {
            questionSystemPanel.SetActive(!questionSystemPanel.activeSelf);
        }
    }
    
}