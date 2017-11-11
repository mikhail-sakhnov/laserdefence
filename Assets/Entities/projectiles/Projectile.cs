using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float damage = 75f;
	public AudioClip sound;

	void Start()
	{
		AudioSource.PlayClipAtPoint(GetSound(), transform.position);
	}

	public void Hit()
	{
		Destroy(gameObject);
	}

	public float GetDamage()
	{
		return damage;
	}

	public AudioClip GetSound()
	{
		return sound;
	}

}
