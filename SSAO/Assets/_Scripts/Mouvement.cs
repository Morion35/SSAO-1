using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    
	// Mouvement
	public float walkSpeed     = 6.0F;
	public float jumpSpeed     = 8.0F;
	public float gravity     = 20.0F;

	private Vector3 moveDirection = Vector3.back;
	private CharacterController controller;

	private Animator anim;
	// Camera
	public float rotateSpeed = 5;
	Vector3 offset;
    
	// Use this for initialization
	void Awake ()
	{
		controller = GetComponent<CharacterController>();
		offset = transform.position - transform.position;
		anim = GetComponent<Animator>();
	}
    
	// Update is called once per frame
	void LateUpdate () 
	{
		controller = GetComponent<CharacterController>();
		// Mouvement
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(h, 0, v).normalized;
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= walkSpeed;
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
				anim.SetTrigger("jump");
			}

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		anim.SetBool("iswalking", h != 0 ||v != 0);

		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		transform.Rotate(0, horizontal, 0);
 
		float desiredAngle = transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position -= (rotation * offset);
        
		transform.LookAt(transform);
	}
}