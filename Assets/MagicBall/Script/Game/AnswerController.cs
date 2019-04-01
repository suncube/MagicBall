using UnityEngine;
using System.Collections;

// answer logic
public class AnswerController
{
    private AnswerGroup answerGroup;
    public AnswerController(AnswerGroup answerGroup)
    {
        this.answerGroup = answerGroup;
    }

    public Answer GetAnswer()
    {
        return answerGroup.Answers[GetRandomAnswer()];
    }

    private int GetRandomAnswer()
    {
        Shuffle(answerGroup.Answers);
        return Random.Range(0, answerGroup.Answers.Length);
    }

    void Shuffle(Answer[] answers)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            var temp = answers[i];
            int randomIndex = Random.Range(0, answers.Length);
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;
        }
    }
}
