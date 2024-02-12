
namespace CS.Inputs
{
    public interface IPlayerInput
    {
        bool IsAccelButtonPressed();
        bool IsBreakButtonPressed();
        bool IsTurningLeftButtonPressed();
        bool IsTurningRightButtonPressed();
        bool IsReversePressed();
        bool IsForwardPressed();
    } 
}
