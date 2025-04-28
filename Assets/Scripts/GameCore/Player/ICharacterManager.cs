namespace CircleCharacter.GameCore.Player
{
    public interface ICharacterManager
    {
        void Initialize();
        PlayerContainer PlayerContainer { get; }
    }
}