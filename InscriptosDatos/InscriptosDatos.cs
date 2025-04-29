using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ParcialProgramacion.Models; 

namespace ParcialProgramacion.InscriptosDatos
{
	public class InscriptosDatos
	{
		private string ConexionString = "Data Source=LAPTOP-DVRUBVNE\\SQLEXPRESS;Initial Catalog=Competencia;Integrated Security=True;";

		public List<Inscriptos> ListarInscripto(int id)
		{
			List<Inscriptos> lista = new List<Inscriptos>();

			using (SqlConnection _con = new SqlConnection(ConexionString))
			{
				string Query = "SELECT ID_Anotados AS InscriptosID, Nombre AS NombresInscriptos, Disciplina AS InscriptoDisciplina, Edad AS EdadInscripto, CiudadResidencia FROM Inscriptos";

				if (id > 0)
				{
					Query += " WHERE ID_Anotados = @Id";
				}

				SqlCommand cmd = new SqlCommand(Query, _con);
				if (id > 0)
				{
					cmd.Parameters.AddWithValue("@Id", id);
				}

				_con.Open();
				SqlCommand cmd = new SqlCommand(Query, _con);
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Inscriptos inscripto = new Inscriptos();
					inscripto.Id = (int)reader["InscriptosID"];
					inscripto.Nombre = reader["NombresInscriptos"].ToString();
					inscripto.Disciplina = reader["InscriptoDisciplina"].ToString();
					inscripto.Edad = (int)reader["EdadInscripto"];
					inscripto.CiudadResidencia = reader["CiudadResidencia"].ToString();

					lista.Add(inscripto);
				}
			}

			return lista;
		}

		public List<Disciplina> ListarDisciplinas(int id)
		{
			List<Disciplina> lista = new List<Disciplina>();

			using (SqlConnection conexion = new SqlConnection(ConexionString))
			{
				string query;

				if (id == 0)
				{
					query = "SELECT ID_Disciplina AS Id, Nombre FROM Disciplina";
				}
				else
				{
					query = "SELECT ID_Disciplina AS Id, Nombre FROM Disciplina WHERE ID_Disciplina = @Id";
				}

				SqlCommand cmd = new SqlCommand(query, conexion);

				if (id > 0)
				{
					cmd.Parameters.AddWithValue("@Id", id);
				}

				conexion.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Disciplina disciplina = new Disciplina
					{
						Id = (int)reader["Id"],
						Nombre = reader["Nombre"].ToString()
					};

					lista.Add(disciplina);
				}
			}

			return lista;
		}


		public string CrearInscripto(Inscriptos inscripto)
		{
			string Query = "INSERT INTO Inscriptos (Nombre, Disciplina, Edad, CiudadResidencia) " +
						   "VALUES ('" + inscripto.Nombre + "', '" + inscripto.Disciplina + "', " + inscripto.Edad + ", '" + inscripto.CiudadResidencia + "')";

			try
			{
				using (SqlConnection _con = new SqlConnection(ConexionString))
				{
					_con.Open();
					SqlCommand cmd = new SqlCommand(Query, _con);
					cmd.ExecuteNonQuery();
					return "";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string EditarInscripto(Inscriptos inscripto)
		{
			try
			{
				using (SqlConnection _con = new SqlConnection(ConexionString))
				{
					string Query = "UPDATE Inscriptos SET " +
								   "Nombre = '" + inscripto.Nombre + "', " +
								   "Disciplina = '" + inscripto.Disciplina + "', " +
								   "Edad = " + inscripto.Edad + ", " +
								   "CiudadResidencia = '" + inscripto.CiudadResidencia + "' " +
								   "WHERE ID_Anotados = " + inscripto.Id;

					_con.Open();
					SqlCommand cmd = new SqlCommand(Query, _con);
					cmd.ExecuteNonQuery();
					return "";
				}
			}
			catch (Exception err)
			{
				return err.Message;
			}
		}

		public string EliminarInscripto(int id)
		{
			try
			{
				using (SqlConnection _con = new SqlConnection(ConexionString))
				{
					string Query = "DELETE FROM Inscriptos WHERE ID_Anotados = " + id;

					_con.Open();
					SqlCommand cmd = new SqlCommand(Query, _con);
					cmd.ExecuteNonQuery();
					return "";
				}
			}
			catch (Exception err)
			{
				return err.Message;
			}
		}
	}
}



