using UnityEngine;

// This script governs how collectables work
public class Collectable : MonoBehaviour {

    // Speed of rotation of the collectable
    private float speed = 1;
	private Quaternion rotation;

    // Audio and target
    public Transform target;
	public AudioClip collectAudioClip;

    // Initialize the rotation of the collectable
    void Start () {
		rotation = transform.rotation;
	}

    // Rotate the collectable
    void Update () {
		rotation *=  Quaternion.AngleAxis(speed, Vector3.back);
		transform.rotation= Quaternion.Lerp (transform.rotation, rotation , 10 * Time.deltaTime); 
	}

    // User collides with the collectable, update progress and destroy the object
    void OnTriggerEnter(Collider col) {
		if (col.gameObject == target.gameObject) {
			target.GetComponent<AudioSource> ().PlayOneShot(collectAudioClip);
			GameManager.progress++;
			Destroy(gameObject);
		}
	}
}
