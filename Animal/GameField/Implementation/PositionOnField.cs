namespace Entities.GameField
{
    public class PositionOnField
    {
        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public bool IsInViewRange { get; set; }

        public PositionOnField()
        {
            this.IsInViewRange = true;
        }
    }
}
