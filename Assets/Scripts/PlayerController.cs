using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected InputActions InputActions { get; set; }
    private SelectableJoint activeJoint;
    private bool cameraRotateActive;

    private CameraController cameraController;
    [SerializeField]
    private Transform CameraFocus;
    

    public SkinnedMeshRenderer MeshRenderer { get; private set; }

    private Vector2 CameraSensitivity = Vector2.one * 20f;

	private void Awake()
	{
        InputActions = new InputActions();
        InputActions.Enable();

        MeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
	}

	void Start()
    {
        InputActions.Player.Move.started += MoveStarted;
        InputActions.Player.Move.canceled += MoveEnded;

        InputActions.Player.Rotate.started += ctx => cameraRotateActive = true;
        InputActions.Player.Rotate.canceled += ctx => cameraRotateActive = false;

        InputActions.Player.ToggleAxis.started += ctx =>
        {
            if (activeJoint != null)
            {
                activeJoint.ToggleMoveAxis(true);
            }
        };
        InputActions.Player.ToggleAxis.canceled += ctx =>
        {
            if (activeJoint != null)
            {
                activeJoint.ToggleMoveAxis(false);
            }
        };

        InputActions.Player.Lock.performed += ToggleLockJoint;

        cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.SetFocus(CameraFocus);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraRotateActive)
        {
            Vector2 mouseDelta = InputActions.Player.Delta.ReadValue<Vector2>() * Time.deltaTime * CameraSensitivity;
            Vector3 euler = new Vector3(mouseDelta.y, mouseDelta.x, 0);
            //Quaternion q = Quaternion.Euler(mouseDelta.y, 0, mouseDelta.x);
            cameraController.Rotate(euler);
        }
        else if (activeJoint != null)
        {
            if (!activeJoint.Locked)
            {
                Vector2 mouseDelta = InputActions.Player.Delta.ReadValue<Vector2>() * Time.deltaTime;
                activeJoint.Move(mouseDelta);
            }
        }

        if (InputActions.Player.Reset.triggered)
        {
            cameraController.ResetView();
        }
    }

    public void ToggleLockJoint(InputAction.CallbackContext ctx)
    {
        if (TryGetJointAtMousePosition(out SelectableJoint joint))
        {
            joint.ToggleLock();
        }
    }

    public void MoveStarted(InputAction.CallbackContext ctx) {
        if (TryGetJointAtMousePosition(out SelectableJoint joint))
        {
            activeJoint = joint;
            joint.SetSelect(true);
        }
    }

    public void MoveEnded(InputAction.CallbackContext ctx)
    {
        // reset joint color
        if (activeJoint != null)
        {
            activeJoint.SetSelect(false);
            activeJoint = null;
        }
    }

    private bool TryGetJointAtMousePosition(out SelectableJoint joint)
    {
        // set active joint from raycast
        Vector2 mousePosition = InputActions.Player.Position.ReadValue<Vector2>();
        Ray ray = cameraController.Camera.ScreenPointToRay(mousePosition);
        joint = null;
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, 1 << LayerMask.NameToLayer("Player"), QueryTriggerInteraction.Collide))
        {
            joint = hit.collider.GetComponent<SelectableJoint>();
        }
        return joint != null;
    }
}
