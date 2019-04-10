using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Lion : IAnimal
    {
        public string Name { get; set; }

        public int VisionRange { get; set; }

        public PositionOnField PositionOnField { get; set; }

        public Lion()
        {
            this.Name = "L";
            this.VisionRange = 7;
            this.PositionOnField = new PositionOnField();
        }

        public void PeaceStateMovement(ISavannahGameField gameField)
        {
            //TO DO: Implement Lion Move - Chase Antilope
        }

        public void ActionWhenSeesEnenmy(PositionOnField lionsPositionOnField, ISavannahGameField gameField)
        {
            
            //TO DO: Implement Lion SpecialAction - shoot lazors with one out of 10 possibility. Lazor range - 7 blocks. Damage - 3% of preys health
        }

    }
}
