using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public GameManager gm;
    public MeshDestroy md;
    public CharacterRagdoll cr;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            cr.transform.SetParent(null);
            cr.Explosion();
            md.DestroyMesh();
            LeanTween.delayedCall(3, () =>
            {
                Debug.Log("Fail çalıştı");
                UIManager.instance.OpenFailPanel();
            });

        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gold")
        {
            other.gameObject.GetComponent<DiamondCollect>().CollectGold();
            gm.CollectGold();
            Destroy(other.gameObject);
        }
    }
}
