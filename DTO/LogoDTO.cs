using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class LogoDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public byte[] Image { get; set; }

		[DataMember]
		public int Width { get; set; }

		[DataMember]
		public int Height { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int Size { get; set; }

		[DataMember]
		public string Type { get; set; }
	}
}
