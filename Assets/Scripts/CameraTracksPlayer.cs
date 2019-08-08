using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {
	Transform player;
	float offsetX;
	
	void Start () {
		// Find the player and center the camera over it whatever offset we decide as we design the game
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if (player_go == null) return;
		player = player_go.transform;
		offsetX = transform.position.x - player.position.x;
	}
	
	void Update () {
		// Update the position of the camera as the player moves
		if (player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
