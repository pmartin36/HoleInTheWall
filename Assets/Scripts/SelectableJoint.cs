using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableJoint : PlayerJoint
{
    public bool Locked { get; set; }
    public bool Selected { get; set; }
    public Material Material { get; protected set; }
    public bool MoveAxisToggled { get; set; }

    public abstract void Move(Vector3 move);
    public virtual void ToggleMoveAxis(bool toggleOn)
    {
        MoveAxisToggled = toggleOn;
    }

    public virtual void SetSelect(bool select)
    {
        Selected = select;
        ToggleMoveAxis(false);
        SetColor();
    }

    public void ToggleLock()
    {
        SetLock(!Locked);
    }

    public void SetLock(bool locked)
    {
        Locked = locked;
        SetColor();
    }

    private void SetColor()
    {
        if (Locked)
        {
            Material.SetColor("_Color", Color.red);
        }
        else
        {
            Color c = Selected ? new Color(0.5f, 1f, 0.5f, 1) : Color.green;
            Material.SetColor("_Color", c);
        }
    }
}
