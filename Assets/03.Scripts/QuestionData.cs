[System.Serializable]
public class QuestionData {
    public int questionIndex;
    public string[] options;
    public int correctAnswerIndex;
    
    public QuestionData(int index, string[] answers, int correct, string explain = "") {
        this.questionIndex = index;
        this.options = answers;
        this.correctAnswerIndex = correct;
    }
} 