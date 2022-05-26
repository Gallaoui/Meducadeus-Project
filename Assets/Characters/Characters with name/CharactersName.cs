using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersName : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Text PlayerName;
    

    private void Awake()
    {
        PlayerName.text = FirebaseConnection.instance.getUsername();
    }
}
