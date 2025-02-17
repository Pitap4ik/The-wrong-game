namespace ActorController
{
    public interface IActorController<T>
    {
        public Movement2D MovementController { get; set; }
        public T Stats { get; set; }
    }
}
