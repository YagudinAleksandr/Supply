using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class OrderElectricityCreate : Form
    {
        private int _hostelID;
        private int _tenantID;
        private Tenant _tenant;
        public OrderElectricityCreate()
        {
            InitializeComponent();
            _tenantID = 0;
        }
        public OrderElectricityCreate(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void OrderElectricityCreate_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateInform);
            thread.Start();
            _hostelID = 0;

            if (_tenantID != 0)
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    CB_Hostels.Enabled = false;
                    _tenant = db.Tenants
                        .Where(id => id.ID == _tenantID)
                        .Include(r => r.Room)
                        .FirstOrDefault();

                    Flat flat = db.Flats
                        .Where(id => id.ID == _tenant.Room.FlatID)
                        .Include(ent => ent.Enterance)
                        .FirstOrDefault();

                    Hostel hostel = db.Hostels
                        .Where(id => id.ID == flat.Enterance.HostelId)
                        .FirstOrDefault();

                    CB_Hostels.SelectedValue= _hostelID = hostel.ID;
                }
            }
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            if(_hostelID==0)
            {
                MessageBox.Show("Выбирите общежитие!");
                return;
            }
            if (_tenantID == 0)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();
                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();
                    if (enterances.Count == 0)
                    {
                        MessageBox.Show("Общежиие не сформировано! Данная операция невозможна!");
                        return;
                    }

                    List<Tenant> tenantsList = new List<Tenant>();

                    foreach (Enterance enterance in enterances)
                    {
                        var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                        if (flats.Count == 0)
                        {
                            MessageBox.Show("Общежиие не сформировано! Данная операция невозможна!");
                            return;
                        }

                        foreach (Flat flat in flats)
                        {
                            var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).ToList();


                            foreach (Room room in rooms)
                            {
                                var tenants = db.Tenants.Where(x => x.RoomID == room.ID).ToList();
                                if (tenants.Count != 0)
                                {
                                    foreach (Tenant tenant in tenants)
                                    {
                                        bool flag = false;
                                        var additionalInformations = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).Include(t => t.AdditionalInformationType).ToList();
                                        foreach (AdditionalInformation additionalInformation in additionalInformations)
                                        {
                                            if (additionalInformation.AdditionalInformationTypeID == 5)
                                            {
                                                if (additionalInformation.Value == "Заочная")
                                                {
                                                    flag = true;
                                                }
                                            }
                                        }

                                        if (flag == false)
                                        {
                                            tenantsList.Add(tenant);
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (tenantsList.Count == 0)
                    {
                        MessageBox.Show($"Нет жильцов в общежитии {hostel.Name}");
                        return;
                    }
                    PB_Progress.Minimum = 0;
                    PB_Progress.Maximum = tenantsList.Count;
                    PB_Progress.Step = 1;
                    foreach (Tenant tenant in tenantsList)
                    {
                        ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(t => t.TenantID == tenant.ID).Where(st => st.Status == true).FirstOrDefault();
                        if (elecricityOrder == null)
                        {
                            elecricityOrder = new ElecricityOrder();
                            elecricityOrder.StartDate = TB_StartOrder.Text;
                            elecricityOrder.EndDate = TB_EndOrder.Text;
                            elecricityOrder.CreatedAt = elecricityOrder.UpdatedAt = DateTime.Now.ToString();
                            elecricityOrder.TenantID = tenant.ID;
                            elecricityOrder.Status = true;

                            try
                            {
                                db.ElecricityOrders.Add(elecricityOrder);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Log log = new Log();
                                log.ID = Guid.NewGuid();
                                log.Type = "ERROR";
                                log.CreatedAt = DateTime.Now.ToString();
                                log.Caption = $"Class: OrderElectricityCreate. Method: BTN_Create_Click." + ex.Message + "." + ex.InnerException;

                                db.Logs.Add(log);
                                db.SaveChanges();
                                MessageBox.Show(ex.Message);
                            }
                        }
                        string error = string.Empty;
                        if (!OrdersCreation.CreateServiceOrder(tenant.ID, out error))
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: OrderElectricityCreate. Method: BTN_Create_Click." + error;

                            db.Logs.Add(log);
                            db.SaveChanges();
                            MessageBox.Show(error);
                        }
                        PB_Progress.PerformStep();
                    }

                    MessageBox.Show("Договора сформированы!");
                    this.Close();
                }
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();
                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();
                    if (enterances.Count == 0)
                    {
                        MessageBox.Show("Общежиие не сформировано! Данная операция невозможна!");
                        return;
                    }

                    List<Tenant> tenantsList = new List<Tenant>();

                    bool flag = false;
                    var additionalInformations = db.AdditionalInformation.Where(x => x.TenantID == _tenant.ID).Include(t => t.AdditionalInformationType).ToList();
                    foreach (AdditionalInformation additionalInformation in additionalInformations)
                    {
                        if (additionalInformation.AdditionalInformationTypeID == 5)
                        {
                            if (additionalInformation.Value == "Заочная")
                            {
                                flag = true;
                            }
                        }
                    }

                    if (flag == false)
                    {
                        tenantsList.Add(_tenant);
                    }
                    else
                    {
                        MessageBox.Show("Студент заочной формы обучения!");
                        return;
                    }
                    if (tenantsList.Count == 0)
                    {
                        MessageBox.Show($"Нет жильцов в общежитии {hostel.Name}");
                        return;
                    }
                    PB_Progress.Minimum = 0;
                    PB_Progress.Maximum = tenantsList.Count;
                    PB_Progress.Step = 1;
                    foreach (Tenant tenant in tenantsList)
                    {
                        ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(t => t.TenantID == tenant.ID).Where(st => st.Status == true).FirstOrDefault();
                        if (elecricityOrder == null)
                        {
                            elecricityOrder = new ElecricityOrder();
                            elecricityOrder.StartDate = TB_StartOrder.Text;
                            elecricityOrder.EndDate = TB_EndOrder.Text;
                            elecricityOrder.CreatedAt = elecricityOrder.UpdatedAt = DateTime.Now.ToString();
                            elecricityOrder.TenantID = tenant.ID;
                            elecricityOrder.Status = true;

                            try
                            {
                                db.ElecricityOrders.Add(elecricityOrder);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Log log = new Log();
                                log.ID = Guid.NewGuid();
                                log.Type = "ERROR";
                                log.CreatedAt = DateTime.Now.ToString();
                                log.Caption = $"Class: OrderElectricityCreate. Method: BTN_Create_Click." + ex.Message + "." + ex.InnerException;

                                db.Logs.Add(log);
                                db.SaveChanges();
                                MessageBox.Show(ex.Message);
                            }
                        }
                        string error = string.Empty;
                        if (!OrdersCreation.CreateServiceOrder(tenant.ID, out error))
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: OrderElectricityCreate. Method: BTN_Create_Click." + error;

                            db.Logs.Add(log);
                            db.SaveChanges();
                            MessageBox.Show(error);
                        }
                        PB_Progress.PerformStep();
                    }

                    MessageBox.Show("Договор сформирован!");
                    this.Close();
                }
            }
        }
        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void UpdateInform()
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      CB_Hostels.DataSource = db.Hostels.ToList();
                      CB_Hostels.ValueMember = "ID";
                      CB_Hostels.DisplayMember = "Name";
                  }
              };
            Invoke(action);
        }

        
    }
}
