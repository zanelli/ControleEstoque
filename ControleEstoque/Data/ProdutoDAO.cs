using ControleEstoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Data
{
    public class ProdutoDAO : IProdutoDAO, IDisposable
    {
        private readonly DataContext contexto;

        public ProdutoDAO()
        {
            this.contexto = new DataContext();
        }

        public Produto Adicionar(Produto p)
        {
            contexto.Produto.Add(p);
            contexto.SaveChanges();

            return p;
        }

        public void Atualizar(Produto p)
        {
            contexto.Produto.Update(p);
            contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public async Task<IList<Produto>> Produtos()
        {
            return await contexto.Produto.ToListAsync();
        }

        public Produto Produto(int id)
        {
            return contexto.Produto
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public void Remover(Produto p)
        {
            contexto.Produto.Remove(p);
            contexto.SaveChanges();
        }

    }
}
