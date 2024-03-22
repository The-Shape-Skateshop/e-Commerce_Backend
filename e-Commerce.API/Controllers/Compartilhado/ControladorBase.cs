using AutoMapper;
using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Servico.Compartilhado;
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
        readonly IMapper _map;
        readonly IServicoBase<TEntity> _service;

        public ControladorBase(IServicoBase<TEntity> service, IMapper map)
        {
            this._map = map;
            this._service = service;
        }
    }
}
