using Entities.GameField;

namespace Presentation.Interfaces
{
    public interface IInputOutput
    {
        void DrawGameField(ISavannahGame gameField);
        string ReturnKeyPressed();
    }
}
