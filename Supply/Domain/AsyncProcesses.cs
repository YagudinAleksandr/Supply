using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Supply.Domain
{
    public class AsyncProcesses
    {
        public static void UpdateBenefits()
        {

        }

        public static void UpdateChangeRoom()
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                var changeRooms = db.ChangeRooms.Where(st => st.Status == true).Include(or => or.Order).ToList();

                foreach(ChangeRoom changeRoom in changeRooms)
                {
                    if (Convert.ToDateTime(changeRoom.StartDate) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        Tenant tenant = db.Tenants.Where(id => id.ID == changeRoom.Order.ID).FirstOrDefault();
                        tenant.RoomID = (int)changeRoom.RoomID;
                        tenant.UpdatedAt = DateTime.Now.ToString();

                        try
                        {
                            db.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            changeRoom.Status = false;
                            db.Entry(changeRoom).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: AsyncProcesses. Method: UpdateChangeRoom." + ex.Message + "." + ex.InnerException;

                            db.Logs.Add(log);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
