using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Data
{
    interface IProdutoDAO
    {
        Produto Adicionar(Produto p);
        void Atualizar(Produto p);
        void Remover(Produto p);
        Task<IList<Produto>> Produtos();
    }
}
