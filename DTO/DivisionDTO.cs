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
		public ICollection<SubDivisionDTO> SubDivisions { get; set; }

		public int Id { get; set; }
	}
}
