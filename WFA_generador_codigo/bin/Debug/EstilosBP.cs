
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