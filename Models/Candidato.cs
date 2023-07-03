public class Candidato{
    public int IdCandidato {get; set;}
    public int IdPartido{get; set;}
    public string Apellido{get; set;}
    public string Nombre{get; set;}
    public DateTime FechaNacimiento{get; set;}
    public string Foto {get; set;}
    public string Postulacion{get; set;}

  public Candidato(int idCan, int idPar, string ap, string nom, DateTime fn, string ft, string post){
    idCan = IdCandidato;
    idPar = IdPartido;
    ap = Apellido;
    nom = Nombre;
    fn = FechaNacimiento;
    ft = Foto;
    post = Postulacion;
  }
}