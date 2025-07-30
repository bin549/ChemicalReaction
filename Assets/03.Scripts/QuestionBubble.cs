using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionBubble : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button bubbleButton;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private float moveSpeed = 50f;
    
    private QuestionData questionData;
    private int optionIndex = -1;
    private bool isSelected = false;
    private bool movementEnabled = true;
    private Color normalColor = Color.white;
    private Color selectedColor = Color.yellow;
    private Color normalTextColor = Color.black;
    private Color selectedTextColor = Color.green;
    private QuestionManager questionManager;
    
    private void Start() {
        bubbleButton.onClick.AddListener(OnBubbleClicked);
        questionManager = FindObjectOfType<QuestionManager>();
        if (questionText != null) {
            questionText.color = normalTextColor;
        }
    }
    
    private void Update() {
        if (movementEnabled) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            
            if (transform.position.x < -Screen.width) {
                Destroy(gameObject);
            }
        }
    }
    
    public void SetQuestionData(QuestionData data) {
        questionData = data;
        if (data.options != null && data.options.Length > 0) {
            questionText.text = data.options[0];
        }
    }
    
    public void SetOptionIndex(int index) {
        optionIndex = index;
    }
    
    public int GetOptionIndex() {
        return optionIndex;
    }
    
    public void SetMovementEnabled(bool enabled) {
        movementEnabled = enabled;
    }
    
    private void OnBubbleClicked() {
        if (questionManager != null) {
            questionManager.SelectQuestion(this);
        }
    }
    
    public void SetSelected(bool selected) {
        isSelected = selected;
        backgroundImage.color = selected ? selectedColor : normalColor;
        if (questionText != null) {
            questionText.color = selected ? selectedTextColor : normalTextColor;
        }
    }
    
    public QuestionData GetQuestionData() {
        return questionData;
    }
    
    public bool IsSelected() {
        return isSelected;
    }
} 