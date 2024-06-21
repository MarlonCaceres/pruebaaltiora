using System;
using Newtonsoft.Json;
using Npgsql;
using pruebaaltiora.Models;
using System.Data;

namespace pruebaaltiora.Core
{
    public static partial class Core
    {
        public static ResponseModel Register(
            IConfiguration ao_config,
            ProductModel productModel
            )
        {
            ResponseModel response = new ResponseModel();

            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conexion = new NpgsqlConnection(ConexionDB(ao_config));

            try
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = "DATA.INSERT_PRODUCT".ToLower();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CODE".ToLower(), productModel.Code.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("NAME".ToLower(), productModel.Name.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("PRICE".ToLower(), productModel.Price.ToString()).Direction = ParameterDirection.Input;

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                Utilities.Utilities.ColumnasCambioNombre(dataSet, true);

                response.status = true;

                if (Utilities.Utilities.DataSetConDatos(dataSet))
                {
                    response.data = JsonConvert.SerializeObject(dataSet.Tables[0]);
                    List<PS_Error> listaParametros = System.Text.Json.JsonSerializer.Deserialize<List<PS_Error>>(response.data.ToString());
                    response.data = listaParametros;
                }
                else
                {
                    response.status = false;
                    response.data = "";
                    response.error = 1;
                    response.message = "No se encontro información.";
                }

                return response;
            }
            catch (Exception le_error)
            {
                throw le_error;
            }
            finally
            {
                conexion.Close();
                command.Dispose();
            }
        }
    }
}

