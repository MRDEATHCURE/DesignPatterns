public class RunState : IState
{
    private StateController controller;
    public RunState(StateController controller) { this.controller = controller; }
    public void Enter() => controller.ApplyMaterial(controller.runMat);
    public void Exit() { }
}
