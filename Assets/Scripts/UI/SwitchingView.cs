using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchingView : MonoBehaviour
{
    private bool Switched = false;
    [SerializeField] private GameObject FPS;
    [SerializeField] private GameObject TPS;

    [SerializeField] private GameObject FPSCAM;
    [SerializeField] private GameObject TPSCAM;


    private void Update()
    {
        SwitchView();
       // SwitchingCamera.instance.ChangeView(Switched);
    }

    private void SwitchView()
    {
        if (PlayerMoves.instance.GetPlayerSwitch())
        {
            Switched = !Switched;
            FPS.SetActive(Switched);
            FPSCAM.SetActive(Switched);
            
            TPS.SetActive(!Switched);
            TPSCAM.SetActive(!Switched);
        }
    }
    
}
