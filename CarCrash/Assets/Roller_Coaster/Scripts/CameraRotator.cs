using UnityEngine;

public class CameraRotator : MonoBehaviour {

    [SerializeField]
    private float _rotateSpeed = 20f;

    private void LateUpdate() {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }

}
