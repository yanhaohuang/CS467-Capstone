using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerBehaviour : MonoBehaviour {

	// Player variables for score
	public static int score = 0;
	public int scale = 1;
	public static int maxScore = 99999999;

	// Player variables for speed
	public float jumpSpeed    = 175f;
	public float forwardSpeed = 1f;
	public float maxSpeed = 25f;

	private CircleCollider2D myCollider;
	// Player variables for managing size, mass, and speed of the player
	public float gainSize = 1f;
	public float gainMass = 0.2f;
	public float gainSpeed = 0.2f;

	public float loseSize = 0.2f;
	public float loseMass = 0.04f;
	public float loseSpeed = 1f;

	private float counter = 0f; 
	private float counterMass = 0f; 
	private float counterSpeed = 0f;

	// Is the player jumping?
	bool didJump = false;
	// Is the player dead?
	public bool dead = false;

	// Player class variables for powerups
	public bool godMode = false;
    public bool hasWeapon = false;
    public GameObject weaponShot;
    public Transform weaponShotSpawn;

	// Animator for managing player's animations
	Animator animator;

	// Sound management variables (effects, changing of clips, etc)
	public AudioMixer audioMixer;
	public AudioClip jump;
	public AudioClip absorb;
	public AudioClip squish;
	public AudioClip powerup;
    public AudioClip fireWeapon;
    AudioSource audioSource;

	// Start playing music on start and get the animation controller for future use
	void Start () {
		// Getting the master mixer
		AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
		audioSource = GetComponent<AudioSource>();
		// And make sure we play through the proper mixer
		audioSource.outputAudioMixerGroup = audioMixGroup[0];
		animator = transform.GetComponentInChildren<Animator>();
	}

	// Set some variables on player action and game state
	void Update() {
		// If the player has tapped the screen or pressed the spacebar, set our mover variable
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) didJump = true;
		// Update the score based on the location of the player
		score = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").transform.position.x) * scale;  
		// Kill the player if they've gone beyond the max score 
		if (score > maxScore) dead = true;
		// If the player is dead and time is 0 then destroy this object
		if (Time.timeScale == 0 && dead) Destroy(gameObject);
	}

	// This function runs every .02 seconds
	void FixedUpdate () {
		// If dead, we don't need to run this function
		if (dead) return;

		// Otherwise, move the player forward
		GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed );

		// If the player pressed the spacebar or tapped the screen
		if (didJump) {
			// Give the player some force forward based on their jump speed and play the player's movement audio clip
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * jumpSpeed );
			audioSource.PlayOneShot(jump, 1F);

			// If the player's mass is greater than 1
			if (GetComponent<Rigidbody2D> ().mass >= 1.04f) {
				// Let the player lose size as they tap
				counter = loseSize;
				counterMass = loseMass;
				GetComponent<Rigidbody2D> ().mass -= counterMass;
				transform.localScale -= new Vector3 (counter, counter, counter);
				counterMass = 0f;
				counter = 0f;
			}

			// If the player's speed is less than the max speed
			if (GetComponent<Rigidbody2D> ().velocity.x <= maxSpeed) {
				// Give the player more speed as they tap
				counterSpeed = gainSpeed;
				forwardSpeed += counterSpeed;
				counterSpeed = 0f;
			}

			// If the player has the weapon powerup enabled, let them shoot it
            if (hasWeapon)
            {
				// Changed the rotation on this so that the weapon always fires out
                Instantiate(weaponShot, weaponShotSpawn.position, Quaternion.identity);
                audioSource.PlayOneShot(fireWeapon, 1F);
            }
			// And set didjump back to false until the player taps again
			didJump = false;
		}

		// Figure out the player's location and velocity and rotate them a bit based on that
		if (GetComponent<Rigidbody2D>().velocity.y > 0) {
			float angle = Mathf.Lerp (0, 90, (-GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		} else {
			float angle = Mathf.Lerp (0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	// Manages the player's interactions/collisions with elements
	void OnCollisionEnter2D(Collision2D collision) {

		// If the player collides with an enemy
		if (collision.gameObject.tag == "Enemy") {
			// And "godMode"/invinciliby is active, then just return now
			if (godMode) return;

			// Otherwise, destroy the enemy
			Destroy (collision.gameObject);

			// And make the player gain size and mass while losing speed
			audioSource.PlayOneShot(absorb, 1F);
			counter = gainSize;
			counterMass = gainMass;
			GetComponent<Rigidbody2D>().mass += counterMass;
			transform.localScale += new Vector3 (counter, counter, counter);
			counter = 0f;
			counterMass = 0f;
			if (GetComponent<Rigidbody2D> ().velocity.x >= 2) {
				counterSpeed = loseSpeed;
				forwardSpeed -= counterSpeed;
				counterSpeed = 0f;
			}
		}

		// If the player collides with the ground, then they're dead
		if (collision.gameObject.tag == "Ground") {
			audioSource.PlayOneShot(squish, 1F);
			animator.SetTrigger("Death");
			dead = true;
		}
	}

	// Sets the animiation of our player - used primarily in the PowerUpBase and classes that inherit from that
	public void setAnimation( string animationKeyword )
	{
		animator.SetTrigger( animationKeyword );
	}
}