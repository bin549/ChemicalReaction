using UnityEngine;

public class LabManager : MonoBehaviour {
    public static LabManager Instance { get; private set; }

    private AudioManager audioManager;
    private UIManager uiManager;
    private int currentStepIndex = -1;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        this.audioManager = FindObjectOfType<AudioManager>();
        this.uiManager = FindObjectOfType<UIManager>();
    }

    public void NextStep() {
        this.currentStepIndex++;
        this.uiManager.ShowTipText(currentStepIndex);
        if (currentStepIndex == this.audioManager.TipAudioClips.Length) {
            this.OnLabConclude();
            return;
        }
        this.audioManager.PlayTipClip(currentStepIndex);
    }

    public void OnLabConclude() {
        this.uiManager.ShowConcludePanel();
        this.audioManager.PlayConcluedeClip();
    }
}