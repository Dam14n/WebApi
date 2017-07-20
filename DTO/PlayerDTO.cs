using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class PlayerDTO : IIdentificable
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int Age { get; set; }

		[DataMember]
		public int? TeamId { get; set; }

		[DataMember]
		public List<int> GoalsIds { get; set; }

		[DataMember]
		public int Id { get; set; }
	}
}
