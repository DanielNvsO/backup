using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Entidade
{
    public class EntidadePacientes
    {

        public int id { get; set; }
        public string Empresa { get; set; }
        public string Filial { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Situacao { get; set; }
        public string GrauParentesco { get; set; }

    }
}
