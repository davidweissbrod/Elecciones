using System.Data.SqlClient;
using Dapper;
namespace EjemploLogin.Models;

public static class BD
{
    private static string ConnectionString { get; set; } = @"Server=localhost;DataBase=elecciones;Trusted_Connection=True;";

    private static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
        private static List<Candidato> listaCandidatos = new List<Candidato>{};
        private static List<Partido> listaPartidos = new List<Partido>{};

        public static void AgregarCandidato(Candidato can){
            string sql = "INSERT INTO Candidatos(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pidPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pidPartido = can.IdPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion});
            }
        }

        public static void AgregarPartido(Partido par){
            string sql = "INSERT INTO Partidos(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores) VALUES (@pNombre, @pLogo, @pSitioWeb, @pFechaFundacion, @pCantidadDiputados, @pCantidadSenadores)";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pNombre = par.Nombre, pLogo = par.Logo, pSitioWeb = par.SitioWeb, pFechaFundacion = par.FechaFundacion, pCantidadDiputados = par.CantidadDiputados, pCantidadSenadores = par.CantidadSenadores});
            }
        }

        public static void EliminarCandidato(int idAEliminar)
        {
            string sql = "DELETE FROM Candidatos WHERE idCandidato = @id";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new {id = idAEliminar});
            }
        }

        public static Partido VerInfoPartido(int idPartido){
            for (int i = 0; i< listaPartidos.Count(); i++){
                if (listaPartidos[i].IdPartido == idPartido) { return listaPartidos[i]; }
            }
            return null;
        }

        public static Candidato VerInfoCandidato(int idCandidato){
            for (int i = 0; i< listaCandidatos.Count(); i++){
                if (listaCandidatos[i].IdCandidato == idCandidato){ 
                    return listaCandidatos[i]; 
                }
            }
            return null;
        }

        public static List<Partido> ListarPartidos(){
            return listaPartidos;
        }

        public static List<Candidato> ListarCandidatos(int idPartido){
            List<Candidato> listaDev = new List<Candidato>{};
            for (int i = 0; i < listaCandidatos.Count(); i++){
                if (listaCandidatos[i].IdPartido == idPartido){ 
                    listaDev.Add(listaCandidatos[i]); 
                }
            }
            return listaDev;
        }
}