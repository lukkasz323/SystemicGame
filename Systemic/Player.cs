namespace Systemic;

public class Player
{
    public Storage Storage { get; private set; } = new(15, "Inventory", (132, 32));
}
