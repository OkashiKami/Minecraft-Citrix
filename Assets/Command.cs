using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum mode { Impulse, Repeat, }

public class Command : MonoBehaviour
{
    [SerializeField]private Material center_mat;
    [SerializeField]private float time;
    [SerializeField]private float maxTime = 1;
    [SerializeField]private int index;

    private Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
    };
    private Material outter_mat;

    // Update is called once per frame
    private void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();
        var materials = renderer.materials;
        foreach (var mat in materials)
        {
            var name = mat.name.Replace(" (Instance)", string.Empty);
            if (name.Equals("block_command_center"))
            {
                this.center_mat = mat;
            }
            if (name.Equals("block_command"))
            {
                this.outter_mat = mat;
            }
        }
    }
    void Update()
    {
        if (!center_mat) Start();
        if(time < maxTime)
            time += 1 * Time.deltaTime;
        if(time >= maxTime)
        {
            index = Random.Range(0, colors.Length);
            time = 0;
        }
        center_mat.color = Color.Lerp(center_mat.color, colors[index], 0.8f);
    }
}
