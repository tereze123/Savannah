using Entities.GameField;

namespace Presentation.Interfaces
{
    public interface IInputOutput
    {
        void DrawGameField(ISavannahGameField gameField);
        string ReturnKeyPressed();
    }
}
