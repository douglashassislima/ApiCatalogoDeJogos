using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.VR1
{
    [Route("api/VR1[controller]")]
    [ApiController]
    public class JogosDaApiController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<JogosViewModel>>> Obter()
        {
            return Ok();
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogosViewModel>>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogosViewModel>> InserirJogo(JogosInputModel jogo)
        {
            return Ok();
        }

        [HttpPut("{idJogo}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo,JogosInputModel jogo)
        {
            return Ok();
        }

        [HttpPatch("{idJogo}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }


    }
}
