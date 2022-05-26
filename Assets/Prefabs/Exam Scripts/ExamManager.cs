using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ExamManager : MonoBehaviour
{
    [SerializeField] private GameObject ChosenAnswersPrefab;
    [SerializeField] private GameObject ChosenAnswerPrefab;
    [SerializeField] private GameObject ChosenAnswersContent;
    [SerializeField] private Sprite CheckedBox;
    [SerializeField] private Sprite unCheckedBox;

    [SerializeField] private GameObject LaterQuestionPrefab;
    [SerializeField] private GameObject QuestionsBox;

    [SerializeField] private GameObject Answers;
    [SerializeField] private GameObject AnswerPrefab;

    [SerializeField] private GameObject ExaManager;

    [SerializeField] private TMPro.TMP_Text QuestionTitle;

    [SerializeField] private Exam ExamQuestions;

    private int TotalScore = 0;
    [SerializeField] private TMPro.TMP_Text Score;

    private int index = 0;
            int Lindex = 0;
    private List<Questions> LaterQuestions = null;
    private ExamUI examUI;

    private void Awake()
    {
        examUI = GetComponent<ExamUI>();

        for(int i = 0; i < ExamQuestions.questions.Count; i++)
        {
            ExamQuestions.questions[i].QuestionId = i;
            for(int j = 0; j < ExamQuestions.questions[i].Answers.Count; j++)
            {
                ExamQuestions.questions[i].Answers[j].isChecked = false;
            }
        }
        
        LaterQuestions = new List<Questions>();
        examUI.ExamIntroduction();
        CreateQuestion();
    }

    #region Questions Control

    public void NextQuestion()
    {
        if (index < ExamQuestions.questions.Count -1)
        {
            index++;
            print(index);
        }
        else
        {
            examUI.ExamEnd();
        }

        CreateQuestion();
    }

    public void PreviousQuestion()
    {
        if (index > 0)
        {
            index--;
            print(index);
        }
        else
        {
            examUI.ExamIntroduction();
        }

        CreateQuestion();
    }
    

    public void ClearQuestion()
    {
        QuestionTitle.text = "";
        for (int i = 0; i< Answers.transform.childCount; i++)
        {
            Destroy(Answers.transform.GetChild(i).gameObject);
        }
    }
    #endregion

    public void CreateQuestion()
    {
        ClearQuestion();

        QuestionTitle.text = ExamQuestions.questions[index].QuestionTitle;

        for(int i = 0; i < ExamQuestions.questions[index].Answers.Count; i++)
        {
            GameObject AP = Instantiate(AnswerPrefab, Answers.transform);
            AP.transform.Find("Info").gameObject.GetComponent<TMPro.TMP_Text>().text = ExamQuestions.questions[index].Answers[i].AnswerTitle;
            AP.GetComponent<Button>().onClick.AddListener(() =>
            {
                ChosenAnswer(AP.transform.Find("Checkbox").gameObject, index, AP.transform.GetSiblingIndex());
            });
        }
    }

    #region Later Questions Section
    public void LaterQuestion()
    {
        if (!LaterQuestions.Contains(ExamQuestions.questions[index]))
        {
            LaterQuestions.Add(ExamQuestions.questions[index]);
            CreateLaterQuestions(index);
        }
        else
        {
            return;
        }
    }

    public void CreateLaterQuestions(int iss)
    {
            GameObject AP = Instantiate(LaterQuestionPrefab, QuestionsBox.transform);
            AP.transform.Find("index").gameObject.GetComponent<TMPro.TMP_Text>().text = (Lindex + 1).ToString() + " -- ";
            AP.transform.Find("Question Title").gameObject.GetComponent<TMPro.TMP_Text>().text = LaterQuestions[Lindex].QuestionTitle;
            AP.transform.Find("Button").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {ExaManager.GetComponent<ExamManager>().LaterListIndex(iss);});
        Lindex++;

        //print();
    }

    public void LaterListIndex(int Index)
    {
        index = Index;
        CreateQuestion();
        examUI.ExamBody();
    }
    #endregion

    public void ChosenAnswer(GameObject Answer, int QuestionIndex, int AnswerIndex)
    {
        if (Answer.GetComponent<Image>().sprite == unCheckedBox)
        {
            Answer.GetComponent<Image>().sprite = CheckedBox;
            ExamQuestions.questions[QuestionIndex].Answers[AnswerIndex].isChecked = true;
        }
        else
        {
            Answer.GetComponent<Image>().sprite = unCheckedBox;
            ExamQuestions.questions[QuestionIndex].Answers[AnswerIndex].isChecked = false;
        }
    }

     public void ResultList()
     {
        
        for (int i = 0; i < ExamQuestions.questions.Count; i++)
         {
            GameObject QuestionsAnswer = Instantiate(ChosenAnswersPrefab, ChosenAnswersContent.transform);
            QuestionsAnswer.transform.Find("Info").GetComponent<TMPro.TMP_Text>().text = ExamQuestions.questions[i].QuestionTitle;

            for(int j = 0; j < ExamQuestions.questions[i].Answers.Count; j++)
            {
                GameObject QuestionsAnswerCopy = Instantiate(ChosenAnswerPrefab, QuestionsAnswer.transform.Find("AnswersContent"));

                QuestionsAnswerCopy.transform.Find("Info").GetComponent<TMPro.TMP_Text>().text = ExamQuestions.questions[i].Answers[j].AnswerTitle;
                QuestionsAnswerCopy.transform.Find("Checkbox").GetComponent<Image>().sprite = unCheckedBox;
                QuestionsAnswerCopy.GetComponent<Image>().color = new Color(0, 0, 0, .5f);

                if (ExamQuestions.questions[i].Answers[j].isChecked)
                {
                    if (ExamQuestions.questions[i].Answers[j].isCorrect)
                    {
                        QuestionsAnswerCopy.transform.Find("Checkbox").GetComponent<Image>().sprite = CheckedBox;
                        QuestionsAnswerCopy.GetComponent<Image>().color = new Color(0, 1.0f, 0, .5f);
                        TotalScore++;
                    }
                    if (!ExamQuestions.questions[i].Answers[j].isCorrect)
                    {
                        QuestionsAnswerCopy.transform.Find("Checkbox").GetComponent<Image>().sprite = CheckedBox;
                        QuestionsAnswerCopy.GetComponent<Image>().color = new Color(1.0f, 0, 0, .5f);
                    }
                }

                if (ExamQuestions.questions[i].Answers[j].isCorrect)
                {
                    QuestionsAnswerCopy.GetComponent<Image>().color = new Color(0, 1.0f, 0, .5f);
                }
            }

        }
        Score.text += TotalScore.ToString()+"/3";

    } 
}