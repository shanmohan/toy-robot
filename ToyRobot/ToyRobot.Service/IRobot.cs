namespace ToyRobot
{
    public interface IRobot
    {
        DirectionTypeEnum CurrentDirection { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        string StatusMessage { get; set; }
        bool Left();
        bool Move();
        bool Place(int positionX, int positionY, DirectionTypeEnum defaultDirection);
        string Report();
        bool Right();
    }
}