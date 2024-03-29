using UnityEngine;
using System.Collections;


// makes sure that it has the rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class Player_Motor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	// Veclocity receoved from the player controller
	private Vector3 velocity = Vector3.zero;
	//rotation received from the player controller
	private Vector3 rotation = Vector3.zero;
	// camera rotaion received from the player controller
	private Vector3 camera_rotation = Vector3.zero;

	// TO handle the rigid body opsition functions without changing physics
	private Rigidbody rb;

	//initialize
	void Start()
	{
		// no need of gameObject as it is being taked care by the requireComponent
		rb = GetComponent<Rigidbody> ();



	}


	// perform movement based on veclocity received by PlayerController
	public void move(Vector3 _velocity)
	{
		velocity = _velocity;
		PerformMovement ();
	}

	// perform rotation based on rotation received by the PlayerController
	public void rotate(Vector3 _rotation)
	{
		rotation = _rotation;
		PerformRotation ();
	}

	// perform camera rotation based on the rotation received by the Player Controller
	public void rotateCamera(Vector3 _camera_rotation)
	{
		camera_rotation = _camera_rotation;
		PerformRotation ();
	}



	// Perform movement based on velocity variable
	void PerformMovement()
	{
		if(velocity != (Vector3.zero))
		{
			rb.MovePosition (rb.position + velocity* Time.fixedDeltaTime);

		}


	}


	// perform rotation
	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
		if (cam != null) {
		
			cam.transform.Rotate (-camera_rotation);
			//rb.MoveRotation (rb.rotation * Quaternion.Euler (-camera_rotation));
		}



	}


}



