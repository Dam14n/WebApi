using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class DivisionDTO : IIdentificable
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public List<int> SubDivisionsIds { get; set; }

		[DataMember]
		public int Id { get; set; }
	}
}
