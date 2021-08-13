using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RepositorioGerenciamento.Entidade;
using Repositorio;
using Repositorio.Conexao;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API_Consultas.Controllers
{
    public class ValuesController : ApiController
    {
       
        [HttpPost]
        [Route("api/ConsultarProcedimentos")]
        public IHttpActionResult ConsultarProcedimentos([FromBody] EntidadeProcedimentos procedimentos)
        {
            CnProcedimentos Proc = new CnProcedimentos();
            List<EntidadeProcedimentos> _return;
            try { 
            
                _return = Proc.ConsultarProcedimentos(procedimentos);

                return Ok(_return);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                Proc = null;
                _return = null;
            }



        }

        protected IHttpActionResult JsonOK(object T = null)
        {
            if (T == null)
                return Ok("");

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(T));

        }

        [HttpPost]
        [Route("api/InserirProcedimentos")]
        public IHttpActionResult InserirProcedimentos([FromBody] EntidadeProcedimentos obj)
        {
            CnProcedimentos Proc = new CnProcedimentos();
            List<EntidadeProcedimentos> _return;
            try
            {
                
                _return = Proc.InserirProcedimentos(obj);

                return Ok(_return);


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally {
                Proc = null;
                _return = null;
            }

        }

        [HttpPost]
        [Route("api/DeleteProcedimentos")]
        public IHttpActionResult DeleteProcedimentos([FromBody] EntidadeProcedimentos obj)
        {
            CnProcedimentos Proc = new CnProcedimentos();
            List<EntidadeProcedimentos> _return;

            try
            {

                _return = Proc.DeleteProcedimentos(obj);

                return Ok(_return);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                Proc = null;
                _return = null;
            }

        }


        [HttpPost]
        [Route("api/AtualizarProcedimentos")]
        public IHttpActionResult AtualizarProcedimentos([FromBody] EntidadeProcedimentos obj)
        {
            CnProcedimentos Proc = new CnProcedimentos();
            List<EntidadeProcedimentos> _return;

            try
            {
                _return = Proc.AtualizarProcedimentos(obj);

                return Ok(_return);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                Proc = null;
                _return = null;
            }

        }


    }
}
