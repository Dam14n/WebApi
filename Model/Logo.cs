namespace Model
{
	public class Logo : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual int Width { get; set; }
		public virtual int Height { get; set; }
	}
}
