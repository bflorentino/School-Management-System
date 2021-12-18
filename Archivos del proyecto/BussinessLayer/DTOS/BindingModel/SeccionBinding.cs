using System.ComponentModel.DataAnnotations;
using System;
using System.Text;

namespace ServicesLayer.DTOs.BindingModel
{
    public class NewSeccion
    {
            public string CodigoSeccion { get; set; }

            public int IdArea { get; set; }

            public string Nivel { get; set; }

            public string Seccion { get; set; }

            public int? Aula { get; set; }
        }
  }