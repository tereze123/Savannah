namespace Entities.Animals
{
    public abstract class Animal
    {
        public abstract int VisionRange { get; set; }
        public abstract void Move();
        public abstract void SpecialAction();
    }
}
