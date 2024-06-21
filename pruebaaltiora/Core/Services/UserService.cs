using Npgsql;
using System.Data;
using Newtonsoft.Json;
using pruebaaltiora.Models;

namespace pruebaaltiora.Core
{
	public static partial class Core
	{

        public static ResponseModel GetAllUser(
            IConfiguration ao_config
            )
        {
            ResponseModel response = new ResponseModel();

            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conexion = new NpgsqlConnection(ConexionDB(ao_config));

            try
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = "DATA.ALL_USER".ToLower();
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                Utilities.Utilities.ColumnasCambioNombreCapital(dataSet);

                response.status = true;

                if (Utilities.Utilities.DataSetConDatos(dataSet))
                {
                    response.data = JsonConvert.SerializeObject(dataSet.Tables[0]);
                    List<UserModel> listaParametros = System.Text.Json.JsonSerializer.Deserialize<List<UserModel>>(response.data.ToString());
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

        public static ResponseModel GetUserById(
            IConfiguration ao_config,
            UserModel userModel
			)
		{
            ResponseModel response = new ResponseModel();

            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conexion = new NpgsqlConnection(ConexionDB(ao_config));

			try
			{
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = "DATA.GET_USER_BY_ID".ToLower();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("USER_ID".ToLower(), userModel.Id).Direction = ParameterDirection.Input;

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                Utilities.Utilities.ColumnasCambioNombre(dataSet, true);

                response.status = true;

                if (Utilities.Utilities.DataSetConDatos(dataSet))
                {
                    response.data = JsonConvert.SerializeObject(dataSet.Tables[0]);
                    List<UserModel> listaParametros = System.Text.Json.JsonSerializer.Deserialize<List<UserModel>>(response.data.ToString());
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


        public static ResponseModel Register(
            IConfiguration ao_config,
            UserModel userModel
            )
        {
            ResponseModel response = new ResponseModel();

            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conexion = new NpgsqlConnection(ConexionDB(ao_config));

            try
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = "DATA.INSERT_USER".ToLower();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("NAME".ToLower(), userModel.Name.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("LASTNAME".ToLower(), userModel.Lastname.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("IDENTIFICATION".ToLower(), userModel.Identification.ToString()).Direction = ParameterDirection.Input;

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

        public static ResponseModel Delete(
            IConfiguration ao_config,
            int Id
            )
        {
            ResponseModel response = new ResponseModel();

            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conexion = new NpgsqlConnection(ConexionDB(ao_config));

            try
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = "DATA.DELETE_USER".ToLower();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ID".ToLower(), Id.ToString()).Direction = ParameterDirection.Input;

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

        public static ResponseModel Update(
            IConfiguration ao_config,
            UserModel userModel
            )
        {
            ResponseModel response = new ResponseModel();

            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection conexion = new NpgsqlConnection(ConexionDB(ao_config));

            try
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = "DATA.UPDATE_USER".ToLower();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ID".ToLower(), userModel.Id.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("NAME".ToLower(), userModel.Name.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("LASTNAME".ToLower(), userModel.Lastname.ToString()).Direction = ParameterDirection.Input;
                command.Parameters.AddWithValue("IDENTIFICATION".ToLower(), userModel.Identification.ToString()).Direction = ParameterDirection.Input;

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

