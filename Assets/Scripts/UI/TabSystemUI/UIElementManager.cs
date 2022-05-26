using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIElementManager : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _element;

    private VisualElement Activity1;
    private Button Head1;

    private VisualElement Activity2;
    private Button Head2;

    private VisualElement Activity3;
    private Button Head3;

    private VisualElement Activity4;
    private Button Head4;

    #region Messages
    private VisualElement Room1;
    private Button _room1;

    private VisualElement Room2;
    private Button _room2;

    private VisualElement Room3;
    private Button _room3;

    private VisualElement Room4;
    private Button _room4;
    #endregion

    #region Examens
    private Button _examen;
    private Button _examen2;
    private Button _examen3;
    private Button _examen4;

    private VisualElement historySection;
    private Button _history;

    private VisualElement examSection;
    private Button _exam;
    #endregion


    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _element = _document.rootVisualElement;
    }

    void Start()
    {
        #region get All navigation actions
        Head1 = _element.Q<Button>("Action1");
        Activity1 = _element.Q<VisualElement>("Activity1");

        Head2 = _element.Q<Button>("Action2");
        Activity2 = _element.Q<VisualElement>("Activity2");

        Head3 = _element.Q<Button>("Action3");
        Activity3 = _element.Q<VisualElement>("Activity3");

        Head4 = _element.Q<Button>("Action4");
        Activity4 = _element.Q<VisualElement>("Activity4");

        Head1.clicked += Activity1Active;
        Head2.clicked += Activity2Active;
        Head3.clicked += Activity3Active;
        Head4.clicked += Activity4Active;
        #endregion

        #region get All messages actions
        Room1 = _element.Q<VisualElement>("General");
         Room2 = _element.Q<VisualElement>("Salle"); 
         Room3 = _element.Q<VisualElement>("Chambre1"); 
         Room4 = _element.Q<VisualElement>("Chambre2"); 

         _room1 = _element.Q<Button>("Rooms1");
        _room2 = _element.Q<Button>("Rooms2");
        _room3 = _element.Q<Button>("Rooms3");
        _room4 = _element.Q<Button>("Rooms4");

        _room1.clicked += () => ActiveMessagesScene(Room1, Room2, Room3, Room4);
        _room2.clicked += () => ActiveMessagesScene(Room2, Room1, Room3, Room4);
        _room3.clicked += () => ActiveMessagesScene(Room3, Room2, Room1, Room4);
        _room4.clicked += () => ActiveMessagesScene(Room4, Room2, Room3, Room1);
        #endregion

        #region Exams Manager

        _examen = _element.Q<Button>("Examen1");
        _examen2 = _element.Q<Button>("Examen2");
        _examen3 = _element.Q<Button>("Examen3");
        _examen4 = _element.Q<Button>("Examen4");

        _examen.clicked += ExamSceneLoad;
        _examen2.clicked += ExamSceneLoad;
        _examen3.clicked += ExamSceneLoad;
        _examen4.clicked += ExamSceneLoad;

        historySection = _element.Q<VisualElement>("HistorySection");
        examSection = _element.Q<VisualElement>("ExamsSection");

        _history = _element.Q<Button>("History");
        _exam = _element.Q<Button>("Exams");

        _history.clicked += () => 
        {
            historySection.style.display = DisplayStyle.Flex;
            examSection.style.display = DisplayStyle.None;
        };

        _exam.clicked += () =>
        {
            historySection.style.display = DisplayStyle.None;
            examSection.style.display = DisplayStyle.Flex;
        };
        #endregion

    }

    void ActiveMessagesScene(VisualElement activated1, VisualElement closed1, VisualElement closed2, VisualElement closed3)
    {
        activated1.style.display = DisplayStyle.Flex;
        closed1.style.display = DisplayStyle.None;
        closed2.style.display = DisplayStyle.None;
        closed3.style.display = DisplayStyle.None;
    }

    void Activity1Active()
    {
        Activity1.style.display = DisplayStyle.Flex;
        Activity2.style.display = DisplayStyle.None;
        Activity3.style.display = DisplayStyle.None;
        Activity4.style.display = DisplayStyle.None;
    }

    void Activity2Active()
    {
        Activity2.style.display = DisplayStyle.Flex;
        Activity1.style.display = DisplayStyle.None;
        Activity3.style.display = DisplayStyle.None;
        Activity4.style.display = DisplayStyle.None;
    }
    void Activity3Active()
    {
        Activity3.style.display = DisplayStyle.Flex;
        Activity2.style.display = DisplayStyle.None;
        Activity1.style.display = DisplayStyle.None;
        Activity4.style.display = DisplayStyle.None;
    }
    void Activity4Active()
    {
        Activity4.style.display = DisplayStyle.Flex;
        Activity3.style.display = DisplayStyle.None;
        Activity2.style.display = DisplayStyle.None;
        Activity1.style.display = DisplayStyle.None;
    }

    void ExamSceneLoad()
    {
        SceneManager.LoadScene(3);
    }
}
