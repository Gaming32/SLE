using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITool
{
    Material toolImage { get; set; }
    List<Material> modeImages { get; set; }
    int mode { get; set; }

    void InitOnce();
    void Use(Transform player);
    void SwitchMode(int oldMode, int newMode);
    void Update();
}
