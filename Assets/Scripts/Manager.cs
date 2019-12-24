using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private Light sun;

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("Sun").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion rotation = sun.transform.rotation;
        //sun.transform.rotation = Quaternion.Euler(rotation.x + Time.deltaTime, rotation.y, rotation.z);
        sun.transform.Rotate(Time.deltaTime, 0, 0);
    }

    public void LoadFile(string filename)
    {

    }
}
