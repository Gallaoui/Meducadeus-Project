using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject Nurse;
    [SerializeField] private GameObject Student;
    void Update()
    {
        if (Nurse.activeSelf)
        {
            Vector3 mvs = new Vector3(Nurse.transform.position.x, this.transform.position.y, Nurse.transform.position.z); 
            this.transform.position = mvs;
            this.transform.rotation = Nurse.transform.rotation;
        }

        if (Student.activeSelf)
        {
            Vector3 mvs = new Vector3(Student.transform.position.x, this.transform.position.y, Student.transform.position.z);
            this.transform.position = mvs;
            this.transform.rotation = Student.transform.rotation;
        }
        
    }
}
