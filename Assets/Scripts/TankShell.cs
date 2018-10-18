using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This implements <see cref="Bullet"/>
/// It's a basic tank shell
/// </summary>
public class TankShell : Bullet // Less code to write now :)
{
	/// <summary>
	/// Damage to apply
	/// </summary>
	public int damage = 1;

	public override void HandleCollision(Collision collision)
	{
		/*    ^
		 *    |
		 * Overriding the base class method lets us add different behaviour for each 
		 * class that inherits from Bullet.
		 * 
		 * Here we add code to do damage, and create an explosion.
		 * 
		 * If we do not call base.HandleCollision(collision); then we will not see the debug log 
		 * or get any of the functionality of the base class' HandleCollision method*/

		base.HandleCollision(collision);


		// Check if we hit something that can be damaged.
		// As an example, we will check for an Enemy component.

		// Attempt to get an Enemy component
		Enemy enemy = collision.collider.GetComponent<Enemy>();

		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}

		Destroy(this.gameObject);
		// spawn a particle system
	}

}
