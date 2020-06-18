using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public GameManager gm;
    public MeshDestroy md;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            md.DestroyMesh();
            Time.timeScale = .5f;

        }

        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gold")
        {
            other.gameObject.GetComponent<DiamondCollect>().CollectGold();
            Destroy(other.gameObject);
            gm.CollectGold();
        }
    }
}
