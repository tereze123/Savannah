using Entities.GameField;

namespace Presentation.Interfaces
{
    public interface IInputOutput
    {
        void DrawGameField(SavannahGameState savannahGameState);
        string ReturnKeyPressed();
    }
}
