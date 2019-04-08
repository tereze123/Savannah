namespace Entities.Animals
{
    public interface IAnimal
    {
        int VisionRange { get; set; }
        void Move();
        void SpecialAction();
    }
}
