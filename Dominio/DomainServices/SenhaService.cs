using Desafio.Dominio.Interfaces.ServicesInterface;
using System.Text.RegularExpressions;

namespace Desafio.Dominio.DomainServices
{
    public class SenhaService : ISenhaService
    {
        public bool SenhaEhValida(string senha)
        {
            return Regex.IsMatch(senha, @"^(?=.*[0-9])(?=.*[^a-zA-Z])[a-zA-Z0-9]{9,}$");
        }

    }
}
