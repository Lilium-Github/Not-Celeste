namespace Not_Celeste.ComponentCore;
/// <summary>
/// class <c> ComponentHandler</c> this object manages the ECS.
/// </summary>
class ComponentHandler
{
	// priority: int = 0
	// shouldDelete: bool = False
	// children: list["GameObject"]
	public int priority = 0;
	public bool shouldDelete  = false;
	/// <summary>
	/// function constructor <c>ComponentHandler</c> use this function when creating a fresh instance of the game.
	/// </summary>
	ComponentHandler(){
		
	}
	/// <summary>
	/// function constructor  <c>ComponentHandler</c> use this function when using serialization.
	/// </summary>
	ComponentHandler(List<GameObject> objects){
		
	}
}