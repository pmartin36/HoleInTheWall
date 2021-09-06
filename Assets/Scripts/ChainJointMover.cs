using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChainJointMover
{
    protected ChainJointMover(ChainJoint j)
    {
        Joint = j;
    }
    public static ChainJointMover ConstructMover(ChainJoint j)
    {
        int previousFixedIndex = GetPreviousFixedPointIndex(j);
        int nextFixedIndex = GetNextFixedPointIndex(j);
        ChainJointMover mover;

        if (j.Index - previousFixedIndex == 1)
        {
            if (nextFixedIndex < 0)
            {
                nextFixedIndex = j.Root.Bones.Count - 1;
                mover = new SingleJointMover(j);
            }
            else if (nextFixedIndex - j.Index > 1)
            {
                mover = new SingleJointMover(j);
            }
            else
            {
                Transform pole = null;
                foreach (Transform t in j.transform)
                {
                    if (t.CompareTag("Pole")) pole = t;
                }
                if (pole == null)
                {
                    GameObject t = new GameObject("Pole");
                    t.tag = "Pole";
                    t.transform.parent = j.transform;
                    pole = t.transform;
                }
                mover = new PoleMover(j, pole);
            }
        }
        else
        {
            if (j.Index < j.Root.Bones.Count - 1)
                nextFixedIndex = nextFixedIndex < 0 ? j.Root.Bones.Count - 1 : nextFixedIndex;
            else
                nextFixedIndex = j.Root.Bones.Count;
            mover = new MultiJointMover(j);
        }
        mover.PreviousFixedIndex = previousFixedIndex;
        mover.NextFixedIndex = nextFixedIndex;
        return mover;
    }

    public ChainJoint Joint { get; set; }
    public int PreviousFixedIndex { get; protected set; }
    public int NextFixedIndex { get; protected set; }
    protected List<PlayerJoint> bones => Joint.Root.Bones;
    protected List<float> boneLengths => Joint.Root.Lengths;
    protected int Index => Joint.Index;
    public abstract void Move(Vector3 move);
    public abstract void Draw();

    protected static int GetNextFixedPointIndex(ChainJoint j)
    {
        for (int i = j.Index + 1; i < j.Root.Bones.Count; i++)
        {
            if ((j.Root.Bones[i] as ChainJoint).Locked)
                return i;
        }
        return -1;
    }

    protected static int GetPreviousFixedPointIndex(ChainJoint j)
    {
        for (int i = j.Index - 1; i >= 0; i--)
        {
            if (i == 0 || (j.Root.Bones[i] as ChainJoint).Locked)
                return i;
        }
        return -1;
    }

}

public class PoleMover : ChainJointMover
{
    public Vector3 Center;
    public float DistFromCenter;
    public Transform Pole;

    public PoleMover(ChainJoint j, Transform pole) : base(j)
    {
        var p = (j.Root.Bones[j.Index - 1].transform.position - j.Root.Bones[j.Index + 1].transform.position);
        Center = j.Root.Bones[j.Index - 1].transform.position + p / 2f;
        DistFromCenter = Mathf.Sqrt((j.Root.Lengths[j.Index] - p.magnitude) / 2f);

        Pole = pole;
        Pole.position = (j.transform.position - Center).normalized * DistFromCenter;
    }

	public override void Move(Vector3 move)
	{
        var po = (Pole.position - Center).normalized * DistFromCenter + move;
        Pole.position = Center + po.normalized * DistFromCenter;
    }

    public override void Draw()
    {

    }
}

public class SingleJointMover : ChainJointMover
{
    public SingleJointMover(ChainJoint j):base(j)
    {

    }
	public override void Move(Vector3 move)
	{
        var parentBone = bones[Index - 1];
        var n = Joint.transform.position - parentBone.transform.position + move;
        parentBone.transform.localRotation = Quaternion.FromToRotation(parentBone.Direction, n);
    }
	public override void Draw()
	{
		throw new System.NotImplementedException();
	}
}

public class MultiJointMover : ChainJointMover
{
    public MultiJointMover(ChainJoint j) : base(j)
    {

    }

    public override void Move(Vector3 move)
    {
        SolveIKPosition(Joint.transform.position + move);
    }
    public override void Draw()
    {
        throw new System.NotImplementedException();
    }

    public void SolveIKPosition(Vector3 target, Vector3? pole = null)
    {
        List<Vector3> positions = new List<Vector3>(bones.Count);
        int solverIterations = 10;
        float delta = 0.01f;
        float lengthToRoot = 0f;
        for (int i = PreviousFixedIndex; i < NextFixedIndex; i++)
        {
            positions[i] = bones[i].transform.position;
            if (i > PreviousFixedIndex)
                lengthToRoot += (positions[i] - positions[i - 1]).magnitude;
        }

        // Root                         Leaf
        //  o -------------o--------------o
        //  0              1              2
        //              Lengths
        //  0 (root to 1), 1 (1 to leaf), 2 (0)

        if ((target - bones[PreviousFixedIndex].transform.position).sqrMagnitude > lengthToRoot)
        {
            var dir = (target - bones[PreviousFixedIndex].transform.position).normalized;
            for (int i = PreviousFixedIndex + 1; i < Index + 1; i++)
            {
                positions[i] = positions[i - 1] + dir * (positions[i] - positions[i - 1]).magnitude;
            }
        }
        else
        {
            for (int it = 0; it < solverIterations; it++)
            {
                for (int i = Index; i > PreviousFixedIndex; i--)
                {
                    if (i == Index)
                    {
                        positions[i] = target;
                    }
                    else
                    {
                        var nextP = positions[i] - positions[i + 1];
                        positions[i] = positions[i + 1] + nextP.normalized * boneLengths[i];
                    }
                }

                for (int i = PreviousFixedIndex + 1; i <= Index; i++)
                {
                    var nextP = positions[i] - positions[i - 1];
                    positions[i] = positions[i - 1] + nextP.normalized * boneLengths[i - 1];
                }

                if ((positions[Index] - target).sqrMagnitude < delta * delta)
                {
                    break;
                }
            }

            if (pole != null)
            {
                for (int i = 1; i < positions.Count - 1; i++)
                {
                    var plane = new Plane(positions[i + 1] - positions[i - 1], positions[i - 1]);
                    var projectedPole = plane.ClosestPointOnPlane(pole.Value);
                    var projectedBone = plane.ClosestPointOnPlane(positions[i]);
                    var angle = Vector3.SignedAngle(projectedBone - positions[i - 1], projectedPole - positions[i - 1], plane.normal);
                    positions[i] = Quaternion.AngleAxis(angle, plane.normal) * (positions[i] - positions[i - 1]) + positions[i - 1];
                }
            }
        }

        for (int i = PreviousFixedIndex + 1; i < Index + 1; i++)
        {
            //if (i == Positions.Length - 1)
            //    SetRotationRootSpace(Bones[i], Quaternion.Inverse(targetRotation) * StartRotationTarget * Quaternion.Inverse(StartRotationBone[i]));
            //else
            //    SetRotationRootSpace(Bones[i], Quaternion.FromToRotation(StartDirectionSucc[i], Positions[i + 1] - Positions[i]) * Quaternion.Inverse(StartRotationBone[i]));

            bones[i].transform.position = positions[i];
        }
    }
}
