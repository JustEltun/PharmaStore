using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaStoreData
{
    public class PharmaContext : DataContext
    {
        #region SQL COMMAND
        private readonly string cmdGet = "EXEC sp_Get";
        private readonly string cmdAdd = "EXEC sp_Add @name={0},@description={1},@manufacturer={2},@country={3},@price={4},@amount={5},@manufactureddate={6},@expiration={7}";
        private readonly string cmdEdit = "EXEC sp_Edit @id={0},@name={1},@description={2},@manufacturer={3},@country={4},@price={5},@amount={6},@manufactureddate={7},@expiration={8}";
        private readonly string cmdDelete = "EXEC sp_Delete @id={0}";
        private readonly string cmdFindByName = "EXEC sp_FindByName @target={0}";
        private readonly string cmdFindByDescription = "EXEC sp_FindByDescription @target={0}";
        #endregion

        public PharmaContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"\pharmacydata.mdf;Integrated Security=True")
        {
        }
        //GET
        public List<Drug> Drugs()
        {
            return ExecuteQuery<Drug>(cmdGet).ToList();
        }
        //GET ASYNC
        public async Task<List<Drug>> DrugsAsync()
        {
            return await Task.Run(() =>
           {
               return ExecuteQuery<Drug>(cmdGet).ToList();
           });
        }

        //ADD
        public async Task<int> Add(Drug drug)
        {
            return await Task.Run(() =>
            {
                return ExecuteCommand(cmdAdd,
                                      drug.Name,
                                      drug.Description,
                                      drug.Manufacturer,
                                      drug.Country,
                                      drug.Price,
                                      drug.Amount,
                                      drug.ManufacturedDate,
                                      drug.Expiration);
            });
        }

        //EDIT
        public async Task<int> Edit(Drug drug)
        {
            return await Task.Run(() =>
             {
                 return ExecuteCommand(cmdEdit,
                                      drug.Id,
                                      drug.Name,
                                      drug.Description,
                                      drug.Manufacturer,
                                      drug.Country,
                                      drug.Price,
                                      drug.Amount,
                                      drug.ManufacturedDate,
                                      drug.Expiration);
             });
        }

        //DELETE
        public async Task<int> Delete(int? id)
        {
            return await Task.Run(() =>
             {
                 return ExecuteCommand(cmdDelete, id);
             });
        }

        // SEARCH 
        public async Task<List<Drug>> Find(string place, string target)
        {
            return await Task.Run(() =>
            {
                if (place == "name")
                    return ExecuteQuery<Drug>(cmdFindByName, target).ToList();
                else if (!String.IsNullOrEmpty(place))
                    return ExecuteQuery<Drug>(cmdFindByDescription, target).ToList();
                else
                    return null;
            });
        }
    }
}
