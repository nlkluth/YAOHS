public class PlayerCharacter : BaseCharacter 
{
	void Update()
	{
		Messenger<int, int>.Broadcast("player health update", 100, 80);
	}
}
