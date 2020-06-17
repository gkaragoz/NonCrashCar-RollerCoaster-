using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXColorEmitter : MonoBehaviour {

    [SerializeField]
    private Vector3 _rotationOffset = Vector3.zero;
    [SerializeField]
    private Vector3 _positionOffset = Vector3.zero;
    [SerializeField]
    private int _emissionCount = 100;
    private ParticleSystem _VFX;

    private void Awake() {
        _VFX = GetComponent<ParticleSystem>();
    }

    private void Update() {
        transform.localPosition = _positionOffset;
        transform.localRotation = Quaternion.Euler(_rotationOffset);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Emit();
        }
    }

    private void Emit() {
        for (int ii = 0; ii < _emissionCount; ii++) {
            var main = _VFX.main;
            main.startColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            _VFX.Emit(1);
        }
    }


}
