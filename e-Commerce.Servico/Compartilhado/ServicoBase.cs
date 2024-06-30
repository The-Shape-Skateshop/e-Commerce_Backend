using FluentValidation;
using FluentValidation.Results;

namespace e_Commerce.Servico.Compartilhado
{
    public class ServicoBase<TEntity, TValidator>
        where TValidator : AbstractValidator<TEntity>, new()
    {
        protected virtual Result Validar(TEntity registro)
        {
            var validador = new TValidator();

            var resultado = validador.Validate(registro);

            var erros = new List<Error>();

            foreach (ValidationFailure err in resultado.Errors)
            {
                Log.Logger.Warning(err.ErrorMessage);

                erros.Add(new Error(err.ErrorMessage));
            }

            if (erros.Any())
            {
                return Result.Fail(erros);
            }

            return Result.Ok();
        }
    }
}
