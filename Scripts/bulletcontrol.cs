using UnityEngine;
using System.Collections;

public class bulletcontrol : MonoBehaviour {

    public enum BulletType { MiningLaser,RailGunRound,Bullet,rocket}
    public BulletType bulletType = BulletType.Bullet;
	public GameObject explo;
    public float TimeToDestroy;
	// Use this for initialization
	void Start () {

		StartCoroutine(destroyBullet());
	}

	IEnumerator destroyBullet() {
		yield return new WaitForSeconds(TimeToDestroy);
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("hit");
		GameObject clone = (GameObject)Instantiate (explo, this.transform.position, this.transform.rotation);

        if (bulletType == BulletType.MiningLaser && collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<Asteroid>().MineAsteroid();
        }
		Destroy (gameObject);
	}
}
