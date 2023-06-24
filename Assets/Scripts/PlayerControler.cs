using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Rigidbody physic;
    [SerializeField] Transform cameratransform;
    [SerializeField] Animator animator;
    [SerializeField] float speedmove, speedrotate,jump;
    bool isgraund;
    void Start()
    {
        
    }
    private void Walke()
    {
       if(!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharactorRun"))
        animator.Play("PlayerCharactorRun");
    }

    void paycastGraund()
    {
        
        for (int i = 0; i < 4; i++)
        {


            Ray ray = new Ray(transform.position, Vector3.down + (Random.insideUnitSphere / 2.5f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < 1.02)
                {
                    isgraund = true;
                }
                else
                {

                    isgraund = false;
                }
            }
        }

    }
    private void FixedUpdate()
    {

        paycastGraund();
        Movement();

    }

    private void Movement()
    {
        
        physic.AddForce(((transform.right * Input.GetAxisRaw("Horizontal") * speedmove * Time.deltaTime)
            + (transform.forward * Input.GetAxisRaw("Vertical") * speedmove * Time.deltaTime)*(Mathf.Abs( physic.velocity.y*0.05f)+1f)),ForceMode.VelocityChange);
        if (Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical") != 0)
        {
            Walke();
        }
    }

    void Update()
    {
        Rorateing();
        Jumping();
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            physic.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void Rorateing()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            cameratransform.Rotate(-Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * speedrotate, 0, 0);
            transform.Rotate(0, Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * speedrotate, 0);
        }
        else Cursor.lockState = CursorLockMode.None;
    }
}
