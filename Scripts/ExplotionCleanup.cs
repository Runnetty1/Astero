using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionCleanup : MonoBehaviour
{
    public float TimeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroySelf());
    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(TimeToDestroy);
        Destroy(this.gameObject);
    }
}
