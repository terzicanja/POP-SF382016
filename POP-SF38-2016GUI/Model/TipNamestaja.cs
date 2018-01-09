using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class TipNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private bool obrisan;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;



        public override string ToString()
        {
            return $"{Naziv}";
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tip in Projekat.Instance.TipoviNamestaja)
            {
                if(tip.Id == id)
                {
                    return tip; //mozda nije id nego naziv ili nzm i onda pozivan Tipnamestaja.getbyid(idtipnamestaja)
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new TipNamestaja()
            {
                Id = id,
                Naziv = naziv,
                Obrisan = obrisan
            };
        }


        #region CRUD
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    tipoviNamestaja.Add(tn);
                }
            }
            return tipoviNamestaja;
        }

        public static ObservableCollection<TipNamestaja> Search(string srchtext, string sorttext)
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                //con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                string selectCommand = "SELECT * FROM TipNamestaja WHERE Naziv LIKE @srchtext ORDER BY ";

                selectCommand += sorttext;
                cmd.CommandText = selectCommand;
                //cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Naziv LIKE @srchtext ORDER BY @sorttext;";
                cmd.Parameters.AddWithValue("@srchtext", "%" + srchtext + "%");
                //cmd.Parameters.AddWithValue("@sorttext", sorttext);
                da.SelectCommand = cmd;
                da.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    tipoviNamestaja.Add(tn);
                }
                return tipoviNamestaja;
            }
        }

        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES (@Naziv, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.TipoviNamestaja.Add(tn);

            return tn;
        }

        public static void Update(TipNamestaja tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE TipNamestaja SET Naziv = @Naziv, Obrisan = @Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();
            }
            //azuriranje modela
            foreach (var tip in Projekat.Instance.TipoviNamestaja)
            {
                if(tn.Id == tip.Id)
                {
                    tip.Naziv = tn.Naziv;
                    tip.Obrisan = tn.Obrisan;
                }
            }
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }
        #endregion
    }
}
