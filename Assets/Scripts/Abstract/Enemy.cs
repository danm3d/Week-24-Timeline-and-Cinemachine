using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public abstract class Enemy : MonoBehaviour
{
	public int health = 1;

	/// <summary>
	/// Take damage and handle health reaching less than or equal to 0
	/// </summary>
	/// <param name="damage">Damage to take</param>
	public virtual void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Debug.LogFormat("I, {0}, have died!", this.name);
		}
	}
}
