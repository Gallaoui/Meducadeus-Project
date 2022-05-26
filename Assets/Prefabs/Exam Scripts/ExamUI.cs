using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamUI : MonoBehaviour
{
    [SerializeField] private GameObject BeforeExamStartUI;
    [SerializeField] private GameObject DuringExamUI;
    [SerializeField] private GameObject BeforeExamEndUI;
    [SerializeField] private GameObject LaterListUI;
    [SerializeField] private GameObject AfterExamEndUI;

    [HideInInspector] public bool ExamStarted = false;

    ExamManager em;

    private void Start()
    {
        em = GetComponent<ExamManager>();
    }

    public void ExamIntroduction()
    {
        BeforeExamStartUI.SetActive(true);
        DuringExamUI.SetActive(false);
        AfterExamEndUI.SetActive(false);
        LaterListUI.SetActive(false);
        BeforeExamEndUI.SetActive(false);
    }

    public void ExamBody()
    {
        DuringExamUI.SetActive(true);
        BeforeExamStartUI.SetActive(false);
        AfterExamEndUI.SetActive(false);
        LaterListUI.SetActive(false);
        BeforeExamEndUI.SetActive(false);
    }

    public void ExamEnd()
    {
        BeforeExamEndUI.SetActive(true);
        DuringExamUI.SetActive(false);
        BeforeExamStartUI.SetActive(false);
        LaterListUI.SetActive(false);
        AfterExamEndUI.SetActive(false);
    }

    public void LaterExamList()
    {
        LaterListUI.SetActive(true);
        AfterExamEndUI.SetActive(false);
        DuringExamUI.SetActive(false);
        BeforeExamStartUI.SetActive(false);
        BeforeExamEndUI.SetActive(false);
    }

    public void ExamExit()
    {
        SceneManager.LoadScene(2);
    }

    public void ExamResult()
    {
        AfterExamEndUI.SetActive(true);
        LaterListUI.SetActive(false);
        BeforeExamEndUI.SetActive(false);
        DuringExamUI.SetActive(false);
        BeforeExamStartUI.SetActive(false);
        em.ResultList();
    }
}
