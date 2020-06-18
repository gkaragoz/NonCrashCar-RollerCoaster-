using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollect : MonoBehaviour
{
    public ParticleSystem diamondVFX;
    public TxtCollectedDiamond diamondCollect;


    public void CollectGold()
    {
        diamondCollect.ShowUI();
        diamondVFX.Play();
    }
}
