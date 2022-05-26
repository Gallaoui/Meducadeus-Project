using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeOrientation : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
