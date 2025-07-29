using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }
    
    [SerializeField] private Image bgImage;

    [SerializeField] private Button startButton;

    [SerializeField] private GameObject[] rulePanels;
    private AudioManager audioManager;
    private int currentRulePanelIndex = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        this.audioManager = AudioManager.Instance;
    }

    public void OnStartButtonClicked() {
        this.bgImage.gameObject.SetActive(false);
        this.startButton.gameObject.SetActive(false);
        this.ShowRulePanel(currentRulePanelIndex);
        // this.audioManager.PlayRuleClip(currentRulePanelIndex);
    }

    public void OnRulePanelButtonClicked() {
        currentRulePanelIndex++;
        this.ShowRulePanel(currentRulePanelIndex);
        // this.audioManager.PlayRuleClip(currentRulePanelIndex);
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
}