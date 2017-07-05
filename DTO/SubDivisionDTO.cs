using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class SubDivisionDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int DivisionId { get; set; }

		[DataMember]
		public List<int> CategoriesIds { get; set; }
	}
}
