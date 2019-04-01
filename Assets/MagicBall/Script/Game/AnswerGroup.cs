using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AnswerGroup
{
    public int ID;
    public string Name;
    public Answer[] Answers;
}

[System.Serializable]
public class Answer
{
    public string TextKey;
  //  public Image Image;
}