namespace Model
{
	public class Logo : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }
		public virtual int Size { get; set; }
		public virtual string Type { get; set; }
		public virtual byte[] Image { get; set; }
		public virtual int Width { get; set; }
		public virtual int Height { get; set; }
	}
}
