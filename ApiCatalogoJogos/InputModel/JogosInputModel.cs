using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    public class JogosInputModel
    {
        [Required]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "O nome do jogo deve conter entre 4 e 150 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "O nome da produtora deve conter entre 4 e 150 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(5, 100, ErrorMessage = "O preço deve ser de no mínimo 5 reais e no máximo 100 reais")]
        public double Preco { get; set; }
    }
}
