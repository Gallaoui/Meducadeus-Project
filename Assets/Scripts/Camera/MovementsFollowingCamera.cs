using UnityEngine;
using Cinemachine;


public class MovementsFollowingCamera : MonoBehaviour
{
    [SerializeField] private int CameraNumber = 0;
    private CinemachineFreeLook cinemachine1;
    private CinemachineVirtualCamera cinemachine2;
    [SerializeField] private float Xspeed = 200f;
    [SerializeField] private float Yspeed = 1f;
    private void Start()
    {
        if(CameraNumber == 0)
            cinemachine1 = GetComponent<CinemachineFreeLook>();
        else
            cinemachine2 = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        Vector2 delta = PlayerMoves.instance.GetPlayerLooks();
        
        if(CameraNumber == 0)
        {
            cinemachine1.m_XAxis.Value += delta.x * Xspeed * Time.deltaTime;
            cinemachine1.m_YAxis.Value += delta.y * Yspeed * Time.deltaTime;
        }
        else
        {
            cinemachine2.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value += -delta.y * Xspeed * Time.deltaTime;
            cinemachine2.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value += delta.x * Yspeed * Time.deltaTime;
        }

    }

}
