using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketAnim : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Packet").GetComponent<Animator>();
        anim.Play("PacketMovingLeftRight");
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95 && !anim.IsInTransition(0))
        {
            anim.Play("PacketMovingRightLeft");
        }
    }
}
