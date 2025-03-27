using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.IO;


namespace WFA_generador_codigo
{
    public partial class formulario : DevExpress.XtraEditors.XtraForm
    {
        //Conexion a la base de datos
        private SqlConnection conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
        private ContextMenuStrip menu_opciones = new ContextMenuStrip();

        public formulario()
        {
            InitializeComponent();
            //Se agregan las opciones para el menu
            menu_opciones.Items.Add("Generar estructuras", null, OpcionEstructura_Click);
            menu_opciones.Items.Add("Generar estructuras simples", null, OpcionEstructuraSimple_Click);

            // Asociar el evento de clic derecho
            listBoxControl1.MouseUp += listBoxControl1_MouseUp;
        }

        //metodo para convertir la primera letra de un texto en mayuscula
        public static string Mayuscula_primera_letra(string texto)
        {
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }

        //evento que carga las bases de datos cuando inicia el formulario
        private void formulario_Load(object sender, EventArgs e)
        {
            //Combox con las bases de datos disponibles
            List<Bases> bases = Bases.GetSampleData(conexion);
            lookUpEdit1.Properties.DataSource = bases;
            lookUpEdit1.Properties.DisplayMember = "Nombre";
            lookUpEdit1.Properties.ValueMember = "Nombre";
            lookUpEdit1.Properties.NullText = "Seleccione una opción";
            //Eventos de click sobre registros
            lookUpEdit1.EditValueChanged += lookUpEdit1_EditValueChanged; //Sobre las bases de datos
            listBoxControl1.SelectedIndexChanged += listBoxControl1_SelectedIndexChanged; //Sobre las tablas
        }
        // cargar las tablas en la lista
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string nombreBase = lookUpEdit1.EditValue?.ToString();

            if (!string.IsNullOrEmpty(nombreBase))
            {
                ObtenerTablas(nombreBase);
            }
        }

        // cargar los campos en la tabla de la aplicacion
        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tablaSeleccionada = listBoxControl1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tablaSeleccionada))
            {
                EjecutarProcedimiento(tablaSeleccionada);
            }
        }

        //ejecuta la consulta para mostrar los campos de la base seleccionada
        private void ObtenerTablas(string nombreBase)
        {
            List<string> tablas = new List<string>();
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                //Consulta que toma el nombre seleccionado como parametro
                string query = $"USE [{nombreBase}]; SELECT name FROM sys.tables";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tablas.Add(reader["name"].ToString());
                        }
                    }
                }
                //Manda la informacion al objeto de tablas a la lista
                listBoxControl1.DataSource = tablas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las tablas: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void listBoxControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBoxControl1.IndexFromPoint(e.Location);
                // verifica si hay un elemento seleccionado
                if (index != ListBox.NoMatches)
                {
                    // seleccionar el elemento donde se hace click
                    listBoxControl1.SelectedIndex = index;
                    // muestra el menu en la posición del click
                    menu_opciones.Show(listBoxControl1, e.Location);
                }
            }
        }

        //opcion que ejecuta todos los metodos disponibles
        private void OpcionEstructura_Click(object sender, EventArgs e)
        {
            EjecutarAccion(GenerarProcedimientos, Generar_codigo_completo, Generar_archivo_clase, Generar_archivo_metodo);
        }

        private void OpcionEstructuraSimple_Click(object sender, EventArgs e)
        {
            EjecutarAccion(Generar_catalogos_BP, Generar_catalogos_DA, Generar_procedimiento_seleccionar_catalogo );
        }

        // metodo para reducir código repetitivo
        private void EjecutarAccion(params Action<string>[] acciones)
        {
            string tablaSeleccionada = listBoxControl1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(tablaSeleccionada))
            {
                foreach (var accion in acciones)
                {
                    accion(tablaSeleccionada);
                }
                MessageBox.Show("Accion realizada");
            }
            else
            {
                MessageBox.Show("Debes seleccionar una tabla");
            }
        }

        // Método para ejecutar el procedimiento con los detalles de la tabla
        private void EjecutarProcedimiento(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                // Procedimiento almacenado para obtener detalles de la tabla
                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    // Cargar datos en un DataTable
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    // Asignar los datos al GridControl de DevExpress
                    tabla_propiedades.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el procedimiento: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void Generar_codigo_completo(string tabla)
        {
            try
            {
                // llamamos a los métodos previos para generar las partes del código
                string contenidoGeneradoClase = Generar_clase(tabla);
                string contenidoGeneradoEstructura = Generar_estructura_simple(tabla);
                string contenidoGeneradoInsertar = Generar_metodo_insertar(tabla);
                string contenidoGeneradoEditar = Generar_metodo_editar(tabla);

                // ahora concatenamos todo el contenido y lo asignamos al componente texto_metodo
                string contenidoCompleto = contenidoGeneradoClase + "\n\n" +
                                           contenidoGeneradoEstructura + "\n\n" +
                                           contenidoGeneradoInsertar + "\n\n" +
                                           contenidoGeneradoEditar;

                texto_metodo.Text = contenidoCompleto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el código completo: " + ex.Message);
            }
        }

        private string Generar_procedimiento_insertar(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                // inicializamos los valores donde vamos a contener los parametros de nuestra consulta y que valor tendrán
                List<string> parametros = new List<string>();
                List<string> valores = new List<string>();
                string nombreId = "";

                // Obtener detalles de la tabla
                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreColumna = reader["Campo"].ToString();
                            string tipoDato = reader["Tipo"].ToString();
                            bool esIdentity = Convert.ToInt32(reader["EsIdentity"]) == 1;

                            // Ignoramos el id para la inserción ya que es autoincrementable
                            if (esIdentity)
                            {
                                nombreId = nombreColumna;
                                continue;
                            }
                            string parametro;
                            switch (tipoDato)
                            {
                                case "nvarchar":
                                case "varchar":
                                    parametro = $"@{nombreColumna} {tipoDato}({reader["Tamaño"]})";
                                    break;
                                case "int":
                                    parametro = $"@{nombreColumna} int";
                                    break;
                                case "bit":
                                    parametro = $"@{nombreColumna} bit";
                                    break;
                                case "numeric":
                                case "decimal":
                                    parametro = $"@{nombreColumna} numeric(12,2)";
                                    break;
                                case "date":
                                case "datetime":
                                    parametro = $"@{nombreColumna} {tipoDato}";
                                    break;
                                default:
                                    parametro = $"@{nombreColumna} {tipoDato}";
                                    break;
                            }

                            parametros.Add(parametro);
                            valores.Add($"@{nombreColumna}");
                        }
                    }
                }

                // Generar el procedimiento almacenado
                string procedimiento = $@"
            CREATE PROCEDURE [db_accessadmin].[usp_{tabla}_insertar] 
            {string.Join(",\n\t", parametros)},
            @id int OUTPUT
            AS
            BEGIN
                BEGIN TRY
                    BEGIN TRANSACTION

                    INSERT INTO db_accessadmin.{tabla}
                    ({string.Join(", ", parametros.Select(p => p.Split(' ')[0].TrimStart('@')))})
                    VALUES
                    ({string.Join(", ", valores)})

                    SET @id = SCOPE_IDENTITY()

                    COMMIT TRANSACTION
                END TRY
                BEGIN CATCH
                    ROLLBACK TRANSACTION
                    DECLARE @ErrorMessage NVARCHAR(4000);
                    DECLARE @ErrorSeverity INT;
                    DECLARE @ErrorState INT;    
                    SELECT @ErrorMessage = ERROR_MESSAGE(),
                           @ErrorSeverity = ERROR_SEVERITY(),
                           @ErrorState = ERROR_STATE();    
                    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
                END CATCH
            END";

                // Devolver el procedimiento generado como texto
                return procedimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el procedimiento almacenado: " + ex.Message);
                return null; // O retornar el mensaje de error según lo que prefieras
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private string Generar_procedimiento_editar(string tabla)
        {
            // Usamos try-catch solo para la ejecución de la lógica
            try
            {
                // Abrir la conexión si está cerrada
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                List<string> parametros = new List<string>();
                List<string> asignaciones = new List<string>();
                List<string> condicionesWhere = new List<string>();
                string nombreId = "";

                // Obtener los detalles de la tabla mediante el procedimiento almacenado
                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreColumna = reader["Campo"].ToString();
                            string tipoDato = reader["Tipo"].ToString();
                            bool esIdentity = Convert.ToInt32(reader["EsIdentity"]) == 1;

                            string parametro;
                            switch (tipoDato)
                            {
                                case "nvarchar":
                                case "varchar":
                                    parametro = $"@{nombreColumna} {tipoDato}({reader["Tamaño"]})";
                                    break;
                                case "int":
                                    parametro = $"@{nombreColumna} int";
                                    break;
                                case "bit":
                                    parametro = $"@{nombreColumna} bit";
                                    break;
                                case "numeric":
                                case "decimal":
                                    parametro = $"@{nombreColumna} numeric(12,2)";
                                    break;
                                case "date":
                                case "datetime":
                                    parametro = $"@{nombreColumna} {tipoDato}";
                                    break;
                                default:
                                    parametro = $"@{nombreColumna} {tipoDato}";
                                    break;
                            }

                            parametros.Add(parametro);

                            if (!esIdentity) // Excluimos los ID del UPDATE
                            {
                                asignaciones.Add($"{nombreColumna} = @{nombreColumna}");
                            }

                            if (esIdentity)
                            {
                                nombreId = nombreColumna;
                            }
                            else
                            {
                                condicionesWhere.Add($"{nombreColumna} = @{nombreColumna}");
                            }
                        }
                    }
                }
                // Si hay un ID con identity, se utiliza para la cláusula WHERE
                string whereClause = !string.IsNullOrEmpty(nombreId) ? $"{nombreId} = @{nombreId}" : string.Join(" AND ", condicionesWhere);

                // Generamos el texto del procedimiento almacenado
                return $@"
                CREATE PROCEDURE [db_accessadmin].[usp_{tabla}_editar] 
                    {string.Join(",\n\t", parametros)}
                AS
                BEGIN
                    BEGIN TRY
                        BEGIN TRANSACTION

                        UPDATE db_accessadmin.{tabla}
                        SET {string.Join(",\n\t\t", asignaciones)}
                        WHERE {whereClause}

                        COMMIT TRANSACTION
                    END TRY
                    BEGIN CATCH
                        ROLLBACK TRANSACTION
                        DECLARE @ErrorMessage NVARCHAR(4000);
                        DECLARE @ErrorSeverity INT;
                        DECLARE @ErrorState INT;    
                        SELECT @ErrorMessage = ERROR_MESSAGE(),
                               @ErrorSeverity = ERROR_SEVERITY(),
                               @ErrorState = ERROR_STATE();    
                        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
                    END CATCH
                END";
            }
            catch (Exception ex)
            {
                // En lugar de usar MessageBox, lanzamos el error para que sea manejado por quien llame al método
                throw new Exception("Error al generar el procedimiento almacenado: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void GenerarProcedimientos(string tabla)
        {
            try
            {
                // Abrimos la conexión si está cerrada
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                // Generar procedimiento seleccionar
                string procedimientoSeleccionar = Generar_procedimiento_seleccionar(tabla);
                // Generar procedimiento insertar
                string procedimientoInsertar = Generar_procedimiento_insertar(tabla);
                // Generar procedimiento editar
                string procedimientoEditar = Generar_procedimiento_editar(tabla);

                // Combinar los tres procedimientos en el MemoEdit
                texto_usp.Lines = new string[] { procedimientoSeleccionar, "", procedimientoInsertar, "", procedimientoEditar };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar los procedimientos almacenados: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private string Generar_procedimiento_seleccionar(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                List<string> columnas = new List<string>();
                string nombreId = "";
                string tipoId = "";
                bool tieneId = false;

                // Obtener detalles de la tabla
                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreColumna = reader["Campo"].ToString();
                            string tipoDato = reader["Tipo"].ToString();

                            columnas.Add(nombreColumna);

                            // buscamos si hay un campo id
                            if (nombreColumna.ToLower() == "id")
                            {
                                tieneId = true;
                                nombreId = nombreColumna;
                                tipoId = tipoDato; // Se guarda el tipo de id
                            }
                        }
                    }
                }

                // Se busca el id de la tabla para incluirlo en el parámetro
                string parametroId = tieneId ? $"@{nombreId} {tipoId} = NULL" : "";

                // Generar el procedimiento almacenado con filtro
                string procedimiento = $@"
        CREATE PROCEDURE [db_accessadmin].[usp_{tabla}_seleccionar] 
        {parametroId}
        AS
        BEGIN
            SELECT {string.Join(", ", columnas)}
            FROM db_accessadmin.{tabla}
            {(tieneId ? $"WHERE (@{nombreId} IS NULL OR {tabla}.{nombreId} = @{nombreId})" : "")}
        END";

                // Devolver el procedimiento generado como texto
                return procedimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el procedimiento almacenado: " + ex.Message);
                return null; // O retornar el mensaje de error según lo que prefieras
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        private string Generar_metodo_insertar(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                string esquema = "dbaccess_admin";
                using (SqlCommand cmd = new SqlCommand("SELECT SCHEMA_NAME()", conexion))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        esquema = result.ToString();
                    }
                }

                List<string> parametros = new List<string>();
                string nombreId = "";

                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreColumna = reader["Campo"].ToString();
                            string tipoDato = reader["Tipo"].ToString();
                            bool esIdentity = Convert.ToInt32(reader["EsIdentity"]) == 1;

                            if (esIdentity)
                            {
                                nombreId = nombreColumna;
                                continue;
                            }

                            string paramDefinition;
                            switch (tipoDato)
                            {
                                case "nvarchar":
                                case "varchar":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.NVarChar, {reader["Tamaño"]}).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "int":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.Int).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "bit":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.Bit).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "numeric":
                                case "decimal":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.Float).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "date":
                                case "datetime":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.DateTime).Value = objDatosBE.{nombreColumna};";
                                    break;
                                default:
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.VarChar).Value = objDatosBE.{nombreColumna};";
                                    break;
                            }

                            parametros.Add(paramDefinition);
                        }
                    }
                }

                string metodoInsertar = $@"
        public int Insertar(BE.{Mayuscula_primera_letra(tabla)}BE objDatosBE)
        {{
            try
            {{
                using (SqlCommand cmd = new SqlCommand())
                {{
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = ""[{esquema}].[usp_{tabla}_insertar]"";
                    {string.Join("\n            ", parametros)}
                    cmd.Parameters.Add(""@id"", SqlDbType.Int).Value = objDatosBE.id;
                    cmd.Parameters[""@id""].Direction = ParameterDirection.InputOutput;

                    General.oDatos.Ejecutar(cmd);
                    return int.Parse(cmd.Parameters[""@id""].Value.ToString());  
                }}
            }}
            catch (Exception ex)
            {{
                throw new Exception(ex.Message);
            }}
        }}";

                return metodoInsertar; // Devolvemos el código generado para el método de inserción
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el método: " + ex.Message);
                return string.Empty; // Devolvemos un string vacío en caso de error
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private string Generar_metodo_editar(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                List<string> parametros = new List<string>();
                string nombreId = "";

                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreColumna = reader["Campo"].ToString();
                            string tipoDato = reader["Tipo"].ToString();
                            bool esIdentity = Convert.ToInt32(reader["EsIdentity"]) == 1;

                            if (esIdentity)
                            {
                                nombreId = nombreColumna;
                                continue;
                            }

                            string paramDefinition = string.Empty;

                            switch (tipoDato)
                            {
                                case "nvarchar":
                                case "varchar":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.NVarChar, {reader["Tamaño"]}).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "int":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.Int).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "bit":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.Bit).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "numeric":
                                case "decimal":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.Float).Value = objDatosBE.{nombreColumna};";
                                    break;
                                case "date":
                                case "datetime":
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.DateTime).Value = objDatosBE.{nombreColumna};";
                                    break;
                                default:
                                    paramDefinition = $"cmd.Parameters.Add(\"@{nombreColumna}\", SqlDbType.VarChar).Value = objDatosBE.{nombreColumna};";
                                    break;
                            }

                            parametros.Add(paramDefinition);
                        }
                    }
                }

                string metodoEditar = $@"
        public bool Editar(BE.{Mayuscula_primera_letra(tabla)}BE objDatosBE)
        {{
            try
            {{
                 using (SqlCommand cmd = new SqlCommand())
                {{
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = ""[db_accessadmin].[usp_{tabla}_editar]"";
                    {string.Join("\n", parametros)}
                    cmd.Parameters.Add(""@id"", SqlDbType.Int).Value = objDatosBE.id;

                    General.oDatos.Ejecutar(cmd);
                    return true;
                }}
            }}
            catch (Exception ex)
            {{
                throw new Exception(ex.Message);
            }}
        }}";

                return metodoEditar; // Devolvemos el código generado para el método de edición
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el método: " + ex.Message);
                return string.Empty; // Devolvemos un string vacío en caso de error
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        private void Generar_archivo_clase(string tabla)
        {
            try
            {
                // para obtener la ruta de la aplicacion
                string rutaEjecutable = AppDomain.CurrentDomain.BaseDirectory;

                // para asignar el nombre del archivo y la extension
                string nombreArchivo = Mayuscula_primera_letra(tabla) + "BE.cs";
                string rutaArchivo = Path.Combine(rutaEjecutable, nombreArchivo);

                // tomamos el contenido generado en el metodo Generar_Clase
                string contenidoClase = texto_metodo.Text;

                // agregamos las propiedades de la clase
                string contenidoFinal = $@"using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace BE
                {{
                {contenidoClase}
                }}";

                // almacenamos el archivo rn la ruta asignada
                File.WriteAllText(rutaArchivo, contenidoFinal);

                Console.WriteLine($"Archivo generado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
            }
        }

        private string Generar_estructura_simple(string tabla)
        {
            try
            {
                // Para obtener la ruta de la aplicación
                string rutaEjecutable = AppDomain.CurrentDomain.BaseDirectory;

                // Para asignar el nombre del archivo y la extensión
                string nombreArchivo = Mayuscula_primera_letra(tabla) + "BP.cs";
                string rutaArchivo = Path.Combine(rutaEjecutable, nombreArchivo);

                // Tomamos el contenido generado en el método Generar_Clase
                string contenidoClase = texto_metodo.Text;

                // Agregamos las propiedades de la clase
                string contenidoFinal = $@"
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace BP
                {{
                    public class {Mayuscula_primera_letra(tabla)}BP
                    {{
                        public int Insertar(BE.{Mayuscula_primera_letra(tabla)}BE objDatosBE)
                        {{
                            return new DA.{Mayuscula_primera_letra(tabla)}DA().Insertar(objDatosBE);
                        }}

                        public bool Editar(BE.{Mayuscula_primera_letra(tabla)}BE objDatosBE)
                        {{
                            return new DA.{Mayuscula_primera_letra(tabla)}DA().Editar(objDatosBE);
                        }}
                    }}
                }}";

                // Almacenamos el archivo en la ruta asignada
                File.WriteAllText(rutaArchivo, contenidoFinal);

                // Devolvemos el contenido generado
                return contenidoFinal;
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo mostramos y devolvemos un mensaje de error
                return "Error al generar el archivo: " + ex.Message;
            }
        }


        private void Generar_archivo_metodo(string tabla)
        {
            try
            {
                // para obtener la ruta de la aplicacion
                string rutaEjecutable = AppDomain.CurrentDomain.BaseDirectory;

                // para asignar el nombre del archivo y la extension
                string nombreArchivo = Mayuscula_primera_letra(tabla) + "DA.cs";
                string rutaArchivo = Path.Combine(rutaEjecutable, nombreArchivo);

                // tomar el contenido generado en el metodo Generar_metodo_insertar
                Generar_metodo_insertar(tabla);
                string metodoInsertar = texto_metodo.Text;

                // tomar el contenido generado en el metodo Generar_metodo_editar
                Generar_metodo_editar(tabla);
                string metodoEditar = texto_metodo.Text;

                // crearemos el contenido del archivo .cs
                string contenidoFinal = $@"using System;
                using System.Collections.Generic;
                using System.Data;
                using System.Data.SqlClient;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace DA
                {{
                    public class {Mayuscula_primera_letra(tabla)}DA
                    {{
                        
                        {metodoInsertar}

                        {metodoEditar}
                    }}
                }}";

                // almacenamos el archivo en la ruta asignada
                File.WriteAllText(rutaArchivo, contenidoFinal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo: " + ex.Message);
            }
        }

        private string Generar_clase(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                List<string> propiedades = new List<string>();

                // Obtenemos los detalles de la tabla
                using (SqlCommand cmd = new SqlCommand("ups_mostrar_campos_tabla", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_tabla", tabla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreColumna = reader["Campo"].ToString();
                            string tipoDato = reader["Tipo"].ToString();
                            string tipoCSharp;

                            // Convertir tipo de valor 
                            switch (tipoDato)
                            {
                                case "nvarchar":
                                case "varchar":
                                    tipoCSharp = "string";
                                    break;
                                case "int":
                                    tipoCSharp = "int";
                                    break;
                                case "bit":
                                    tipoCSharp = "bool";
                                    break;
                                case "numeric":
                                case "decimal":
                                case "float":
                                    tipoCSharp = "double";
                                    break;
                                case "date":
                                case "datetime":
                                    tipoCSharp = "DateTime";
                                    break;
                                default:
                                    tipoCSharp = "string";
                                    break;
                            }

                            // Agregar la propiedad a la lista
                            propiedades.Add($"public {tipoCSharp} {nombreColumna} {{ get; set; }}");
                        }
                    }
                }

                // Generación de la clase con las propiedades de la tabla
                string claseGenerada = $@"
        public class {Mayuscula_primera_letra(tabla)}BE
        {{
            {string.Join("\n    ", propiedades)}
        }}";

                return claseGenerada; // Devolvemos el código de la clase generada
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la clase: " + ex.Message);
                return string.Empty; // Devolvemos un string vacío en caso de error
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        //metodo para genera la estructura simple del catalogo
        private void Generar_catalogos_BP(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                string claseBP = $@"
            using System;
            using System.Collections.Generic;
            using System.Data;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;

            namespace BP
            {{
                public class CatalogosGeneralesBP
                {{
                    public int {Mayuscula_primera_letra(tabla)}(DataTable tblDatos)
                    {{
                        return new DA.CatalogosGeneralesDA().{Mayuscula_primera_letra(tabla)}(tblDatos);
                    }}
                }}
            }}";

                // Ruta para guardar el archivo
                string rutaEjecutable = AppDomain.CurrentDomain.BaseDirectory;
                string nombreArchivo = "CatalogosGeneralesBP.cs";
                string rutaArchivo = Path.Combine(rutaEjecutable, nombreArchivo);

                // Escribir el archivo generado
                File.WriteAllText(rutaArchivo, claseBP);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el método: " + ex.Message);
                
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        //metodo para generar la estructura con referencia al procedimiento almacenado
        private void Generar_catalogos_DA(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                string esquema = "dbaccess_admin";
                using (SqlCommand cmd = new SqlCommand("SELECT SCHEMA_NAME()", conexion))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        esquema = result.ToString();
                    }
                }

                string metodoDA = $@"
                using System;
                using System.Collections.Generic;
                using System.Data;
                using System.Data.SqlClient;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace DA
                {{
                    public class CatalogosGeneralesDA
                    {{
                        public int {Mayuscula_primera_letra(tabla)}(DataTable tblDatos)
                        {{
                            try
                            {{
                                using (SqlCommand cmd = new SqlCommand())
                                {{
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = ""[{esquema}].[usp_{tabla}_insertar]"";
                                    cmd.Parameters.Add(""@detalle"", SqlDbType.Structured).Value = tblDatos;

                                    General.oDatos.Ejecutar(cmd);
                                    return 1;
                                }}
                            }}
                            catch (Exception ex)
                            {{
                                throw new Exception(ex.Message);
                            }}
                        }}     
                    }}
                }}";

                string rutaEjecutable = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivo = Path.Combine(rutaEjecutable, "CatalogosGeneralesDA.cs");

                File.WriteAllText(rutaArchivo, metodoDA);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo: " + ex.Message);
            
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        //metodo para generar el procedimiento de catalogo
        private void Generar_procedimiento_seleccionar_catalogo(string tabla)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                string esquema = "dbaccess_admin";
                using (SqlCommand cmd = new SqlCommand("SELECT SCHEMA_NAME()", conexion))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        esquema = result.ToString();
                    }
                }

                string procedimiento = $@"
                CREATE PROCEDURE [{esquema}].[usp_{tabla}_seleccionar]
                AS
                BEGIN
                    SELECT id, descripcion, 0 AS [status]
                    FROM [{esquema}].[{tabla}]
                    WHERE baja = 0  
                    ORDER BY descripcion
                END";

                // asignamos el texto generado al componente 
                texto_usp.Text = procedimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el procedimiento almacenado: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        //aqui terminan los metodos
    }


    //clase para carga las bases de datos en el combo box de la aplicacion
    public class Bases
    {
        public string Nombre { get; set; }
        public Bases(string nombre)
        {
            Nombre = nombre;
        }
        //lista que se llena con la informacion de la lista
        public static List<Bases> GetSampleData(SqlConnection conexion)
        {
            List<Bases> listaTablas = new List<Bases>();
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                //Consulta que devuelve todas las bases de datos
                string query = "SELECT name FROM sys.databases";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaTablas.Add(new Bases(reader["name"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las bases de datos: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return listaTablas;
        }
    }
}
