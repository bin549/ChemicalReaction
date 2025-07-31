using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    private AudioManager audioManager;
    private LabManager labManager;
    private UIManager uiManager;
    private float startTime;
    private float elapsedTime;
    private int score = 100;
    private bool isGameActive = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }]
        this.audioManager = FindObjectOfType<AudioManager>();
        this.labManager = FindObjectOfType<LabManager>();
        this.uiManager = FindObjectOfType<UIManager>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            this.labManager.NextStep();
        }
        if (isGameActive) {
            elapsedTime = Time.time - startTime;
            if (this.uiManager != null) {
                this.uiManager.UpdateTimeDisplay(GetFormattedTime());
            }
        }
    }

    public void StartTimer() {
        this.startTime = Time.time;
        this.elapsedTime = 0f;
        this.isGameActive = true;
    }
    
    public void StopTimer() {
        this.isGameActive = false;
    }
    
    public void DeductScore(int points = 5) {
        this.score = Mathf.Max(0, this.score - points);
        if (this.uiManager != null) {
            this.uiManager.UpdateScoreDisplay(score);
        }
    }
    
    public string GetFormattedTime() {
        int minutes = Mathf.FloorToInt(this.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(this.elapsedTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public int GetScore() {
        return this.score;
    }
    
    public float GetElapsedTime() {
        return this.elapsedTime;
    }
    
    public void ResetGame() {
        this.score = 100;
        this.elapsedTime = 0f;
        this.isGameActive = false;
    }
}