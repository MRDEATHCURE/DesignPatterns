using UnityEngine;

public class StateController : MonoBehaviour
{
    public Renderer targetRenderer;

    public Material idleMat;
    public Material runMat;
    public Material crouchMat;
    public Material sprintMat;
    public Material jumpMat;
    public Material comboMat;

    private IState[] states;
    private int currentIndex = 0;
    private IState currentState;
    private bool canCycle = true;

    private void Start()
    {
        states = new IState[]
        {
            new IdleState(this),
            new RunState(this),
            new CrouchState(this),
            new SprintState(this),
            new JumpState(this)
        };

        SetState(0);
    }

    private void Update()
    {
        bool isA = Input.GetKey(KeyCode.A);
        bool isD = Input.GetKey(KeyCode.D);

        if (isA && isD)
        {
            ApplyMaterial(comboMat);
            canCycle = false;
            return;
        }

        if (!isA && !isD)
        {
            canCycle = true;
        }

        if (canCycle && (Input.GetKeyDown(KeyCode.A) ^ Input.GetKeyDown(KeyCode.D)))
        {
            CycleState();
            canCycle = false;
        }
    }

    private void CycleState()
    {
        int nextIndex = (currentIndex + 1) % states.Length;
        SetState(nextIndex);
    }

    public void SetState(int index)
    {
        currentState?.Exit();
        currentIndex = index;
        currentState = states[index];
        currentState.Enter();
    }

    public void ApplyMaterial(Material mat)
    {
        if (targetRenderer != null && mat != null)
        {
            targetRenderer.material = mat;
        }
    }
}
