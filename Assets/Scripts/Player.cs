using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    Options options;
    public Text modeText;
    public GameObject canvas;
    public GameObject hud;
    public Transform parts;
    public Transform beingDrawn;
    public GameObject drawingObject;

    private bool verticalLocked = true;
    public List<ITool> modes = new List<ITool>();
    public int mode = 0;
    private ITool tool;
    public bool orbit = false;

    // Start is called before the first frame update
    void Start()
    {
        // Add tool types
        modes.Add(new NoTool());
        modes.Add(new DrawTool());
        modes.Add(new OrbitTool());

        // After That
        tool = modes[mode];
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbit)
        {
            int tmpmode = mode;
            mode += Math.Sign(Input.mouseScrollDelta.y);
            mode %= modes.Count;
            if (mode < 0) mode = modes.Count + mode;
            bool modeChanged = mode != tmpmode;
            if (modeChanged) modeText.text = mode.ToString();
            if (modeChanged) tool = modes[mode];

            if (Input.GetButtonDown(options.toggleVerticalLockButton)) verticalLocked = !verticalLocked;
        }

        if (Input.GetButtonDown(options.useButton)) tool.Use(transform);

        if (orbit) { }
        else
        {
            Vector3 movement;
            movement = 5f * Input.GetAxis(options.xMovement) * Time.deltaTime * transform.right;
            if (verticalLocked) movement.y = 0;
            transform.position += movement;
            movement = 5f * Input.GetAxis(options.zMovement) * Time.deltaTime * transform.forward;
            if (verticalLocked) movement.y = 0;
            transform.position += movement;
        }
    }
}
