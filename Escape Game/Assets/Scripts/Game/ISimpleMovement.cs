namespace Assets.Scripts.Game
{
    public interface ISimpleMovement
    {
        float Speed { get; set; }

        void MoveByInput(float horizontal, float vertical);
    }
}