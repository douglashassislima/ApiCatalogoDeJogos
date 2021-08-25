using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.VR1
{
    [Route("api/VR1[controller]")]
    [ApiController]
    public class JogosDaApiController : ControllerBase
    {
        private readonly IJogoService _jogoService;
        public JogosDaApiController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogosViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<JogosViewModel>>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);
            if (jogo == null)
                return NoContent();
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogosViewModel>> InserirJogo([FromBody] JogosInputModel JogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(JogoInputModel);
                return Ok(jogo);
            }
            //catch (JogoJaCadastradoException ex)
            cath(Exception ex)
            {
                return UnprocessableEntity("Já existe um Jogo cadastrado com esse mesmo nome");
            }
        }

        [HttpPut("{idJogo}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogosInputModel JogosInputModel)
        {
           try
            {
                await _jogoService.Atualizar(idJogo, JogosInputModel);
                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpPatch("{idJogo}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);
                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe esse jogo no sistema");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();
            }
            //catch (JogoNaoCadastradoException ex)
            catch (Exception ex)
            return Ok();
            {
                return NotFound("Não existe esse jogo");
            }
        }


    }
}
