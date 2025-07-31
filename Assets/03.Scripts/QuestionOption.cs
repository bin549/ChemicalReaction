[System.Serializable]
public class QuestionOption {
    public int questionIndex;
    public string[] options;
    public int correctAnswerIndex;
    
    public QuestionOption(int index, string[] optionTexts, int correct = 0) {
        this.questionIndex = index;
        this.options = optionTexts;
        this.correctAnswerIndex = correct;
    }
} 