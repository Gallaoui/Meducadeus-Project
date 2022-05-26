using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientCaseCamera : MonoBehaviour
{
    [SerializeField] private GameObject PatientCamera;
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject PlayerMoves;
    [SerializeField] private GameObject ActionButton;
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private PlayerMoves pm;

    private bool StartedExamination;

    private void Update()
    {
        if (StartedExamination)
        {
            PatientCamera.SetActive(true);
            PlayerCamera.SetActive(false);
            PlayerPrefab.SetActive(false);
            PlayerMoves.SetActive(false);
            pm.OnDisable();
        }
        else
        {
            PatientCamera.SetActive(false);
            PlayerCamera.SetActive(true);
            PlayerPrefab.SetActive(true);
            PlayerMoves.SetActive(true);
            pm.OnEnable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActionButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActionButton.SetActive(false);
        }
    }

    public void StartPatientCamera()
    {
        StartedExamination = !StartedExamination;
        text.text = StartedExamination ? "Quitter" : "Action";
    }
}
