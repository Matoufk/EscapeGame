using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EcranDeFin : MonoBehaviour
{
    public Canvas fin;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        fin.gameObject.SetActive(true);
        player.GetComponent<CharacterScript>().enabled = false;
        player.GetComponentInChildren<CameraScript>().enabled = false;
    }
}

