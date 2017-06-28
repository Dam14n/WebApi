using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class DivisionDTO : IIdentificable
	{
		[DataMember]
		public int DivisionId { get; set; }

		[DataMember]
		public virtual string Name { get; set; }

		[DataMember]
		public int[] SubDivisions { get; set; }

		public int Id { get; set; }
	}
}
