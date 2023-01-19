using Enviostisur.Data.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Enviostisur.Models;

namespace Enviostisur.Data.Datasql
{
    public class SPOperaciones
    {
        public SqlConnection conexion;
        public SPOperaciones()
        {
            var config = GetConfiguration();
            conexion = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public async Task<List<MDGranel>> spMailgraneles()
        {
            try
            {
                List<MDGranel> ListaGranel = new List<MDGranel>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TCALMA_GRN001]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDGranel objGran = new MDGranel();
                    objGran.NU_RECA = rdr["NU_RECA"].ToString(); 
                    objGran.NU_DOCU_ORIG = rdr["NU_DOCU_ORIG"].ToString();
                    objGran.NU_SECU_ITEM = rdr["NU_SECU_ITEM"].ToString();
                    objGran.DE_CLIE = rdr["DE_CLIE"].ToString();
                    objGran.DE_CARG = rdr["DE_CARG"].ToString();
                    objGran.DE_ALMA = rdr["DE_ALMA"].ToString();
                    objGran.FE_TARJ = rdr["FE_TARJ"].ToString();
                    objGran.DIAS = rdr["DIAS"].ToString();
                    ListaGranel.Add(objGran);
                }
                conexion.Close();



                return ListaGranel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<MDRequerimiento>> spRequerimiento(string value)
        {
            try
            {
                List<MDRequerimiento> Listreque = new List<MDRequerimiento>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TCREQU_INFO03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VALUE", value);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDRequerimiento objReque = new MDRequerimiento();
                    objReque.nro_reque = rdr["nro_reque"].ToString();
                    objReque.placa = rdr["placa"].ToString();
                    objReque.trans = rdr["trans"].ToString();
                    objReque.carga = rdr["carga"].ToString();
                    objReque.fec_prog = rdr["fec_prog"].ToString();
                    objReque.fec_lleg = rdr["fec_lleg"].ToString();
                    objReque.fec_ante = rdr["fec_ante"].ToString();
                    objReque.fec_1Bal = rdr["fec_1Bal"].ToString();
                    objReque.fec_tarja = rdr["fec_tarja"].ToString();
                    objReque.fec_2Bal = rdr["fec_2Bal"].ToString();
                    objReque.fec_puert = rdr["fec_puert"].ToString();
                    Listreque.Add(objReque);
                }
                conexion.Close();

                return Listreque;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<List<MDRecalada>> spRecalada(string value)
        {
            try
            {
                List<MDRecalada> ListReca = new List<MDRecalada>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TCREQU_INFO04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VALUE", value);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDRecalada objReca = new MDRecalada();
                    objReca.NU_RECA = rdr["NU_RECA"].ToString();
                    objReca.NO_NAVE = rdr["NO_NAVE"].ToString();
                    objReca.DE_CARG = rdr["DE_CARG"].ToString();
                    objReca.TI_DIRE_INDI = rdr["TI_DIRE_INDI"].ToString();
                    objReca.CA_RECE = rdr["CA_RECE"].ToString();
                    objReca.PE_RECE = rdr["PE_RECE"].ToString();
                    objReca.PERDET_C_CANTIDAD_ENTREGADA = rdr["PERDET_C_CANTIDAD_ENTREGADA"].ToString();
                    objReca.PERDET_C_PESO_ENTREGADO = rdr["PERDET_C_PESO_ENTREGADO"].ToString();                 
                    ListReca.Add(objReca);
                }
                conexion.Close();



                return ListReca;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<MDBalanza>> spBalanza(DateTime Fecini, DateTime Fecfin, string recal, int iddocu, int item)
        {
            try
            {
                List<MDBalanza> Listbal = new List<MDBalanza>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TCBALA_Q52]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FECINI", Fecini);
                cmd.Parameters.AddWithValue("@FECFIN", Fecfin);
                cmd.Parameters.AddWithValue("@RECA", recal);
                cmd.Parameters.AddWithValue("@ID_DOCU_ORIG", iddocu);
                cmd.Parameters.AddWithValue("@ITEM", item);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDBalanza objBalanza = new MDBalanza();
                    objBalanza.ID_EMPR = rdr["ID_EMPR"].ToString();
                    objBalanza.ID_EJES = rdr["ID_EJES"].ToString();
                    objBalanza.ST_CIER = rdr["ST_CIER"].ToString();
                    objBalanza.NU_MOVI_BDLO = rdr["NU_MOVI_BDLO"].ToString();
                    objBalanza.NU_MOVI = rdr["NU_MOVI"].ToString();
                    objBalanza.ID_MOVI_BALA = rdr["ID_MOVI_BALA"].ToString();
                    objBalanza.DE_TIPO = rdr["DE_TIPO"].ToString();
                    objBalanza.ID_BALA = rdr["ID_BALA"].ToString();
                    objBalanza.TI_MOVI_INDI = rdr["TI_MOVI_INDI"].ToString();
                    objBalanza.TI_MOVI = rdr["TI_MOVI"].ToString();
                    objBalanza.ID_MOVI_DUES = rdr["ID_MOVI_DUES"].ToString();
                    objBalanza.ID_MOVI_OPER = rdr["ID_MOVI_OPER"].ToString();
                    objBalanza.FE_ENTR = rdr["FE_ENTR"].ToString();
                    objBalanza.HO_ENTR = rdr["HO_ENTR"].ToString();
                    objBalanza.FE_SALI = rdr["FE_SALI"].ToString();
                    objBalanza.HO_SALI = rdr["HO_SALI"].ToString();
                    objBalanza.ID_REGI_PLAC = rdr["ID_REGI_PLAC"].ToString();
                    objBalanza.ID_TICK_ANTE = rdr["ID_TICK_ANTE"].ToString();
                    objBalanza.NU_BREV = rdr["NU_BREV"].ToString(); 
                    objBalanza.NO_COND = rdr["NO_COND"].ToString();
                    objBalanza.NU_DOCU_IDEN = rdr["NU_DOCU_IDEN"].ToString();
                    objBalanza.NO_TRAN = rdr["NO_TRAN"].ToString();
                    objBalanza.ID_TRAN = rdr["ID_TRAN"].ToString();
                    objBalanza.DE_NUME_TRAC = rdr["DE_NUME_TRAC"].ToString();
                    objBalanza.DE_NUME_TAUX = rdr["DE_NUME_TAUX"].ToString();
                    objBalanza.NU_EJES = rdr["NU_EJES"].ToString();
                    objBalanza.DE_CONF_VEHI = rdr["DE_CONF_VEHI"].ToString();
                    objBalanza.CO_CLIE = rdr["CO_CLIE"].ToString();
                    objBalanza.DE_CLIE = rdr["DE_CLIE"].ToString();
                    objBalanza.NU_RECA = rdr["NU_RECA"].ToString();
                    objBalanza.NO_NAVE = rdr["NO_NAVE"].ToString();
                    objBalanza.NU_SALI = rdr["NU_SALI"].ToString();
                    objBalanza.NO_DOCU = rdr["NO_DOCU"].ToString();
                    objBalanza.TI_DOCU_ORIG = rdr["TI_DOCU_ORIG"].ToString();
                    objBalanza.NU_DOCU_ORIG = rdr["NU_DOCU_ORIG"].ToString();
                    objBalanza.ID_DOCU_ORIG = rdr["ID_DOCU_ORIG"].ToString();
                    objBalanza.NU_SECU_ITEM = rdr["NU_SECU_ITEM"].ToString();
                    objBalanza.NU_CHAS = rdr["NU_CHAS"].ToString();
                    objBalanza.ID_TIPO_JORN = rdr["ID_TIPO_JORN"].ToString();
                    objBalanza.DE_TIPO_JORN = rdr["DE_TIPO_JORN"].ToString();
                    objBalanza.ST_CERT_CESO = rdr["ST_CERT_CESO"].ToString();
                    objBalanza.NU_GUIA_REMI = rdr["NU_GUIA_REMI"].ToString();
                    objBalanza.CO_BODE = rdr["CO_BODE"].ToString();
                    objBalanza.DE_BODE = rdr["DE_BODE"].ToString();
                    objBalanza.NU_FACT = rdr["NU_FACT"].ToString();
                    objBalanza.DE_CIUD = rdr["DE_CIUD"].ToString();
                    objBalanza.ID_CIUD = rdr["ID_CIUD"].ToString();
                    objBalanza.DE_CONT = rdr["DE_CONT"].ToString();
                    objBalanza.DE_OBSE = rdr["DE_OBSE"].ToString();
                    objBalanza.FE_TRAN_BDLO = rdr["FE_TRAN_BDLO"].ToString();
                    objBalanza.HO_TRAN_BDLO = rdr["HO_TRAN_BDLO"].ToString();
                    objBalanza.ID_MOVI_BDLO = rdr["ID_MOVI_BDLO"].ToString();
                    objBalanza.PE_TARA = rdr["PE_TARA"].ToString();
                    objBalanza.CA_PES1 = rdr["CA_PES1"].ToString();
                    objBalanza.CA_PES2 = rdr["CA_PES2"].ToString();
                    objBalanza.DE_PERS_PES1 = rdr["DE_PERS_PES1"].ToString();
                    objBalanza.DE_PERS_PES2 = rdr["DE_PERS_PES2"].ToString();
                    objBalanza.ST_CIER_JORN = rdr["ST_CIER_JORN"].ToString();
                    objBalanza.DE_EDIT_PESO = rdr["DE_EDIT_PESO"].ToString();
                    objBalanza.ST_CARG_CONT = rdr["ST_CARG_CONT"].ToString();
                    objBalanza.NO_USUA_CREA = rdr["NO_USUA_CREA"].ToString();
                    objBalanza.NO_USUA_MODI = rdr["NO_USUA_MODI"].ToString();
                    objBalanza.FE_USUA_CREA = rdr["FE_USUA_CREA"].ToString();
                    objBalanza.FE_USUA_MODI = rdr["FE_USUA_MODI"].ToString();
                    objBalanza.DE_TIPO_SITU = rdr["DE_TIPO_SITU"].ToString();
                    objBalanza.TI_SITU = rdr["TI_SITU"].ToString();
                    objBalanza.PE_RECE = rdr["PE_RECE"].ToString();
                    objBalanza.SA_DOCU_ORIG = rdr["SA_DOCU_ORIG"].ToString();
                    objBalanza.DE_PLAC = rdr["DE_PLAC"].ToString();
                    objBalanza.ID_REGI_COND = rdr["ID_REGI_COND"].ToString();
                    objBalanza.CA_PESO_SECO = rdr["CA_PESO_SECO"].ToString();
                    objBalanza.DE_MICS = rdr["DE_MICS"].ToString();
                    objBalanza.NU_PESO_MICS = rdr["NU_PESO_MICS"].ToString();
                    objBalanza.NU_CART_PORT = rdr["NU_CART_PORT"].ToString();
                    objBalanza.NU_DUES = rdr["NU_DUES"].ToString();
                    objBalanza.NU_VUEL = rdr["NU_VUEL"].ToString();
                    objBalanza.NU_TOTA_VUEL = rdr["NU_TOTA_VUEL"].ToString();
                    objBalanza.NU_NOTA_ENTR = rdr["NU_NOTA_ENTR"].ToString();
                    objBalanza.NU_MESA_PART = rdr["NU_MESA_PART"].ToString();
                    objBalanza.NU_CORR_CONT = rdr["NU_CORR_CONT"].ToString();
                    objBalanza.CO_PERS_PES1 = rdr["CO_PERS_PES1"].ToString();
                    objBalanza.CO_PERS_PES2 = rdr["CO_PERS_PES2"].ToString();
                    objBalanza.CO_REGU_PESO = rdr["CO_REGU_PESO"].ToString();
                    objBalanza.CO_EDIT_PESO = rdr["CO_EDIT_PESO"].ToString();
                    objBalanza.ST_EDIT_PESO = rdr["ST_EDIT_PESO"].ToString();
                    objBalanza.DE_CLAS_CARG = rdr["DE_CLAS_CARG"].ToString();
                    objBalanza.PC_HUME = rdr["PC_HUME"].ToString();
                    objBalanza.ST_INDI_CLAS = rdr["ST_INDI_CLAS"].ToString();
                    objBalanza.DE_REGI = rdr["DE_REGI"].ToString();
                    objBalanza.CA_RECE = rdr["CA_RECE"].ToString();
                    objBalanza.CA_DESP = rdr["CA_DESP"].ToString();
                    objBalanza.DE_CARG = rdr["DE_CARG"].ToString();
                    objBalanza.DE_DIRE_WEBS = rdr["DE_DIRE_WEBS"].ToString();
                    objBalanza.DE_NOMB = rdr["DE_NOMB"].ToString();
                    objBalanza.NU_RUCS = rdr["NU_RUCS"].ToString();
                    objBalanza.ST_CARG_FRAC = rdr["ST_CARG_FRAC"].ToString();
                    objBalanza.ST_CARG_GRAN = rdr["ST_CARG_GRAN"].ToString();
                    objBalanza.ST_CARG_RODA = rdr["ST_CARG_RODA"].ToString();
                    objBalanza.ST_CONT_LLVA = rdr["ST_CONT_LLVA"].ToString();
                    objBalanza.CA_TOTA = rdr["CA_TOTA"].ToString();
                    objBalanza.ID_REGI = rdr["ID_REGI"].ToString();
                    objBalanza.DE_TIPO_EMBA = rdr["DE_TIPO_EMBA"].ToString();
                    objBalanza.ID_BAL2 = rdr["ID_BAL2"].ToString();
                    objBalanza.NU_BULT = rdr["NU_BULT"].ToString();
                    objBalanza.NU_DOCU_DEST = rdr["NU_DOCU_DEST"].ToString();
                    objBalanza.DE_DIRE = rdr["DE_DIRE"].ToString();
                    objBalanza.ID_UBIG = rdr["ID_UBIG"].ToString();
                    objBalanza.NU_DUAS = rdr["NU_DUAS"].ToString();
                    objBalanza.DE_ZONA = rdr["DE_ZONA"].ToString();
                    objBalanza.NU_DOCU_CLIE = rdr["NU_DOCU_CLIE"].ToString();
                    objBalanza.PR_ADUA_MANI = rdr["PR_ADUA_MANI"].ToString();
                    objBalanza.NU_MANI = rdr["NU_MANI"].ToString();
                    Listbal.Add(objBalanza);
                }
                conexion.Close();

                return Listbal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MDTmreca> ListRecalada(int INID_EMPR)
        {
            try
            {
                List<MDTmreca> ListReca = new List<MDTmreca>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TMRECA_Q09]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@INID_EMPR", INID_EMPR);
                conexion.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MDTmreca objReca = new MDTmreca();  
                    objReca.NU_RECA = rdr["NU_RECA"].ToString();
                    objReca.NAVE_RECA = rdr["NO_NAVE"].ToString();         
                    ListReca.Add(objReca);
                }
                conexion.Close();



                return ListReca;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MDTcdocu_orig> ListDocorig(string NU_RECA)
        {
            try
            {
                List<MDTcdocu_orig> ListDocu = new List<MDTcdocu_orig>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TCDOCU_ORIG_Q42]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@ISNU_RECA", NU_RECA);
                conexion.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MDTcdocu_orig objDocu = new MDTcdocu_orig();
                    objDocu.ID_DOCU_ORIG = Convert.ToInt32(rdr["ID_DOCU_ORIG"]);
                    objDocu.NU_RECA = rdr["NU_RECA"].ToString();
                    objDocu.TI_DOCU_ORIG = rdr["TI_DOCU_ORIG"].ToString();
                    objDocu.NU_DOCU_ORIG = rdr["NU_DOCU_ORIG"].ToString();
                    ListDocu.Add(objDocu);
                }
                conexion.Close();

                return ListDocu;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MDTddocu_orig> ListItem(int ID_DOCU_ORIG)
        {
            try
            {
                List<MDTddocu_orig> Listitem = new List<MDTddocu_orig>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TS_TDDOCU_ORIG_Q31]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@INID_DOCU_ORIG", ID_DOCU_ORIG);
                conexion.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MDTddocu_orig objitem = new MDTddocu_orig();
                    objitem.ID_DOCU_ORIG = Convert.ToInt32(rdr["ID_DOCU_ORIG"]);
                    objitem.NU_DOCU_ORIG = rdr["NU_DOCU_ORIG"].ToString();
                    objitem.NU_SECU_ITEM = Convert.ToInt32(rdr["NU_SECU_ITEM"]);
                    objitem.DE_CARG = rdr["DE_CARG"].ToString();
                    Listitem.Add(objitem);
                }
                conexion.Close();

                return Listitem;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task InsertImg(string path, string nombre, string almacen)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[OfiOper].[TC_ANTPIMG_I01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PE_imgruta", path);
                cmd.Parameters.AddWithValue("@PE_nombre", nombre);
                cmd.Parameters.AddWithValue("@PE_almacen", almacen);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MDImagen> ListImg()
        {
            try
            {
                List<MDImagen> Listitem = new List<MDImagen>();
                SqlCommand cmd = new SqlCommand("[OfiOper].[TC_ANTPIMG_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MDImagen objimg = new MDImagen();
                    objimg.id_img = Convert.ToInt32(rdr["id_img"]);
                    objimg.img_ruta = rdr["img_ruta"].ToString();
                    objimg.img_nombre = rdr["img_nombre"].ToString();
                    objimg.img_almacen = rdr["img_almacen"].ToString();
                    Listitem.Add(objimg);
                }
                conexion.Close();

                return Listitem;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
