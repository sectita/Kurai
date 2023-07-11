using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManagerScript.PlaySound("pick");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("tag" + collision);
            AmmoText.ammoAmount += 30;
            Destroy(this.gameObject, 0.1f);
        }
    }
}
