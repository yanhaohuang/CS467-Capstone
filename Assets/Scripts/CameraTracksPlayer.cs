using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {
	Transform player;
	float offsetX;
	
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if (player_go == null) return;
		player = player_go.transform;
		offsetX = transform.position.x - player.position.x;
	}
	
	void Update () {
		if (player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
