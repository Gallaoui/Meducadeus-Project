using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UISystem : MonoBehaviour
{
    private UIDocument _document;
    
    [HideInInspector]
    public static VisualElement _background;    
    
    private VisualElement _element;

    private Button _closeButton;
    

    [SerializeField] private GameObject MenuIcon;

   // private ChatSystemManager db;


    #region ListView of messages
    private ListView _general;
    private ListView _salle;
    private ListView _chambre1;
    private ListView _chambre2;

    private TextField _input;
    private TextField _input2;
    private TextField _input3;
    private TextField _input4;

    private Button _button;
    private Button _button2;
    private Button _button3;
    private Button _button4;
    #endregion

    #region List of messages to be stored
    private List<string> general = null;
    private List<string> salle = null;
    private List<string> chambre1 = null;
    private List<string> chambre2 = null;
    #endregion


    private void OnEnable()
    {
        _document = GetComponent<UIDocument>();

        _element = _document.rootVisualElement;

        _background = _element.Q<VisualElement>("Background");
        
        _general = _element.Q<ListView>("MessagesList");
        _salle = _element.Q<ListView>("MessagesList2");
        _chambre1 = _element.Q<ListView>("MessagesList3");
        _chambre2 = _element.Q<ListView>("MessagesList4");

        _button = _element.Q<Button>("MessageButton");
        _button2 = _element.Q<Button>("MessageButton2");
        _button3 = _element.Q<Button>("MessageButton3");
        _button4 = _element.Q<Button>("MessageButton4");

        _input = _element.Q<TextField>("MessageInput");
        _input2 = _element.Q<TextField>("MessageInput2");
        _input3 = _element.Q<TextField>("MessageInput3");
        _input4 = _element.Q<TextField>("MessageInput4");


        _closeButton = _element.Q<Button>("Action5");

        _background.style.display = DisplayStyle.None;
    }

    private void Start()
    {
       /* db = GetComponent<ChatSystemManager>();

        LoadMessagesOnStart(db, general, "general", _general);
        LoadMessagesOnStart(db, salle, "salle", _salle);
        LoadMessagesOnStart(db, chambre1, "chambre1", _chambre1);
        LoadMessagesOnStart(db, chambre2, "chambre2", _chambre2);


        _button.clicked += () => MessageButtonPressed("general", _input);
        _button2.clicked += () => MessageButtonPressed("salle", _input2);
        _button3.clicked += () => MessageButtonPressed("chambre1", _input3);
        _button4.clicked += () => MessageButtonPressed("chambre2", _input4);*/
        _closeButton.clicked += CloseButtonPressed;
        
    }
    /*
    void LoadMessagesOnStart(ChatSystemManager db, List<string> items, string channelName, ListView _list)
    {
        // instantiate messages list for each channel
        items = new List<string>();

        void GetMessagesSent(Message msg)
        {
            items.Add($" {msg.user} : {msg.message}");
        }

        db.getMessages(GetMessagesSent, channelName);

        // The "makeItem" function will be called as needed
        // when the ListView needs more items to render
        Func<VisualElement> makeItem = () => new Label();

        // As the user scrolls through the list, the ListView object
        // will recycle elements created by the "makeItem"
        // and invoke the "bindItem" callback to associate
        // the element with the matching data item (specified as an index in the list)
        Action<VisualElement, int> bindItem = (e, i) =>
        {
            (e as Label).text = items[i];
            e.style.color = Color.white;
        };


        _list.makeItem = makeItem;
        _list.bindItem = bindItem;
        _list.itemsSource = items;
        _list.selectionType = SelectionType.Multiple;
    }*/
    /*
    void MessageButtonPressed(string channelName, TextField _input)
    {
        db.SendMessage(new Message(FirebaseConnection.instance.getUsername(), _input.value), () => print("message sent"), channelName);
        _input.value = "";
    }
    */
    private void Update()
    {
        _general.Refresh();
        _salle.Refresh();
        _chambre1.Refresh();
        _chambre2.Refresh();
    }

    void CloseButtonPressed()
    {
        _background.style.display = DisplayStyle.None;
        MenuIcon.SetActive(true);
    }
}
