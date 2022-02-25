using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIfWOW : MonoBehaviour
{
    AudioSource asou;

    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        asou = this.GetComponent<AudioSource>();

        renderer = this.GetComponent<Renderer>();

        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveEnemy.flug == 1 && renderer.enabled != true)
        {
            asou.Play();
            renderer.enabled = true;
        }
        if (MoveEnemy.flug == 0 && renderer.enabled != false)
        {
            renderer.enabled = false;
        }
    }
}
