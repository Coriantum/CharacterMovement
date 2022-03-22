using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float jumpHeight = 1.2f;

    private CharacterController charController;
    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion de inputs
        Vector3 movementImput = Input.GetAxisRaw("Vertical") * Vector3.forward;
        movementImput= transform.TransformDirection(movementImput);

        if(Input.GetButtonDown("Jump") && charController.isGrounded){
            //Establecemos la velocidad de salto necesaria para alcanzar la altura definida en jumpHeight

            playerVelocity.y= Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
        }
        

        // Gestion de movimiento
        playerVelocity.x = movementImput.x * forwardSpeed;
        playerVelocity.z = movementImput.z * forwardSpeed;

        //Gestion de gravedad
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;

        //Aplicamos movimiento
        charController.Move(playerVelocity * Time.deltaTime);
    }
}

public enum PlayerState{
    Idle,
    Run,
    Jump,
    Fall
}
