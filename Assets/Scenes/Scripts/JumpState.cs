public class JumpState : IState
{
    private StateController controller;
    public JumpState(StateController controller) { this.controller = controller; }
    public void Enter() => controller.ApplyMaterial(controller.jumpMat);
    public void Exit() { }
}
