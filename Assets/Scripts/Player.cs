using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        goToPosition(new Vector3(2,0,10));
    }

    void goToPosition(Vector3 position)
    {
        LerpTransform.LerpTransformToPosition(
            transform,
            position,
            3,
            EaseFunctions.OutBounce,
            () => goToPosition(new Vector3(position.x, position.y, -position.z))
        );
    }
}
