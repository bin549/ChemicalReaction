[System.Serializable]
public class QuestionData {
    public int questionIndex;
    public string[] options;
    public int correctAnswerIndex;
    
    public QuestionData(int index, string[] answers, int correct, string explain = "") {
        questionIndex = index;
        options = answers;
        correctAnswerIndex = correct;
    }
} 