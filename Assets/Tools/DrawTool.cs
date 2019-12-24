using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : ITool
{
    private int state = 0;
    private Transform owned;
    public Material toolImage { get; set; }
    public List<Material> modeImages { get; set; }
    public int mode { get; set; }

    public void InitOnce()
    {
        mode = 0;
    }

    public void Use(Transform player)
    {
        RaycastHit hit;
        if (Physics.Raycast(player.position, player.forward, out hit))
        {
            switch (state)
            {
                case 0:
                    mode = 1;
                    Player playerObject = player.GetComponent<Player>();
                    GameObject obj = GameObject.Instantiate(playerObject.drawingObject, playerObject.beingDrawn);
                    obj.transform.position = hit.transform.position;
                    break;
            }
        }
    }

    public void SwitchMode(int oldMode, int newMode) { }
}
