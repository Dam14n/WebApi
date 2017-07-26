using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class FavoriteDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int CategoryId { get; set; }
	}
}
