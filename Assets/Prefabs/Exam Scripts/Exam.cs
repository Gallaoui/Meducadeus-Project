using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="New Exam", menuName ="New Exam")]
public class Exam : ScriptableObject
{
    public List<Questions> questions;

}

[System.Serializable]

public class Questions
{
    [HideInInspector]public int QuestionId;
    public string QuestionTitle;
    public List<Answer> Answers = null;
}

[System.Serializable]
public class Answer
{
    public string AnswerTitle;

    public bool isCorrect = false;

    public int QuestionScore = 0;

    public bool isChecked = false;

}
