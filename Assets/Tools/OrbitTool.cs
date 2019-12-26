using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTool : ITool
{
    public Material toolImage { get; set; }
    public List<Material> modeImages { get; set; }
    public int mode { get; set; }

    public void InitOnce()
    {
        mode = 0;
    }

    public void Use(Transform playerTransform)
    {
        Player player = playerTransform.GetComponent<Player>();

        player.orbit = !player.orbit;
        if (player.orbit)
        {
            player.GetComponent<MouseLook>().enabled = false;
            player.GetComponent<MouseOrbit>().enabled = true;
            player.canvas.SetActive(false);
        }
        else
        {
            player.GetComponent<MouseOrbit>().enabled = false;
            player.GetComponent<MouseLook>().enabled = true;
            player.canvas.SetActive(true);

            //player.GetComponent<MouseLook>().rotation = playerTransform.rotation;
        }
    }

    public void SwitchMode(int oldMode, int newMode) { }
    public void Update() { }
}
