using System;
using System.Threading.Tasks;
using ClienteCRUD.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClienteCRUD.Domain.Entities.Mapeamento;
using System.Collections.Generic;

namespace ClienteCRUD.API.Controllers
{
    [ApiController, Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService ClienteService)
        {
            _clienteService = ClienteService;
        }

        /// <summary>
        ///    Lista todos os clientes cadastrados.
        /// </summary>
        /// <response code="200">Retorna todos os clientes cadastrados ou retorna vazio caso não possua clientes na base. </response>
        /// /// <response code="400">Caso ocorra algum erro na listagem, retorna mensagem de erro. </response> 
        [HttpGet]
        [ProducesResponseType(typeof(List<Cliente>), 200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clienteService.ListarClientes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///    Lista um cliente específico.
        /// </summary>
        /// <response code="200">Retorna todos o cliente selecionado pelo Id. </response>
        /// /// <response code="400">Caso ocorra algum erro na listagem, retorna mensagem de erro. </response> 
        [HttpGet, Route("BuscarClientePorId")]
        [ProducesResponseType(typeof(List<Cliente>), 200)]
        [ProducesResponseType(400)]
        public IActionResult BuscarClientePorId(int id)
        {
            try
            {
                return Ok(_clienteService.BuscarClientePorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///   Inserir um cliente na base.
        /// </summary>
        /// <param name="cliente">Irá adicionar um cliente na base de dados</param>
        /// <response code="200"> Retorna uam mensagem que o cliente foi cadastrado com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro no cadastro, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            try
            {
                return Ok(_clienteService.AdicionarCliente(cliente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///   Alterar um cliente da base.
        /// </summary>
        /// <param name="cliente">Irá alterar um cliente na base de dados</param>
        /// <response code="200"> Retorna uma mensagem informando que o cliente foi alterado com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro na alteração, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPut]
        public IActionResult Put(Cliente cliente)
        {
            try
            {
                return Ok(_clienteService.AlterarCliente(cliente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///   Deleta um cliente da base.
        /// </summary>
        /// <param name="cliente">Irá deletar um cliente da base de dados</param>
        /// <response code="200"> Retorna uma mensagem informando que o cliente foi deletado com sucesso. </response>
        /// <response code="400">Caso ocorra algum erro no momento de deletar, retorna mensagem de erro. </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_clienteService.ExcluirCliente(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}