using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour {
    private LabManager labManager;
    private UIManager uiManager;
    private AudioManager audioManager;

    [SerializeField] private GameObject questionBubblePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private QuestionOption[] questionOptions;
    [SerializeField] private Button[] optionButtons;
    [SerializeField] private float bubbleSpacing = 100f;
    [SerializeField] private float regenerateInterval = 20f;

    private List<QuestionBubble> currentOptionBubbles = new List<QuestionBubble>();
    private int currentQuestionIndex = 0;
    private QuestionBubble selectedBubble;
    private int selectedOptionIndex = -1;
    private float nextRegenerateTime;
    private bool isQuestionActive = false;

    private void Awake() {
        this.labManager = FindObjectOfType<LabManager>();
        this.uiManager = FindObjectOfType<UIManager>();
        this.audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        this.uiManager.submitButton.onClick.AddListener(OnSubmitClicked);
        for (int i = 0; i < optionButtons.Length; i++) {
            int index = i;
            optionButtons[i].onClick.AddListener(() => SelectOption(index));
        }
    }

    private void Update() {
        if (isQuestionActive && Time.time >= nextRegenerateTime) {
            this.GenerateOptionBubbles();
            nextRegenerateTime = Time.time + regenerateInterval;
            if (GameManager.Instance != null) {
                GameManager.Instance.DeductScore(5);
            }
        }
    }

    public void InitializeQuestion(int questionIndex) {
        this.isQuestionActive = false;
        this.ClearCurrentBubbles();
        this.currentQuestionIndex = questionIndex;
        this.uiManager.submitButton.gameObject.SetActive(true);
        this.ShowCurrentQuestion();
    }

    private QuestionOption GetQuestionByIndex(int questionIndex) {
        for (int i = 0; i < questionOptions.Length; i++) {
            if (questionOptions[i].questionIndex == questionIndex) {
                return questionOptions[i];
            }
        }
        return null;
    }

    private void GenerateOptionBubbles() {
        this.ClearCurrentBubbles();
        QuestionOption currentQuestion = GetQuestionByIndex(currentQuestionIndex);
        if (currentQuestion == null) return;
        for (int i = 0; i < currentQuestion.options.Length; i++) {
            Vector3 bubblePosition = spawnPoint.position + Vector3.right * (i * bubbleSpacing);
            GameObject bubbleObj = Instantiate(questionBubblePrefab, bubblePosition, Quaternion.identity, spawnPoint);
            QuestionBubble bubble = bubbleObj.GetComponent<QuestionBubble>();
            QuestionData optionData = new QuestionData(i, new string[] { currentQuestion.options[i] }, 0);
            bubble.SetQuestionData(optionData);
            bubble.SetOptionIndex(i);
            currentOptionBubbles.Add(bubble);
        }
    }

    private void ClearCurrentBubbles() {
        foreach (QuestionBubble bubble in currentOptionBubbles) {
            if (bubble && bubble.gameObject) {
                Destroy(bubble.gameObject);
            }
        }
        this.currentOptionBubbles.Clear();
        this.selectedBubble = null;
        if (selectedOptionIndex != -1) {
        }
    }

    private void ShowCurrentQuestion() {
        QuestionOption currentQuestion = GetQuestionByIndex(currentQuestionIndex);
        if (currentQuestion == null) return;
        for (int i = 0; i < optionButtons.Length && i < currentQuestion.options.Length; i++) {
            TextMeshProUGUI buttonText = optionButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null) {
                buttonText.text = currentQuestion.options[i];
            }
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponent<Image>().color = Color.white;
        }
        for (int i = currentQuestion.options.Length; i < optionButtons.Length; i++) {
            optionButtons[i].gameObject.SetActive(false);
        }
        this.selectedOptionIndex = -1;
        this.selectedBubble = null;
        this.isQuestionActive = true;
        this.GenerateOptionBubbles();
        this.nextRegenerateTime = Time.time + regenerateInterval;
    }

    public void SelectQuestion(QuestionBubble bubble) {
        if (selectedBubble != null) {
            selectedBubble.SetSelected(false);
        }
        selectedBubble = bubble;
        bubble.SetSelected(true);
        selectedOptionIndex = bubble.GetOptionIndex();
        for (int i = 0; i < optionButtons.Length; i++) {
            optionButtons[i].GetComponent<Image>().color = (i == selectedOptionIndex) ? Color.cyan : Color.white;
        }
    }

    private void SelectOption(int index) {
        selectedOptionIndex = index;
        foreach (QuestionBubble bubble in currentOptionBubbles) {
            bubble.SetSelected(false);
        }
        if (index < currentOptionBubbles.Count) {
            currentOptionBubbles[index].SetSelected(true);
            selectedBubble = currentOptionBubbles[index];
        }
        for (int i = 0; i < optionButtons.Length; i++) {
            optionButtons[i].GetComponent<Image>().color = (i == index) ? Color.cyan : Color.white;
        }
    }

    private void OnSubmitClicked() {
        if (selectedOptionIndex == -1) return;
        QuestionOption currentQuestion = GetQuestionByIndex(currentQuestionIndex);
        if (currentQuestion == null) return;
        bool isCorrect = selectedOptionIndex == currentQuestion.correctAnswerIndex;
        if (isCorrect) {
            this.audioManager.PlayPassClip();
            this.isQuestionActive = false;
            this.ClearCurrentBubbles();
            if (this.currentQuestionIndex == 11) {
                this.uiManager.HideTestDetailPanel();
            }
            if (this.currentQuestionIndex == 13) {
                this.labManager.HideWoodStick();
            }
            this.currentQuestionIndex++;
            this.labManager.NextStep();
            Invoke(nameof(ShowNextQuestion), 0.0f);
        } else {
            this.uiManager.errorUI.gameObject.SetActive(true);
            this.audioManager.PlayErrorClip();
            if (GameManager.Instance != null) {
                GameManager.Instance.DeductScore(5);
            }
            selectedOptionIndex = -1;
            selectedBubble = null;
            for (int i = 0; i < optionButtons.Length; i++) {
                optionButtons[i].GetComponent<Image>().color = Color.white;
            }
            foreach (QuestionBubble bubble in currentOptionBubbles) {
                bubble.SetSelected(false);
            }
        }
    }

    private void ShowNextQuestion() {
        this.ShowCurrentQuestion();
    }
}