using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiOnRoadTrigger : MonoBehaviour {

    private ParticleSystem[] _VFXs = new ParticleSystem[2];

    private void Awake() {
        _VFXs[0] = GetComponent<ParticleSystem>();
        _VFXs[1] = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            foreach (var item in _VFXs) {
                item.Play();
            }
        }
    }

}
