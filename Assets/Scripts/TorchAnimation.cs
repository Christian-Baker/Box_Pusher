using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimation : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite[] torch = new Sprite[9];

    public void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        torch[0] = Resources.Load<Sprite>("Torch0");
        torch[1] = Resources.Load<Sprite>("Torch1");
        torch[2] = Resources.Load<Sprite>("Torch2");
        torch[3] = Resources.Load<Sprite>("Torch3");
        torch[4] = Resources.Load<Sprite>("Torch4");
        torch[5] = Resources.Load<Sprite>("Torch5");
        torch[6] = Resources.Load<Sprite>("Torch6");
        torch[7] = Resources.Load<Sprite>("Torch7");
        torch[8] = Resources.Load<Sprite>("Torch8");
    }

    public int frame = 0;
    // Update is called once per frame
    void Update()
    {
        if (frame == 41)
            frame = 0;

        rend.sprite = torch[frame / 5];
        frame++;
    }
}
