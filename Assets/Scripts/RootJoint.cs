using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootJoint : PlayerJoint
{
    public List<PlayerJoint> Bones { get;  private set; } = new List<PlayerJoint>();
    public List<float> Lengths { get; private set; } = new List<float>();

	public override void Start()
    {
        base.Start();
        Transform t = this.transform;
        do
        {
            t = t.parent;
            Player = t.GetComponent<PlayerController>();
        } while (Player == null);

        Bones.Add(this);
        Lengths.Add(0);
        AddToBones(this.transform, 0);
    }

    private void AddToBones(Transform t, float length)
    {
        foreach (Transform child in t)
        {
            if (child.TryGetComponent(out ChainJoint j)) {
                var dist = (child.position - t.position).magnitude;
                Lengths.Add(dist);
                length += dist;

                j.Init(this, Bones.Count, length);
                Bones.Add(j);

                AddToBones(child, length);
            }
            break;
        }
    }

    void Update()
    {
        
    }

	public override bool WithinConstraints()
	{
        //var v = Bones[1].transform.position - transform.position;
        //var up = Vector3.SignedAngle(Vector3.up, v, Player.transform.forward);
        //var right = Vector3.SignedAngle(Vector3.right, v
        //var forward = Vector3.SignedAngle(Vector3.forward, v, Player.transform.forward);
        return true;
    }
}
