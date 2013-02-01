using DebuggingVsTesting.Interfaces;

namespace DebuggingVsTesting.Systems
{
    public class Conveyor : IConveyor
    {
        private readonly int _feetToMove;

        public Conveyor(int feetToMove)
        {
            _feetToMove = feetToMove;
        }

        public ConveyorMovementDetail Run()
        {
            return new ConveyorMovementDetail()
                {
                    FeetMoved = _feetToMove
                };
        }
    }
}