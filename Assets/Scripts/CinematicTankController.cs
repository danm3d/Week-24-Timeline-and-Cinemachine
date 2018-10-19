using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CinematicTankController : MonoBehaviour
{
	/// <summary>
	/// The Transform to spawn projectiles/particles
	/// </summary>
	public Transform firingPoint;
	/// <summary>
	/// Particle system for the gun
	/// </summary>
	public ParticleSystem gunParticles;

	/// <summary>
	/// The movement speed of the tank
	/// </summary>
	public float speed = 5f;

	public void FireGun()
	{
		if (EditorApplication.isPlaying)
		{
			Instantiate(gunParticles, firingPoint.position, firingPoint.rotation, firingPoint);
		}
	}

	private void Update()
	{
		transform.Translate(transform.forward * speed * Time.deltaTime);
	}
}
