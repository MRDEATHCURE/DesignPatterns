public class SprintState : IState
{
    private StateController controller;
    public SprintState(StateController controller) { this.controller = controller; }
    public void Enter() => controller.ApplyMaterial(controller.sprintMat);
    public void Exit() { }
}
