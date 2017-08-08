namespace Model
{
	public class Favorite : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
