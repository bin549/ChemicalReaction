[System.Serializable]
public class QuestionOption {
    public int questionIndex;
    public string[] options;
    public int correctAnswerIndex;
    
    public QuestionOption(int index, string[] optionTexts, int correct = 0) {
        questionIndex = index;
        options = optionTexts;
        correctAnswerIndex = correct;
    }
} 