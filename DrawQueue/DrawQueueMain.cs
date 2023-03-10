using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class DrawableInterface{
    public virtual void draw(){
        
    }
}
class DrawQueueHandler{
    DrawQueueHandler(GraphicsDeviceManager _graphics){
        this._graphics = _graphics;
    }
     
    private GraphicsDeviceManager _graphics;
    public void draw(){
    }


}
