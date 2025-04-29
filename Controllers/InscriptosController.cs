using Microsoft.AspNetCore.Mvc;
using ParcialProgramacion.InscriptosDatos;
using ParcialProgramacion.Models;

namespace ParcialProgramacion.Controllers
{
	public class InscriptosController : Controller
	{
	     InscriptosDatos _BD = new InscriptosDatos();

		public IActionResult Index()
		{
			try
			{
				var lista = _BD.ListarInscripto(0);
				return View(lista);
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al obtener la lista de inscriptos: {ex.Message}";
				return View("Error");
			}
		}

		public IActionResult Details(int id)
		{
			try
			{
				var lista = _BD.ListarInscripto(id);
				if (lista == null)
				{
					return NotFound("Inscripto no encontrado.");
				}
				return View(lista[0]);
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al obtener detalles del inscripto: {ex.Message}";
				return View("Error");
			}
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Inscripto inscripto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var resultado = _BD.CrearInscripto(inscripto);
					if (string.IsNullOrEmpty(resultado))
					{
						return RedirectToAction("Index");
					}
					else
					{
						ViewBag.Error = resultado;
					}
				}
				return View(inscripto);
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al crear el inscripto: {ex.Message}";
				return View("Error");
			}
		}

		public IActionResult Edit(int id)
		{
			try
			{
				var lista = _BD.ListarInscripto(id);
				if (lista == null)
				{
					return NotFound("Inscripto no encontrado.");
				}
				return View(lista[0]);
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al obtener el inscripto para editar: {ex.Message}";
				return View("Error");
			}
		}

		[HttpPost]
		public IActionResult Edit(Inscripto inscripto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var resultado = _BD.EditarInscripto(inscripto);
					if (string.IsNullOrEmpty(resultado))
					{
						return RedirectToAction("Index");
					}
					else
					{
						ViewBag.Error = resultado;
					}
				}
				return View(inscripto);
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al editar el inscripto: {ex.Message}";
				return View("Error");
			}
		}

		public IActionResult Delete(int id)
		{
			try
			{
				var lista = _BD.ListarInscripto(id);
				if (lista == null)
				{
					return NotFound("Inscripto no encontrado.");
				}
				return View(lista[0]);
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al obtener el inscripto para eliminar: {ex.Message}";
				return View("Error");
			}
		}

		[HttpPost]
		public IActionResult DeleteConfirmado(int id)
		{
			try
			{
				var resultado = _BD.EliminarInscripto(id);
				if (string.IsNullOrEmpty(resultado))
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.Error = resultado;
					return RedirectToAction("Delete", new { id = id });
				}
			}
			catch (Exception ex)
			{
				ViewBag.Error = $"Error al eliminar el inscripto: {ex.Message}";
				return View("Error");
			}
		}
	}