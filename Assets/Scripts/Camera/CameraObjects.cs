using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjects : MonoBehaviour
{
  /*  [SerializeField] private GameObject[] objects;
    [SerializeField] private Camera camera;

    private int index = 0;

    private void LateUpdate()
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, objects[index].transform.position, .5f);
    }

    public void NextObject()
    {
        MoveCam(1);
    }
    
    public void PreviousObject()
    {
        MoveCam(-1);
    }

    private void MoveCam(int Index)
    {
        index += Index;

        index = (index < 0) ? objects.Length - 1 : index;
        index = (index >= objects.Length) ? 0 : index;
    }*/
}
