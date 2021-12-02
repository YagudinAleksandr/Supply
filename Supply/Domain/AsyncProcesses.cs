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
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var benefits = db.Benefits.Where(s => s.Status == true).ToList();
                foreach(Benefit benefit in benefits)
                {
                    if (Convert.ToDateTime(benefit.EndDate) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        benefit.Status = false;
                        benefit.UpdatedAt = DateTime.Now.ToString();
                        try
                        {
                            db.Entry(benefit).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: AsyncProcesses. Method: UpdateBenefits." + ex.Message + "." + ex.InnerException;

                            db.Logs.Add(log);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        public static void UpdateChangeRoom()
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                var changeRooms = db.ChangeRooms.Where(st => st.Status == true).Include(or => or.Order).ToList();

                foreach(ChangeRoom changeRoom in changeRooms)
                {
                    try
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
                    catch(Exception ex)
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
        public static void UpdateOrders()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var tenants = db.Tenants.Where(s => s.Status == true).Include(r=>r.Order).ToList();

                foreach(Tenant tenant in tenants)
                {
                    try
                    {
                        if(tenant.Order!=null)
                        {
                            if (Convert.ToDateTime(tenant.Order.EndDate) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                            {
                                tenant.Status = false;
                                tenant.UpdatedAt = DateTime.Now.ToString();

                                try
                                {
                                    db.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    Log log = new Log();
                                    log.ID = Guid.NewGuid();
                                    log.Type = "ERROR";
                                    log.CreatedAt = DateTime.Now.ToString();
                                    log.Caption = $"Class: AsyncProcesses. Method: UpdateOrders." + ex.Message + "." + ex.InnerException;

                                    db.Logs.Add(log);
                                    db.SaveChanges();
                                }
                            }
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Log log = new Log();
                        log.ID = Guid.NewGuid();
                        log.Type = "ERROR";
                        log.CreatedAt = DateTime.Now.ToString();
                        log.Caption = $"Class: AsyncProcesses. Method: UpdateOrders." + ex.Message + "." + ex.InnerException;

                        db.Logs.Add(log);
                        db.SaveChanges();
                    }
                    
                }

                var electricityOrders = db.ElecricityOrders.ToList();

                foreach(ElecricityOrder elecricityOrder in electricityOrders)
                {
                    if (Convert.ToDateTime(elecricityOrder.EndDate) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        elecricityOrder.Status = false;
                        elecricityOrder.UpdatedAt = DateTime.Now.ToString();

                        try
                        {
                            db.Entry(elecricityOrder).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: AsyncProcesses. Method: UpdateOrders." + ex.Message + "." + ex.InnerException;

                            db.Logs.Add(log);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        public static void UpdateTerminations()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var terminations = db.Terminations.Where(s => s.Status == false).ToList();

                foreach (Termination termination in terminations)
                {
                    if (Convert.ToDateTime(termination.Date) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        Tenant tenant = db.Tenants.Where(x => x.ID == termination.OrderID).FirstOrDefault();

                        termination.Status = true;
                        termination.UpdatedAt = DateTime.Now.ToString();

                        tenant.Status = false;
                        tenant.UpdatedAt = DateTime.Now.ToString();

                        try
                        {
                            db.Entry(termination).State = EntityState.Modified;
                            db.SaveChanges();

                            db.Entry(tenant).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: AsyncProcesses. Method: UpdateTerminations." + ex.Message + "." + ex.InnerException;

                            db.Logs.Add(log);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        
    }
}
