using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ApoloAdmin
{
    public class Artista
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string Manifestacion { get; set; }
        public string ActividadProfecional { get; set; }
        public string Fijo { get; set; }
        public string Movil { get; set; }
        public string Correo { get; set; }
        public string DireccionWeb { get; set; }
        public string Curriculo { get; set; }
        public string Organizaciones { get; set; }
    }
    public class Proyectos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdArt { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
    }
    public class VersionActual
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Version { get; set; }
    }
}
