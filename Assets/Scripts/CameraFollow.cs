using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float zOffset;

    private void Start()
    {
        if (player == null)
            throw new MissingReferenceException("Referenciar player para habilitar o camera follow.");

        zOffset = player.position.z - transform.position.z;
    }

    private void LateUpdate()
    {
        if(player != null)
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - zOffset);
    }
}
