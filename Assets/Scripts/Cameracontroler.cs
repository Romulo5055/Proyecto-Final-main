using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroler : MonoBehaviour
{
   [SerializeField]private Transform MainPlayer; 
    private void Update()
    {
        transform.position = new Vector3(MainPlayer.position.x, MainPlayer.position.y, transform.position.z);
    }
}
