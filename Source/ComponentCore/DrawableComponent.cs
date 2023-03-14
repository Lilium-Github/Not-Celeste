namespace Not_Celeste.ComponentCore;

class DrawableComponent : IComponent {
	private Sprite? sprite;
	private Texture texture;

	public DrawableComponent(string path, ComponentHandler handler, RenderWindow window)
	{
		texture = new(path);
		sprite = new();
	}
	public virtual void draw(){
		Console.WriteLine("called draw from drawable component - no virtual definition");
	}
}