using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class CategoryDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int SubDivisionId { get; set; }

		[DataMember]
		public List<int> MatchesIds { get; set; }
	}
}
