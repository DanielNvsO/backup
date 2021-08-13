using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RepositorioGerenciamento.Entidade;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

using System.Data;
using System.Collections.ObjectModel;

using Gerenciamento.ConexaoAPI;
using System.Windows.Interop;
using System.Net.Http.Handlers;
using ProgressDialog;


namespace Gerenciamento
{
    /// <summary>
    /// Interaction logic for Tela_Procedimentos.xaml
    /// </summary>
    public partial class Tela_Procedimentos : Window
    {
        public Tela_Procedimentos()
        {
            InitializeComponent();
        }

       public void PreencherGrid(List<EntidadeProcedimentos> procedimentos)
        {
            try {

                GridProcedimentos.DataContext = procedimentos;
            }
            catch(Exception)
            {
                throw;
            }

        }


        private void SalvarProcedimentos(object sender, RoutedEventArgs e)
        {

            EntidadeProcedimentos Proc = new EntidadeProcedimentos();
            ExecutarAPI ExecAPI = new ExecutarAPI();
            List<EntidadeProcedimentos> obj;
            HttpResponseMessage msg;

            try {

                Proc.id = int.Parse(id.Text);
                Proc.Nome = NomeProcedimento.Text;
                Proc.Descricao = Descricao.Text;
                Proc.Especialidade = Especialidade.Text;
                Proc.Observacao = Observacao.Text;
                
                if (Proc.id != 0)
                    msg = ExecAPI.ExecutarPOST(Proc, "api/AtualizarProcedimentos");
                else
                    throw new Exception("Precisa selecionar o procedimento que atualizara.");
                
                 obj = JsonConvert.DeserializeObject<List<EntidadeProcedimentos>>(msg.Content.ReadAsStringAsync().Result);
                
                PreencherGrid(obj);

                MessageBox.Show("Concluído!", "Mensagem");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Proc = null;
                ExecAPI = null;
                obj = null;
                msg = null;
            }
           
        }

        private void FiltrarProcedimento(object sender, RoutedEventArgs e)
        {
            EntidadeProcedimentos Proc = new EntidadeProcedimentos();
            ExecutarAPI ExecAPI = new ExecutarAPI();
            HttpResponseMessage msg;
            List<EntidadeProcedimentos> obj;

            try
            {
                
                Proc.Nome = NomeProcedimento.Text;
                Proc.Descricao = Descricao.Text;
                Proc.Especialidade = Especialidade.Text;
                Proc.Observacao = Observacao.Text;

                msg = ExecAPI.ExecutarGET(Proc, "api/ConsultarProcedimentos");

                obj = JsonConvert.DeserializeObject<List<EntidadeProcedimentos>>(msg.Content.ReadAsStringAsync().Result);

                PreencherGrid(obj);

                MessageBox.Show("Concluído!", "Mensagem");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Proc = null;
                ExecAPI = null;
                obj = null;
                msg = null;
            }
        }

        private void GridProcedimentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
                return;

            EntidadeProcedimentos proc;
            try
            {
                proc = (EntidadeProcedimentos)e.AddedItems[0];

                NomeProcedimento.Text = proc.Nome;
                Descricao.Text = proc.Descricao;
                Especialidade.Text = proc.Especialidade;
                Observacao.Text = proc.Observacao;
                id.Text = proc.id.ToString();

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc = null;
            }
        }

        private void CriarProcedimento_Click(object sender, RoutedEventArgs e)
        {

            EntidadeProcedimentos Proc = new EntidadeProcedimentos();
            ExecutarAPI ExecAPI = new ExecutarAPI();
            HttpResponseMessage msg;
            List<EntidadeProcedimentos> obj;

            try
            {

                Proc.Nome = NomeProcedimento.Text;
                Proc.Descricao = Descricao.Text;
                Proc.Especialidade = Especialidade.Text;
                Proc.Observacao = Observacao.Text;


                msg = ExecAPI.ExecutarPOST(Proc, "api/InserirProcedimentos");

                obj = JsonConvert.DeserializeObject<List<EntidadeProcedimentos>>(msg.Content.ReadAsStringAsync().Result);

                PreencherGrid(obj);

                MessageBox.Show("Concluído!", "Mensagem");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Proc = null;
                ExecAPI = null;
                obj = null;
                msg = null;
            }
        }

        private void GridProcedimentos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete)
                return;

            EntidadeProcedimentos Proc = new EntidadeProcedimentos();
            ExecutarAPI ExecAPI = new ExecutarAPI();
            HttpResponseMessage msg;
            List<EntidadeProcedimentos> obj;
            try
            {

                Proc.id = int.Parse(id.Text);

                msg = ExecAPI.ExecutarPOST(Proc, "api/DeleteProcedimentos");

                obj = JsonConvert.DeserializeObject<List<EntidadeProcedimentos>>(msg.Content.ReadAsStringAsync().Result);

                PreencherGrid(obj);

                MessageBox.Show("Concluído!", "Mensagem");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Proc = null;
                ExecAPI = null;
                obj = null;
                msg = null;
            }



        }
    }

    
}
