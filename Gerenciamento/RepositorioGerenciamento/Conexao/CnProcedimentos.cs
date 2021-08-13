using RepositorioGerenciamento.Entidade;
using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;


namespace Repositorio.Conexao
{
    public class CnProcedimentos
    {
        //Consultar
        public List<EntidadeProcedimentos> ConsultarProcedimentos(EntidadeProcedimentos ProcedimentosFiltro) {

            Conexao strcn = new Conexao();
            SqlConnection cn =  strcn.GetConnection();
            List<EntidadeProcedimentos> _return = new List<EntidadeProcedimentos>();
            SqlCommand cmd;
            EntidadeProcedimentos Proc;

            try { 
                cmd = new SqlCommand("prd_ConProcedimentos", cn);

                cmd.Parameters.AddWithValue("@Id", ProcedimentosFiltro.id);
                cmd.Parameters.AddWithValue("@Nome", ProcedimentosFiltro.Nome);
                cmd.Parameters.AddWithValue("@Descricao", ProcedimentosFiltro.Descricao);
                cmd.Parameters.AddWithValue("@Observacao", ProcedimentosFiltro.Observacao);
                cmd.Parameters.AddWithValue("@Especialidade", ProcedimentosFiltro.Especialidade);
           
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                        
                            while (dr.Read())
                            {
                                Proc = new EntidadeProcedimentos();

                                Proc.id =   int.Parse(dr["Id"].ToString());
                                Proc.Nome = dr["Nome"].ToString();
                                Proc.Descricao = dr["Descricao"].ToString();
                                Proc.Observacao = dr["Observacao"].ToString();
                                Proc.Especialidade = dr["Especialidade"].ToString();
                                Proc.DataCadastro = DateTime.Parse(dr["DataCadastro"].ToString());

                                _return.Add(Proc);

                            }
                        }
                    }

                    return _return;
                }

            }catch(Exception)
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                Proc = null;
            }

        }



        //Inserir
        public List<EntidadeProcedimentos> InserirProcedimentos(EntidadeProcedimentos Procedimentos)
        {
            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            List<EntidadeProcedimentos> _return =  new List<EntidadeProcedimentos>();
            SqlCommand cmd;
            EntidadeProcedimentos Proc;

            try { 

                cmd = new SqlCommand("prd_InsertProcedimentos", cn);

                cmd.Parameters.AddWithValue("@Nome", Procedimentos.Nome);
                cmd.Parameters.AddWithValue("@Descricao", Procedimentos.Descricao);
                cmd.Parameters.AddWithValue("@Especialidade", Procedimentos.Especialidade);
                cmd.Parameters.AddWithValue("@Observacao", Procedimentos.Observacao);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                        
                            while (dr.Read())
                            {
                                Proc = new EntidadeProcedimentos();

                                Proc.id = int.Parse(dr["Id"].ToString());
                                Proc.Nome = dr["Nome"].ToString();
                                Proc.Descricao = dr["Descricao"].ToString();
                                Proc.Observacao = dr["Observacao"].ToString();
                                Proc.Especialidade = dr["Especialidade"].ToString();
                                Proc.DataCadastro = DateTime.Parse(dr["DataCadastro"].ToString());

                                _return.Add(Proc);

                            }
                        }
                    }

                    return _return;
                }

            }catch(Exception )
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                Proc = null;
            }

        }

        public List<EntidadeProcedimentos> DeleteProcedimentos(EntidadeProcedimentos Procedimentos)
        {
            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            List<EntidadeProcedimentos> _return = new List<EntidadeProcedimentos>(); 
            SqlCommand cmd;
            EntidadeProcedimentos Proc;

            try { 

                cmd = new SqlCommand("prd_DeleteProcedimentos", cn);

                cmd.Parameters.AddWithValue("@Id", Procedimentos.id);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                Proc = new EntidadeProcedimentos();

                                Proc.id = int.Parse(dr["Id"].ToString());
                                Proc.Nome = dr["Nome"].ToString();
                                Proc.Descricao = dr["Descricao"].ToString();
                                Proc.Observacao = dr["Observacao"].ToString();
                                Proc.Especialidade = dr["Especialidade"].ToString();
                                Proc.DataCadastro = DateTime.Parse(dr["DataCadastro"].ToString());

                                _return.Add(Proc);

                            }
                        }
                    }

                    return _return;
                }

            }catch(Exception)
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                Proc = null;
            }

        }

        public List<EntidadeProcedimentos> AtualizarProcedimentos(EntidadeProcedimentos Procedimentos)
        {
            Conexao strcn = new Conexao();
            SqlConnection cn = strcn.GetConnection();
            List<EntidadeProcedimentos> _return = new List<EntidadeProcedimentos>(); 
            SqlCommand cmd;
            EntidadeProcedimentos Proc;

            try { 

                cmd = new SqlCommand("prd_UpdateProcedimentos", cn);

                cmd.Parameters.AddWithValue("@Id", Procedimentos.id);
                cmd.Parameters.AddWithValue("@Nome", Procedimentos.Nome);
                cmd.Parameters.AddWithValue("@Descricao", Procedimentos.Descricao);
                cmd.Parameters.AddWithValue("@Especialidade", Procedimentos.Especialidade);
                cmd.Parameters.AddWithValue("@Observacao", Procedimentos.Observacao);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (cmd)
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                        
                            while (dr.Read())
                            {
                                Proc = new EntidadeProcedimentos();

                                Proc.id = int.Parse(dr["Id"].ToString());
                                Proc.Nome = dr["Nome"].ToString();
                                Proc.Descricao = dr["Descricao"].ToString();
                                Proc.Observacao = dr["Observacao"].ToString();
                                Proc.Especialidade = dr["Especialidade"].ToString();
                                Proc.DataCadastro = DateTime.Parse(dr["DataCadastro"].ToString());

                                _return.Add(Proc);

                            }
                        }
                    }

                    return _return;
                }

            }catch(Exception)
            {
                throw;
            }
            finally
            {
                strcn = null;
                cn = null;
                _return = null;
                cmd = null;
                Proc = null;
            }

        }


    }

}
