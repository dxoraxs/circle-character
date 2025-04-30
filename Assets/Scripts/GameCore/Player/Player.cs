namespace CircleCharacter.GameCore.Player
{
    public class Player
    {
        public Character Character { get; }

        public Player(Character character)
        {
            Character = character;
        }
    }
}