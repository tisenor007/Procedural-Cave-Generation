using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTriggers : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    public AudioSource scareSound;
    //private bool jumpScareTriggered;
    // Start is called before the first frame update
    void Start()
    {
        //jumpScareTriggered = false;
        zombie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        zombie.transform.LookAt(player.transform.position);
        //if (jumpScareTriggered == true)
        //{
            if (scareSound.isPlaying == false)
            {
                //jumpScareTriggered = false;
                zombie.SetActive(false);
                scareSound.Stop();
            }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //jumpScareTriggered = true;
            zombie.SetActive(true);
            scareSound.Play();
        }
    }

}
