using System;
using System.Data;
using System.Configuration;
using Projecto_PrograVI_MVC.Conexion;

namespace WindowsService
{
    class DSCorreo
    {
        public DataSet ObtenerCorreos()
        {
            DataSet vloDSCorreos = new DataSet();
            try
            {
                string vlcConexion = ConfigurationManager.AppSettings["ConexFE"].ToString();
                vloDSCorreos = SqlHelper.ExecuteDataset(vlcConexion, "SP_OlvidoClave");
            }
            catch (Exception)
            {
                throw;
            }
            return vloDSCorreos;
        }
    }
}
