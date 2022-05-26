using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandlesData : MonoBehaviour
{
    public int SceneNumber;

    public void UserWay()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
