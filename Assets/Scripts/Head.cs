using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : SelectableJoint
{
    public Transform Torso;

    void Start()
    {
        Transform t = this.transform;
        do
        {
            t = t.parent;
            Player = t.GetComponent<PlayerController>();
        } while (Player == null);

        foreach (Material m in Player.MeshRenderer.materials)
        {
            if (m.name.StartsWith(gameObject.name))
            {
                Material = m;
                m.SetColor("_Color", Color.green);
            }
        }
    }

    public override void Move(Vector3 move)
    {

    }

    public override bool WithinConstraints()
    {
        throw new System.NotImplementedException();
    }
}
