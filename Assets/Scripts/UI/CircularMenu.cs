using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularMenu : MonoBehaviour
{
    public List<MenuButton> Choices = new List<MenuButton>();
    private Vector2 TouchPosition;
    private Vector2 FromVectorTouch = new Vector2(0.5f, 1.0f);
    private Vector2 CircleCenter = new Vector2(0.5f, 0.5f);
    private Vector2 ToVectorTouch;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject menu;

    public int MenuItems;
    public int CurrentMenuItem;
    public Text title;
    private int OldMenuItem;

    private void Start()
    {
        MenuItems = Choices.Count;
        foreach (MenuButton button in Choices)
        {
            button.SceneImage.color = button.NormalColor;
        }
        CurrentMenuItem = 0;
        OldMenuItem = 0;
    }

    private void Update()
    {
        GetCurrentMenuItem();
        if (Input.GetButtonDown("Fire1"))
        {
            ButtonAction();
        }
    }

    public void GetCurrentMenuItem()
    {
        TouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        ToVectorTouch = new Vector2(TouchPosition.x / Screen.width, TouchPosition.y / Screen.height);
        float angle = (Mathf.Atan2(FromVectorTouch.y - CircleCenter.y, FromVectorTouch.x - CircleCenter.x) - Mathf.Atan2(ToVectorTouch.y - CircleCenter.y, ToVectorTouch.x - CircleCenter.x)) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle += 360;
        }

        CurrentMenuItem = (int)(angle / (360 / MenuItems));

        if (CurrentMenuItem != OldMenuItem)
        {
            Choices[OldMenuItem].SceneImage.color = Choices[OldMenuItem].NormalColor;
            OldMenuItem = CurrentMenuItem;
            Choices[CurrentMenuItem].SceneImage.color = Choices[CurrentMenuItem].HighlightedColor;
            title.text = Choices[CurrentMenuItem].title;
        }
    }

    public void ButtonAction()
    {
        Choices[CurrentMenuItem].SceneImage.color = Choices[CurrentMenuItem].PressedColor;
        StartCoroutine(setAction(CurrentMenuItem));
    }

    IEnumerator setAction(int _index)
    {
        menu.SetActive(false);
        yield return new WaitForSeconds(1f);
        animator.SetBool("T"+(_index + 1).ToString(), true);
        yield return new WaitForSeconds(4f);
        animator.SetBool("T" +(_index + 1).ToString(), false);
        menu.SetActive(true);
    }
}

[System.Serializable]
public class MenuButton
{
    public string title;
    public Image SceneImage;
    public Color NormalColor = Color.white;
    public Color HighlightedColor = Color.gray;
    public Color PressedColor = Color.gray;
}