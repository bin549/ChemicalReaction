using UnityEngine;

public class LabManager : MonoBehaviour {
    public static LabManager Instance { get; private set; }

    private AudioManager audioManager;
    private UIManager uiManager;
    private int currentStepIndex = -1;
    private bool isWorking = true;
    [Header("Step 01")]
    private int fillTestTubeCount = 0;
    public bool isStep01Done = false;
    [SerializeField] private GameObject resetArea;
    public int aluminiumFallCount = 0;
    public bool isStep02Done = false;

    public int CurrentStepIndex => currentStepIndex;
    
    public bool IsWorking {
        get => isWorking;
        set => isWorking = value;
    }

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

    public void IncrementTestTubeCount() {
        this.fillTestTubeCount++;
        if (this.fillTestTubeCount == 2) {
            this.isStep01Done = true;
            this.resetArea.SetActive(true); 
        }
    }
}