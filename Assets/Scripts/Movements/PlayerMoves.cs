using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public static PlayerMoves instance;

   // public PhotonView v;
    private Movements movements;
    private CharacterController characterController;
    private Animator animator;
    private float Walk;
    [SerializeField] private float transition = 2.0f;
    private Transform CameraTransform;
    private float turnSmooth;

    [SerializeField] private GameObject FPSCam;

    private void Awake()
    {
        instance = this;
        movements = new Movements();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

       // if(v.IsMine)
        CameraTransform = Camera.main.transform;
    }

    public CharacterController GetPlayerController()
    {
        return characterController;
    }

    public void OnEnable()
    {
        movements.Enable();
    }

    public void OnDisable()
    {
        movements.Disable();
    }

    void Update()
    {
       // if (v.IsMine)
      //  {
            Moving();
            CharacterAnimation();
       // }
    }

    void Moving()
    {
        Vector2 movementInput = GetPlayerMoves();

        float timing = Time.deltaTime * transition;

        if(movementInput.y > 0.0f)
        {
            if (Walk < 1.0f)
                Walk += timing;
        }

        if (movementInput.y < 0.0f)
        {
            if (Walk > -1.0f)
                Walk -= timing;
        }

        if (movementInput == Vector2.zero)
        {
            if (Walk > 0.0f)
                Walk -= timing;

            if (Walk < 0.0f)
                Walk += timing;
        }
        
        Vector3 moves = (CameraTransform.forward * movementInput.y + CameraTransform.right * movementInput.x);
        moves.y = 0f;
        characterController.Move(moves * Time.deltaTime);

        if((movementInput != Vector2.zero) || (FPSCam.gameObject.activeInHierarchy))
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(gameObject.transform.localEulerAngles.x, CameraTransform.localEulerAngles.y, gameObject.transform.localEulerAngles.z));
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotation, Time.deltaTime * 4f);
        }
    }

    void CharacterAnimation()
    {
        animator.SetFloat("Walk", Walk);
    }

    public Vector2 GetPlayerMoves()
    {
        return movements.Player.Moves.ReadValue<Vector2>();
    }

    public Vector2 GetPlayerLooks()
    {
        return movements.Player.Look.ReadValue<Vector2>();
    }

    public bool GetPlayerSwitch()
    {
        return movements.Player.View.triggered;
    }
}
