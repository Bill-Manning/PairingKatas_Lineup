namespace Algorithms
{
    public class PlayerAssignment
    {
        public Player Player { get; set; }
        public Position? Position { get; set; }

        public bool Matches(PlayerAssignment playerAssignment)
        {
            return this.Player.Name == playerAssignment.Player.Name && this.Position == playerAssignment.Position;
        }
    }
}