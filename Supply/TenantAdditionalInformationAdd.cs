using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantAdditionalInformationAdd : Form
    {
        private int _tenantId;
        private List<AdditionalInformationType> _additionalInformationType;
        public TenantAdditionalInformationAdd(int tenantId)
        {
            InitializeComponent();
            _tenantId = tenantId;
            using (SupplyDbContext db = new SupplyDbContext())
            {
                _additionalInformationType = db.AdditionalInformationTypes.ToList();
            }
        }

        private void TenantAdditionalInformationAdd_Load(object sender, EventArgs e)
        {
            this.COL_Type.DataSource = _additionalInformationType;
            this.COL_Type.DisplayMember = "Name";
            this.COL_Type.ValueMember = "ID";
        }

        private void DG_ViewAdditionalInformation_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.COL_Type.DataSource = _additionalInformationType;
            this.COL_Type.DisplayMember = "Name";
            this.COL_Type.ValueMember = "ID";
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                foreach (DataGridViewRow dataGridViewRow in DG_ViewAdditionalInformation.Rows)
                {
                    if(dataGridViewRow.Cells[0].Value!=null&& dataGridViewRow.Cells[1].Value !=null)
                    {
                        AdditionalInformation additionalInformation = new AdditionalInformation();
                        additionalInformation.TenantID = _tenantId;
                        additionalInformation.AdditionalInformationTypeID = int.Parse(dataGridViewRow.Cells[0].Value.ToString());
                        additionalInformation.Value = dataGridViewRow.Cells[1].Value.ToString();

                        try
                        {
                            db.AdditionalInformation.Add(additionalInformation);
                            db.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}");
                        }
                    }
                }
                MessageBox.Show("Информация добавлена успешно!");
                this.Close();
            }
            
        }
    }
}
