//using EmployeesTracking.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EmployeesTracking.Models
//{
//    public class EmployeeDal : IEmployeeDal
//    {
//        public void Add(Personel personel)
//        {
//            using (EmployeesContext employeesContext = new EmployeesContext())
//            {
//                employeesContext.Personels.Add(personel);
//                employeesContext.SaveChanges();
//            }
//        }

//        public void Delete(Personel personel)
//        {
//            using (EmployeesContext employeesContext = new EmployeesContext())
//            {
//                employeesContext.Personels.Remove(employeesContext.Personels.SingleOrDefault(e => e.Id == personel.Id));
//                employeesContext.SaveChanges();
//            }
//        }

//        public List<Personel> GetAll()
//        {
//            using (EmployeesContext employeesContext = new EmployeesContext())
//            {
//                return employeesContext.Personels.ToList();
//            }
//        }

//        public void Update(Personel personel)
//        {
//            using (EmployeesContext employeesContext = new EmployeesContext())
//            {
//                var EmployeeToUpdate = employeesContext.Personels.SingleOrDefault(p => p.Id == personel.Id);
//                EmployeeToUpdate.Adi = personel.Adi;
//                EmployeeToUpdate.Soyadi = personel.Soyadi;
//                EmployeeToUpdate.BabaAdi = personel.BabaAdi;
//                EmployeeToUpdate.AnaAdi = personel.AnaAdi;
//                EmployeeToUpdate.Cinsiyet = personel.Cinsiyet;
//                EmployeeToUpdate.MedeniHali = personel.MedeniHali;
//                EmployeeToUpdate.TcNo = personel.TcNo;
//                EmployeeToUpdate.DogumYeri = personel.DogumYeri;
//                EmployeeToUpdate.DogumTarihi = personel.DogumTarihi;

//                employeesContext.SaveChanges();
//            }
//        }
//    }
//}
