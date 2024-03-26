using AutoMapper;
using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Servico.Compartilhado;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Commerce.API.Controllers.Compartilhado
{
    public class ControladorBase<TList, TForm, TView, TEntity> : ControllerBase
        where TList : ListBase<TList>
        where TForm : FormBase<TForm>
        where TView : ViewBase<TView>
        where TEntity : EntidadeBase<TEntity>
    {
        readonly IMapper map;
        readonly IServicoBase<TEntity> service;

        public ControladorBase(IServicoBase<TEntity> service, IMapper map)
        {
            this.map = map;
            this.service = service;
        }

        protected IActionResult ProcessarResposta(Result<TEntity> resultado, TForm registroVM = null)
        {
            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            return Ok(new
            {
                Sucesso = true,
                Dados = registroVM
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> SelecionarTodos()
        {
            var resultado = await service.SelecionarTodosAsync();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            List<TList> registrosVM = map.Map<List<TList>>(resultado.Value);
            //O que está em parenteses será convertido no que está entre <>

            return Ok(new
            {
                Sucesso = true,
                Dados = registrosVM
            });
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(string[]), 500)]
        //public virtual async Task<IActionResult> SelecionarPorId(Guid id)
        //{
        //    var resultado = await service.SelecionarPorIdAsync(id);

        //    if (resultado.IsFailed)
        //    {
        //        return BadRequest(new
        //        {
        //            Sucesso = false,
        //            Errors = resultado.Errors.Select(result => result.Message)
        //        });
        //    }

        //    TForm registrosVM = map.Map<TForm>(resultado.Value);
        //    //O que está em parenteses será convertido no que está entre <>

        //    return Ok(new
        //    {
        //        Sucesso = true,
        //        Dados = registrosVM
        //    });
        //}

        [HttpGet("{id}")] // O {} é para colocar o nome do parametro do metodo. É tipo o :id do angular
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var resultado = await service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            TView registroVM = map.Map<TView>(resultado.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = registroVM
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> Inserir(TForm registroVM)
        {
            TEntity registro = map.Map<TEntity>(registroVM);

            var resultado = await service.InserirAsync(registro);

            return ProcessarResposta(resultado, registroVM);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public virtual async Task<IActionResult> Editar(Guid id, TForm registroVM)
        {
            var resultado = await service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            TEntity registro = map.Map(registroVM, resultado.Value);
            #region Porque usar esse outro Map?
            /* Ele pega a referencia do segundo objeto passado pro ele
                * map.Map(valor, referência)
                * 
                * Existem variações de Maps e caso fizesse assim para editar:
                * 
                *    Contato contato = map.Map<Contato>(contatoVM);
                * 
                * O entityframework perderia a referencia do objeto de destino,
                * já que se fizar isso é a mesma coisa de instancia um novo objeto
                */
            #endregion

            var resultadoEdicao = await service.EditarAsync(registro);

            return ProcessarResposta(resultadoEdicao, registroVM);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]//Isso daqui mostra os erros qeu podem retornar do endpoint
        public virtual async Task<IActionResult> Deletar(Guid id)
        {
            var resultado = await service.SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return NotFound(new
                {
                    Sucesso = false,
                    Errors = resultado.Errors.Select(result => result.Message)
                });
            }

            var registro = resultado.Value;

            var resultadoExclusao = await service.DeletarPorRegistroAsync(registro);

            return ProcessarResposta(resultadoExclusao);
        }
    }
}
