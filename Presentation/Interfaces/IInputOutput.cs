using Entities.GameField;

namespace Presentation.Interfaces
{
    public interface IInputOutput
    {
        void DrawGameField(SavannahGameState gameField);
        string ReturnKeyPressed();
    }
}
