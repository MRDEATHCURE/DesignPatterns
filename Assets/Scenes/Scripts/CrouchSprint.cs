public class CrouchState : IState
{
    private StateController controller;
    public CrouchState(StateController controller) { this.controller = controller; }
    public void Enter() => controller.ApplyMaterial(controller.crouchMat);
    public void Exit() { }
}
