using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Data;
using ControleEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        /// <summary>
        /// Recupera todos os produtos cadastrados com seu saldo atual
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        [HttpGet]
        public async Task<List<Produto>> Get([FromServices] DataContext context)
        {
            var listaProdutos = await new ProdutoDAO().Produtos();
            return listaProdutos.ToList();
        }

        /// <summary>
        /// Retorna um produto pelo seu ID
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>O produto com seu saldo atual</returns>
        [HttpGet]
        [Route("{id:int}")]
        public Produto Get(int id)
        {
            return new ProdutoDAO().Produto(id);

        }

        /// <summary>
        /// Cadastra um novo produto com seu saldo inicial
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Produto> Post(
            [FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                return new ProdutoDAO().Adicionar(produto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Edita a descrição e o estoque atual de um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<Produto> Put(
            [FromBody] Produto produto,
            int id)
        {
            Produto produtoBd = new ProdutoDAO().Produto(id);
            if (produtoBd == null)
            {
                return BadRequest();
            }
            else
            {
                produtoBd.Descricao = produto.Descricao;
                produtoBd.Estoque = produto.Estoque;

                new ProdutoDAO().Atualizar(produtoBd);

                return NoContent();
            }
        }

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<Produto> Delete(
            int id)
        {
            Produto produto = new ProdutoDAO().Produto(id);
            new ProdutoDAO().Remover(produto);
            
            return NoContent();
        }


        /// <summary>
        /// Movimenta o estoque de um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        [HttpPut]
        [Route("movimentaEstoque/{id:int}")]
        public ActionResult<Produto> MovimentaEstoque(
            [FromBody] AtualizaEstoqueViewModel produto,
            int id)
        {
            Produto produtoBd = new ProdutoDAO().Produto(id);
            if (produtoBd == null)
            {
                return BadRequest();
            }
            else
            {
                produtoBd.Estoque = produto.Estoque;

                new ProdutoDAO().Atualizar(produtoBd);

                return NoContent();
            }
        }
    }
}
