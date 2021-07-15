using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProdutosWebApi.Models
{
    public class DalHelper
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }


        public static List<Produto> GetProdutos()
        {
            List<Produto> _produtos = new List<Produto>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Produtos", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var produto = new Produto();
                                produto.Id = Convert.ToInt32(dr["Id"]);
                                produto.Nome = dr["Nome"].ToString();
                                produto.Descricao = dr["Descricao"].ToString();
                                produto.Preco = Convert.ToDecimal(dr["Preco"]);
                                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                                _produtos.Add(produto);
                            }
                        }
                        return _produtos;
                    }
                }
            }
        }


        public static Produto GetProduto(int id)
        {
            Produto produto = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Produtos Where Id=" + id, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                produto = new Produto();
                                produto.Id = Convert.ToInt32(dr["Id"]);
                                produto.Nome = dr["Nome"].ToString();
                                produto.Descricao = dr["Descricao"].ToString();
                                produto.Preco = Convert.ToDecimal(dr["Preco"]);
                                produto.Estoque = Convert.ToInt32(dr["Estoque"]);
                            }
                        }
                        return produto;
                    }
                }
            }
        }


        public static int InsertProduto(Produto produto)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Insert into Produtos(nome,descricao,preco,estoque) values (@nome, @descricao, @preco, @estoque)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }


        public static int UpdateProduto(Produto produto)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Update Produtos set nome=@nome, descricao=@descricao, preco=@preco, estoque=@estoque where Id = " + produto.Id;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", produto.Id);
                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }


        public static int DeleteProduto(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Delete from Produtos where Id = " + id;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
    }
}
