namespace CircleCharacter.GameCore.Player
{
    public class Character
    {
        public CharacterContainer CharacterContainer { get; }
        public GroundHandler GroundHandler { get; }
        public CharacterMovement CharacterMovement { get; }

        public Character(CharacterContainer characterCharacterContainer, GroundHandler groundHandler, CharacterMovement characterMovement)
        {
            CharacterContainer = characterCharacterContainer;
            GroundHandler = groundHandler;
            CharacterMovement = characterMovement;
        }
    }
}