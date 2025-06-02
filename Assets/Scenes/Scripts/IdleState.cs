public class IdleState : IState
{
    private StateController controller;
    public IdleState(StateController controller) { this.controller = controller; }
    public void Enter() => controller.ApplyMaterial(controller.idleMat);
    public void Exit() { }
}
