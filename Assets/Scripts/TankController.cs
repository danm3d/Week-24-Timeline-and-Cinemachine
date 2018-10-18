using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controller script for the tank.
/// 
/// **Note from Dan:**
/// It is really important to use summaries like this.
/// If you mouse over the <see cref="TankController"/> name in another script, you will see this summary.
/// Using "see cref=" in xml tags lets you highlight names of other classes, variables, or methods.
/// 
/// Use this script as a guideline for how your code should look.
/// </summary>
[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class TankController : MonoBehaviour
{
	/// <summary>
	/// Tranform of the tank turret
	/// </summary>
	public Transform turretTransform;

	/// <summary>
	/// How fast the turret rotates (in degrres per second)
	/// </summary>
	public float turretRotationSpeed = 1f;

	/// <summary>
	/// The <see cref="Animator"/> that controls this
	/// </summary>
	protected Animator animator;

	/// <summary>
	/// The <see cref="NavMeshAgent"/>
	/// </summary>
	protected NavMeshAgent agent;

	/// <summary>
	/// The Ray
	/// </summary>
	protected Ray ray;

	/// <summary>
	/// Hit
	/// </summary>
	protected RaycastHit hit;

	/// <summary>
	/// The horizontal input axis
	/// 
	/// **Note from Dan**
	/// It is a good idea to cache variables in the class scope like this, rather than declaring
	/// 
	/// </summary>
	protected float horizontalAxis;

	/// <summary>
	/// The Transform to spawn projectiles/particles
	/// </summary>
	public Transform firingPoint;
	/// <summary>
	/// Particle system for the gun
	/// </summary>
	public ParticleSystem gunParticles;

	/// <summary>
	/// Bullet prefab
	/// </summary>
	public GameObject bulletPrefab;

	/// <summary>
	/// How much force to apply to the bullet
	/// </summary>
	public float bulletForce;

	protected void Start()
	{
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	protected void Update()
	{
		// Set the input axis
		horizontalAxis = Input.GetAxisRaw("Horizontal");

		// Rotate the turret
		turretTransform.Rotate(Vector3.up, horizontalAxis * turretRotationSpeed * Time.deltaTime);

		//Fire the gun
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//The Tank Fire animation has an animation trigger on it set to call the public method FireGun(). 
			animator.SetTrigger("Fire");
		}

		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				agent.SetDestination(hit.point);
			}
		}
	}

	/// <summary>
	/// Fires the bullet and plays the particle effect
	/// 
	/// **Note from Dan**
	/// Notice that this is the only method we made public because we do not want to call 
	/// <see cref="TankController.Start()"/> or <see cref="TankController.Update()"/> outside of this class.
	/// 
	/// </summary>
	public void FireGun()
	{
		Instantiate(gunParticles, firingPoint.position, firingPoint.rotation,firingPoint);
		GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
		Rigidbody body = bullet.GetComponent<Rigidbody>();
		if (body != null)
		{
			body.AddForce(bullet.transform.forward * bulletForce, ForceMode.Impulse);
		}
	}
}
