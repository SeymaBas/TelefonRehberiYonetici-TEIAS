using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace TelefonRehberiYonetici_TEIAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        WebServiceTelefonRehberi.WebServiceRehber2SoapClient ws = new WebServiceTelefonRehberi.WebServiceRehber2SoapClient();



        private void VeriGoster_Click(object sender, EventArgs e)
        {
            /*  verileriGoster("select * from Dahili$");

              textEditAdSoyad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditAdSoyad.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditBolumAdi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditBolumAdi.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditDahili1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditDahili1.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditDahili2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditDahili2.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditDahiliID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditDahiliID.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditIsmeGoreArama.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditIsmeGoreArama.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditBolumeGoreArama.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditBolumeGoreArama.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditAdSoyad.Focus();

      */
        }

        public void KisiEkle(string AdSoyad, string dahili1, string dahili2, string BolumAdi)
        {
            ws.KisiEkle(AdSoyad, dahili1, dahili2, BolumAdi);
        }
        private void simpleButtonEkle_Click(object sender, EventArgs e)

        {
            try
            {
                KisiEkle(textEditAdSoyad.Text, textEditDahili1.Text, textEditDahili2.Text, textEditBolumAdi.Text);
                XtraMessageBox.Show("Kişi eklendi.", "İşlem başarılı", MessageBoxButtons.OK);

            }
            catch
            {
                XtraMessageBox.Show("Kişi eklenemedi.Tekrar deneyin.", "İşlem başarısız", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }

            /*  textEditAdSoyad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditAdSoyad.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditBolumAdi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditBolumAdi.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditDahili1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditDahili1.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditDahili2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditDahili2.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditDahiliID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditDahiliID.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditIsmeGoreArama.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditIsmeGoreArama.Properties.Mask.EditMask = @"\d+\.?\d?";

              textEditBolumeGoreArama.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
              textEditBolumeGoreArama.Properties.Mask.EditMask = @"\d+\.?\d?";

            //  textEditAdSoyad.Focus();*/
        }


        public void KisiSil(int dahiliID)
        {
            ws.KisiSil(dahiliID);

        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)gridControlDahiliNumaraDuzenleme.MainView).GetSelectedRows();
                DataRowView selRow = (DataRowView)(((GridView)gridControlDahiliNumaraDuzenleme.MainView).GetRow(selRows[0]));
                textEditDahiliID.Text = selRow["DahiliID"].ToString();
                KisiSil(Convert.ToInt32(selRow["DahiliID"]));
                XtraMessageBox.Show("Kişi silindi.", "İşlem başarılı", MessageBoxButtons.OK);
            }
            catch
            {

                {
                    XtraMessageBox.Show("Kişi silinemedi.Tekrar deneyiniz.", "İşlem başarısız", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }




            }
        }

        private void gridControlDahiliNumaraDuzenleme_Load(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.VeriGoster();
            gridControlDahiliNumaraDuzenleme.DataSource = ds.Tables[0];
        }

        private void textEditIsmeGoreArama_TextChanged(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.IsimAra(textEditIsmeGoreArama.Text);
            gridControlDahiliNumaraDuzenleme.DataSource = ds.Tables[0];

        }

        private void textEditBolumeGoreArama_TextChanged(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.BolumAra(textEditBolumeGoreArama.Text);
            gridControlDahiliNumaraDuzenleme.DataSource = ds.Tables[0];

        }




        private void gridControlDahiliNumaraDuzenleme_Click(object sender, EventArgs e)
        {
            int[] selRows = ((GridView)gridControlDahiliNumaraDuzenleme.MainView).GetSelectedRows();
            DataRowView selRow = (DataRowView)(((GridView)gridControlDahiliNumaraDuzenleme.MainView).GetRow(selRows[0]));
            textEditAdSoyad.Text = selRow["AdSoyad"].ToString();
            textEditBolumAdi.Text = selRow["BolumAdi"].ToString();
            textEditDahili1.Text = selRow["Dahili1"].ToString();
            textEditDahili2.Text = selRow["Dahili2"].ToString();
            textEditDahiliID.Text = selRow["DahiliID"].ToString();

        }

        private void simpleButtonYenile_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.VeriGoster();
            gridControlDahiliNumaraDuzenleme.DataSource = ds.Tables[0];
            textEditAdSoyad.Text = "";
            textEditBolumAdi.Text = "";
            textEditDahili1.Text = "";
            textEditDahili2.Text = "";
            textEditDahiliID.Text = "";
            textEditIsmeGoreArama.Text = "";
            textEditBolumeGoreArama.Text = "";


        }


        public void KisiGuncelle(string adSoyad, string dahili1, string dahili2, string bolumAdi, int dahiliID)
        {

            ws.KisiGuncelle(adSoyad, dahili1, dahili1, bolumAdi, dahiliID);
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)gridControlDahiliNumaraDuzenleme.MainView).GetSelectedRows();
                DataRowView selRow = (DataRowView)(((GridView)gridControlDahiliNumaraDuzenleme.MainView).GetRow(selRows[0]));
                textEditDahiliID.Text = selRow["DahiliID"].ToString();
                KisiGuncelle(textEditAdSoyad.Text, textEditDahili1.Text, textEditDahili2.Text, textEditBolumAdi.Text, Convert.ToInt32(selRow["DahiliID"]));
                XtraMessageBox.Show("Kişi güncellendi.", "İşlem başarılı", MessageBoxButtons.OK);
            }
            catch
            { XtraMessageBox.Show("Güncelleme gerçekleşmedi.Tekrar deneyiniz.", "İşlem başarısız", MessageBoxButtons.YesNo, MessageBoxIcon.Error); }
        }

        private void textEditTrafoMerkeziArama_TextChanged(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.TrafoAra(textEditTrafoMerkeziArama.Text);
            gridControlHariciNumaraDuzenleme.DataSource = ds.Tables[0];

        }

        private void gridControlHariciNumaraDuzenleme_Load(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.VeriGoster2();
            gridControlHariciNumaraDuzenleme.DataSource = ds.Tables[0];

        }

        public void TrafoEkle(string Isim, string TelefonNo, string KodNo, string PaxNo, string BirimAdi)
        {
            ws.TrafoEkle(Isim, TelefonNo, KodNo, PaxNo, BirimAdi);
        }
        private void simpleButtonEkle2_Click(object sender, EventArgs e)
        {


            try
            {
                TrafoEkle(textEditTrafoAdi.Text, textEditTrafoTelNo.Text, textEditKodNo.Text, textEditPaxNo.Text, textEditBirimAdi.Text);
                XtraMessageBox.Show("Kişi eklendi.", "İşlem başarılı", MessageBoxButtons.OK);

            }
            catch
            {
                XtraMessageBox.Show("Kişi eklenemedi.Tekrar deneyin.", "İşlem başarısız", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void simpleButtonYenile2_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ws.VeriGoster2();
            gridControlHariciNumaraDuzenleme.DataSource = ds.Tables[0];
            textEditTrafoAdi.Text = "";
            textEditTrafoTelNo.Text = "";
            textEditKodNo.Text = "";
            textEditPaxNo.Text = "";
            textEditBirimAdi.Text = "";
            textEditTrafoMerkeziArama.Text = "";
            textEditTrafoID.Text = "";

        }


        public void TrafoSil(int trafoID)
        {

            ws.TrafoSil(trafoID);
        }


        private void simpleButtonSil2_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)gridControlHariciNumaraDuzenleme.MainView).GetSelectedRows();
                DataRowView selRow = (DataRowView)(((GridView)gridControlHariciNumaraDuzenleme.MainView).GetRow(selRows[0]));
                textEditDahiliID.Text = selRow["TrafoID"].ToString();
                TrafoSil(Convert.ToInt32(selRow["TrafoID"]));
                XtraMessageBox.Show("Trafo Silindi.", "İşlem başarılı", MessageBoxButtons.OK);
            }
            catch
            {

                {
                    XtraMessageBox.Show("Trafo silinemedi.Tekrar deneyiniz.", "İşlem başarısız", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }


            }
        }

        private void gridControlHariciNumaraDuzenleme_Click(object sender, EventArgs e)
        {
            int[] selRows = ((GridView)gridControlHariciNumaraDuzenleme.MainView).GetSelectedRows();
            DataRowView selRow = (DataRowView)(((GridView)gridControlHariciNumaraDuzenleme.MainView).GetRow(selRows[0]));
            textEditTrafoAdi.Text = selRow["Isim"].ToString();
            textEditTrafoTelNo.Text = selRow["TelefonNo"].ToString();
            textEditKodNo.Text = selRow["KodNo"].ToString();
            textEditPaxNo.Text = selRow["PaxNo"].ToString();
            textEditBirimAdi.Text = selRow["BirimAdi"].ToString();
            textEditTrafoID.Text = selRow["TrafoID"].ToString();
            
        }

        public void trafoGuncelle(string isim, string trafoTelNo, string kodNo, string paxNo, string birimAdi, int trafoID) {

            ws.TrafoGuncelle(isim, trafoTelNo, kodNo, paxNo, birimAdi, trafoID);
        }


        private void simpleButtonGuncelle2_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selRows = ((GridView)gridControlHariciNumaraDuzenleme.MainView).GetSelectedRows();
                DataRowView selRow = (DataRowView)(((GridView)gridControlHariciNumaraDuzenleme.MainView).GetRow(selRows[0]));
                textEditTrafoID.Text = selRow["TrafoID"].ToString();
                trafoGuncelle(textEditTrafoAdi.Text, textEditTrafoTelNo.Text, textEditKodNo.Text,textEditPaxNo.Text,textEditBirimAdi.Text, Convert.ToInt32(selRow["TrafoID"]));
                XtraMessageBox.Show("Kişi güncellendi.", "İşlem başarılı", MessageBoxButtons.OK);
            }
            catch
            { XtraMessageBox.Show("Güncelleme gerçekleşmedi.Tekrar deneyiniz.", "İşlem başarısız", MessageBoxButtons.YesNo, MessageBoxIcon.Error); }


        }
    }
}
   











