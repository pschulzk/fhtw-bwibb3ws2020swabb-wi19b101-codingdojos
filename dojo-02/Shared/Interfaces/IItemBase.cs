namespace dojo_02.Shared.Interfaces
{
    public interface IItemBase
    {
        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }
        string Room { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }
    }
}
