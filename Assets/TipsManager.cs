using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private GameObject Tip1;
    [SerializeField] private GameObject Tip2;
    [SerializeField] private GameObject Tip3;

    [SerializeField] private Button Tip1_b;
    [SerializeField] private Button Tip2_b;
    [SerializeField] private Button Tip3_b;

    private void Start()
    {
        Tip1_b.onClick.AddListener( () => { DestroyObjectTip(Tip1, Tip2, Tip1_b); });
        Tip2_b.onClick.AddListener(() => { DestroyObjectTip(Tip2, Tip3, Tip2_b); });
        Tip3_b.onClick.AddListener(() => { Tip3.SetActive(false); Destroy(Tip3_b.gameObject); });
    }

    void DestroyObjectTip(GameObject obj, GameObject Nobj ,Button btn)
    {
        obj.SetActive(false);

        if(Nobj != obj) Nobj.SetActive(true); else Nobj.SetActive(false);

        Destroy(btn.gameObject);
    }
}
