using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraParent;
    public float levelChangeSpeed = 1;

    public void GoToLevel(int index)
    {
        Vector3 nextPos = new Vector3(cameraParent.transform.position.x, cameraParent.transform.position.y, (100 * index + 10) - 100);
        if (Vector3.Distance(cameraParent.transform.position, nextPos) < 110)
        {
            LeanTween.move(cameraParent, nextPos, levelChangeSpeed).setOnComplete(() =>
            {
                LevelManager.UnloadLevel(LevelManager.currentLevelIndex - 1);
                LevelManager.LoadLevel(LevelManager.currentLevelIndex + 1);
            });
        }
        else
        {
            cameraParent.transform.position = nextPos;
        }

    }
}
