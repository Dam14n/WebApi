using System.Runtime.Serialization;

namespace DTO
{
	[DataContract]
	public class DivisionDTO
	{
		[DataMember]
		public int DivisionId { get; set; }

		[DataMember]
		public virtual string Name { get; set; }
	}
}
