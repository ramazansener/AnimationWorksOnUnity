using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;


    void LateUpdate()
    {
        transform.rotation = Player.rotation;
        transform.position = Player.position;


    }
}
