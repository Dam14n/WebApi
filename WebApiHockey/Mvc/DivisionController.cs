using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using DTO;

namespace WebApiHockey.Mvc
{
	public class DivisionController : Controller
	{
		private readonly string apiUrl = "http://localhost:2491/api/divisions/";

		public ActionResult Index()
		{
			IEnumerable<DivisionDTO> divisionsDto = null;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);

				//HTTP GET
				var responseTask = client.GetAsync("");
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<IList<DivisionDTO>>();
					readTask.Wait();

					divisionsDto = readTask.Result;
				}
				else //web api sent error response
				{
					//log response status here..

					divisionsDto = Enumerable.Empty<DivisionDTO>();

					ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
				}
			}

			return View(divisionsDto);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(DivisionDTO divisionDTO)
		{
			using (var client = new HttpClient())
			{
				var url = apiUrl + "create/";
				client.BaseAddress = new Uri(url);
				//HTTP POST
				var postTask = client.PostAsJsonAsync<DivisionDTO>("divisionDTO", divisionDTO);
				postTask.Wait();

				var result = postTask.Result;
				if (result.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}

			ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

			return View(divisionDTO);
		}

		public ActionResult Delete(int id)
		{
			using (var client = new HttpClient())
			{
				var url = apiUrl + "delete/";
				client.BaseAddress = new Uri(url);
				//HTTP DELETE
				var deleteTask = client.DeleteAsync(id.ToString());
				deleteTask.Wait();

				var result = deleteTask.Result;
				if (result.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}

			return RedirectToAction("Index");
		}

		public ActionResult Edit(int id)
		{
			DivisionDTO divisionDTO = null;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				//HTTP GET
				var responseTask = client.GetAsync(id.ToString());
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<DivisionDTO>();
					readTask.Wait();

					divisionDTO = readTask.Result;
				}
			}

			return View(divisionDTO);
		}

		[HttpPost]
		public ActionResult Edit(DivisionDTO divisionDTO)
		{
			using (var client = new HttpClient())
			{
				var url = apiUrl + "put/";
				client.BaseAddress = new Uri(url);
				//HTTP POST
				var putTask = client.PutAsJsonAsync<DivisionDTO>("divisionDTO", divisionDTO);
				putTask.Wait();

				var result = putTask.Result;
				if (result.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}

			ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

			return View(divisionDTO);
		}
	}
}
