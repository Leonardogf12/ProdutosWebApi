using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdutosWebApi.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> _produtos;


        public ProdutoRepositorio()
        {
            InicializaDados();
        }


        private void InicializaDados()
        {
            _produtos = DalHelper.GetProdutos();
        }


        public IEnumerable<Produto> All
        {
            get { return _produtos; }
        }


        public void Delete(int id)
        {
            DalHelper.DeleteProduto(id);
        }


        public Produto Find(int id)
        {
            return DalHelper.GetProduto(id);
        }


        public void Insert(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }
                DalHelper.InsertProduto(produto);
        }


        public void Update(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }
            DalHelper.UpdateProduto(produto);
        }
    }
}