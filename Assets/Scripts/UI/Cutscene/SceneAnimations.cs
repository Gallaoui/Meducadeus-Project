using System.Collections;
using UnityEngine;

public class SceneAnimations : MonoBehaviour
{
    [SerializeField] private GameObject ScenePanel;
    [SerializeField] private HandlesData hd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SwitchOff());
        }
    }

    IEnumerator SwitchOff()
    {
        ScenePanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        hd.UserWay();
    }
}
