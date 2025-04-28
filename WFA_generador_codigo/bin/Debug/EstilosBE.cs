using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace BE
                {
                
        public class EstilosBE
        {
            public int id { get; set; }
    public string descripcion { get; set; }
        }


                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace BP
                {
                    public class EstilosBP
                    {
                        public int Insertar(BE.EstilosBE objDatosBE)
                        {
                            return new DA.EstilosDA().Insertar(objDatosBE);
                        }

                        public bool Editar(BE.EstilosBE objDatosBE)
                        {
                            return new DA.EstilosDA().Editar(objDatosBE);
                        }
                    }
                }


        public int Insertar(BE.EstilosBE objDatosBE)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[db_accessadmin].[usp_estilos_insertar]";
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 60).Value = objDatosBE.descripcion;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = objDatosBE.id;
                    cmd.Parameters["@id"].Direction = ParameterDirection.InputOutput;

                    General.oDatos.Ejecutar(cmd);
                    return int.Parse(cmd.Parameters["@id"].Value.ToString());  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool Editar(BE.EstilosBE objDatosBE)
        {
            try
            {
                 using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[db_accessadmin].[usp_estilos_editar]";
                    cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 60).Value = objDatosBE.descripcion;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = objDatosBE.id;

                    General.oDatos.Ejecutar(cmd);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
                }