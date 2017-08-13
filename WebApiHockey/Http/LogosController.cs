using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/logos")]
	public class LogosController : ApiController
	{
		private LogoService logoService = new LogoService();

		[Route("")]
		public List<LogoDTO> Get()
		{
			return logoService.GetAll();
		}

		[Route("{id:int}")]
		public LogoDTO Get(int id)
		{
			return logoService.GetLogo(id);
		}

		[Route("create")]
		[HttpPost]
		public virtual string UploadFiles(object obj)
		{
			var stream = HttpContext.Current.Request.GetBufferedInputStream();
			new StreamReader(stream).ReadToEnd();
			var ignore = HttpContext.Current.Request.InputStream;

			var length = HttpContext.Current.Request.ContentLength;
			var bytes = new byte[length];
			HttpContext.Current.Request.InputStream.Read(bytes, 0, length);

			var fileName = HttpContext.Current.Request.Headers["X-File-Name"];
			var fileSize = HttpContext.Current.Request.Headers["X-File-Size"];
			var fileType = HttpContext.Current.Request.Headers["X-File-Type"];

			System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(bytes));

			LogoDTO logoDTO = new LogoDTO();
			logoDTO.Name = fileName;
			logoDTO.Size = Int32.Parse(fileSize);
			logoDTO.Type = fileType;
			logoDTO.Height = image.Height;
			logoDTO.Width = image.Width;
			logoDTO.Image = bytes;

			logoService.Create(logoDTO);
			return string.Format("{0} bytes uploaded", bytes.Length);
		}

		[Route("delete/{id:int}")]
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (id <= 0)
			{
				return BadRequest("Not a valid division id");
			}
			logoService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(LogoDTO logoDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			logoService.Put(logoDTO);
			return Ok();
		}
	}
}
