using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : ITool
{
    private Transform myPlayer;
    private int state = 0;
    private Transform owned;
    private Vector3 ownedAtStart;
    public Material toolImage { get; set; }
    public List<Material> modeImages { get; set; }
    public int mode { get; set; }

    public void InitOnce()
    {
        mode = 0;
    }

    public void Use(Transform player)
    {
        myPlayer = player;
        RaycastHit hit;
        if (Physics.Raycast(player.position, player.forward, out hit))
        {
            switch (state)
            {
                case 0:
                    state = 1;
                    Player playerObject = player.GetComponent<Player>();
                    GameObject obj = GameObject.Instantiate(playerObject.drawingObject, playerObject.beingDrawn);
                    obj.transform.position = hit.point + Vector3.up * 0.01f - (Vector3.forward + Vector3.left) * 0.5f;
                    owned = obj.transform;
                    ownedAtStart = owned.localPosition;
                    break;
            }
        }
    }

    public void Update()
    {
        if (state == 0) return;
        RaycastHit hit;
        if (Physics.Raycast(myPlayer.position, myPlayer.forward, out hit))
        {
            owned.localScale = new Vector3((hit.point.x - ownedAtStart.x) * -1f, 1, (hit.point.z - ownedAtStart.z) * -1f);
            owned.localPosition = new Vector3((ownedAtStart.x - hit.point.x) * -0.5f, ownedAtStart.y, (ownedAtStart.z - hit.point.z) * -0.5f);
        }
    }

    public void SwitchMode(int oldMode, int newMode) { }
}
