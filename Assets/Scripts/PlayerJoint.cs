using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerJoint : MonoBehaviour
{
	public virtual PlayerController Player { get; protected set; }
	
	public JointType JointType;
	public float RotationConstraint;

	protected Vector3 _originalDirection;
	protected Quaternion _originalRotation;
	public Vector3 Direction => transform.rotation * Quaternion.Inverse(_originalRotation) * _originalDirection;

	public abstract bool WithinConstraints();

	public virtual void Start()
	{
		if (transform.parent.TryGetComponent<PlayerJoint>(out PlayerJoint j)) {
			j._originalDirection = (transform.position - j.transform.position).normalized;
		}
		_originalRotation = transform.rotation;
	}
}

public enum JointType
{
	End,
	Ball,
	Hinge
}
