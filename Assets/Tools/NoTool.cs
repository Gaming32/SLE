using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTool : ITool
{
    public Material toolImage { get; set; }
    public List<Material> modeImages { get; set; }
    public int mode { get; set; }

    public void InitOnce()
    {
        mode = 0;
    }
    public void Use(Transform player) { }
    public void SwitchMode(int oldMode, int newMode) { }
}
