using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutosWebApi.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> All { get; }
        Produto Find(int id);
        void Insert(Produto item);
        void Update(Produto item);
        void Delete(int id);

    }
}