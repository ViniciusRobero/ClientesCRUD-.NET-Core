using ClienteCRUD.Domain.Entities.Mapeamento;
using ClienteCRUD.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ClienteCRUD.API.Controllers
{
    [ApiController, Route("Endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _escolaridadeService;
        public EnderecoController(IEnderecoService escolaridadeService)
        {
            _escolaridadeService = escolaridadeService;
        }
        /// <summary>
        ///    Lista todos os endereços cadastrados.
        /// </summary>
        /// <response code="200">Retorna todos os endereços cadastrados ou retorna vazio caso não possua endereços na base. </response>
        /// /// <response code="400">Caso ocorra algum erro na listagem, retorna mensagem de erro. </response> 
        [HttpGet]
        [ProducesResponseType(typeof(List<Endereco>), 200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_escolaridadeService.ListarEnderecos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///    Lista um endereço específico.
        /// </summary>
        /// <response code="200">Retornar um endereço específico por Id. </response>
        /// /// <response code="400">Caso ocorra algum erro na listagem, retorna mensagem de erro. </response> 
        [HttpGet, Route("BuscarEnderecoPorId")]
        [ProducesResponseType(typeof(List<Cliente>), 200)]
        [ProducesResponseType(400)]
        public IActionResult BuscarEnderecoPorId(int id)
        {
            try
            {
                return Ok(_escolaridadeService.BuscarEnderecoPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///   Inserir um endereço na base.
        /// </summary>
        /// <param name="cliente">Irá adicionar um endereço na base de dados</param>
        /// <response code="200"> Retorna uma mensagem que o endereço foi cadastrado com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro no cadastro, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult Post(Endereco endereco)
        {
            try
            {
                return Ok(_escolaridadeService.AdicionarEndereco(endereco));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///   Alterar um endereço da base.
        /// </summary>
        /// <param name="cliente">Irá alterar um endereço da base de dados</param>
        /// <response code="200"> Retorna uma mensagem informando que o endereço foi alterado com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro na alteração, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPut]
        public IActionResult Put(Endereco endereco)
        {
            try
            {
                return Ok(_escolaridadeService.AlterarEndereco(endereco));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///   Deleta um endereço da base.
        /// </summary>
        /// <param name="cliente">Irá deletar um endereço da base de dados a partir do Id informado.</param>
        /// <response code="200"> Retorna uma mensagem informando que o endereço foi deletado com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro no momento de deletar, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_escolaridadeService.ExcluirEndereco(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}