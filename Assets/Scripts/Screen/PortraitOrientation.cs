using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitOrientation : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
