using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private Scorekeeper scoreKeeper;

	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<Scorekeeper>();
	}
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability){
		Fire ();
		}
	}

	void Fire(){
		GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}


	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile){
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0){
				Destroy (gameObject);
				scoreKeeper.Score(scoreValue);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
			}
		}
	}

}
