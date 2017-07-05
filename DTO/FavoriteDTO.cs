using System.Collections.Generic;
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
		public List<int> CategoriesIds { get; set; }
	}
}
