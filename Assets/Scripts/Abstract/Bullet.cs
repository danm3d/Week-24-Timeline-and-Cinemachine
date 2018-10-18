using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Logic for the bullet. Handles how it behaves on impact with something.
/// 
/// 
/// Notice that this is an <see cref="abstract"/> class. Other classes will simply inherit <see cref="Bullet"/>
/// 
/// The <see cref="RequireComponent"/> attribute forces 
/// the Game Object to automatically attach those types of components/
/// For <see cref="Collider"/> specifically, you need to already have a Collider like a <see cref="SphereCollider"/> or <see cref="MeshCollider"/> attached.
/// 
/// 
/// </summary>
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
	public void OnCollisionEnter(Collision collision)
	{
		HandleCollision(collision);
	}

	/// <summary>
	/// This <see cref="virtual"/> method will be Overridden in other inheriting classes.
	/// We use this to allow us to reuse more code.
	/// I never have to have an <see cref="OnCollisionEnter"/> in another class that inherits from <see cref="Bullet"/>
	/// </summary>
	/// <param name=""></param>
	public virtual void HandleCollision(Collision collision)
	{
		Debug.LogFormat("{0} hit {1}", this.name, collision.gameObject.name);
	}
}
