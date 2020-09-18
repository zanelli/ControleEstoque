using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Models
{
    public class Produto
    {
        /// <summary>
        /// Id do produto - gerado automaticamente
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Descrição do produto, deve ter mais de 3 caracteres
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter 3 ou mais caracteres")]
        public string Descricao { get; set; }
        
        /// <summary>
        /// Saldo do estoque atual do produto
        /// </summary>
        public double Estoque { get; set; }
    }
}
