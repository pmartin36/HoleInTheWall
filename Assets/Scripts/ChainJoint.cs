using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainJoint : SelectableJoint
{
	public RootJoint Root { get; private set; }

	public int Index { get; private set; }

	public float CummulativeLengthToRoot { get; private set; }

	public override PlayerController Player => Root.Player;

    // each bone can have its own pole,
    // if next and previous joint locked when adjusting, just move pole
    // if big chain of bones (like octopus), solve each chain individually

    public ChainJointMover Mover { get; private set; }
    

    public void Init(RootJoint rootJoint, int boneIndex, float maxLength)
    {
        Root = rootJoint;
        Index = boneIndex;
        CummulativeLengthToRoot = maxLength;

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
        if (MoveAxisToggled)
        {
            move = new Vector3(0, 0, move.y);
        }
        Mover.Move(move);
	}

	public override void SetSelect(bool select)
	{
        if (select)
        {
            Mover = ChainJointMover.ConstructMover(this);
        }
		base.SetSelect(select);
	}

	public override void ToggleMoveAxis(bool toggleOn)
	{
		base.ToggleMoveAxis(toggleOn);

        // change widget to make x/y axes semi-transparent and solidify z axis

	}

    public override bool WithinConstraints()
    {
        throw new System.NotImplementedException();
    }
}
