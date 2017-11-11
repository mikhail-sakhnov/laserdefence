using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float health = 150f;
	public float projectileSpeed = -10f;
	public GameObject projectilePrefab;
	public float shotsPerSecond = 0.5f;
	public int score = 10;

	public AudioClip deathSound;
	private void OnTriggerEnter2D(Collider2D other)
	{
		Projectile missile = other.gameObject.GetComponent<Projectile>();
		if (missile != null)
		{
			
			missile.Hit();
			health -= missile.GetDamage();
			if (health <= 0)
			{
				Boom();
			}
		}
	}

	void Boom()
	{
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Destroy(gameObject);
		
		ScoreKeeper.AddScore(score);
		
	}


	void Update()
	{
		float probability = shotsPerSecond * Time.deltaTime;
		if (probability >  Random.value)
		{
			Fire();
		}
		
		
	}
	
	private void Fire()
	{
		GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
	}
}
