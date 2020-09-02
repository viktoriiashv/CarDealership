using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using CarDealership.Models;


namespace CarDealership.DAL
{
    interface IManagerRepository : IDisposable
    {
        IEnumerable<Manager> GetManagers();
        Manager GetManagerByID(int managerID);
        void InsertManager(Manager manager);
        void DeleteManager(int managerID);
        void UpdateManager(Manager manager);
        void Save();

    }
}
