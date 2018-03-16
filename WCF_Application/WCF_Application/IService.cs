using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WCF_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        CustomerData Get();

        [OperationContract]
        void Insert(string name, string country);

        [OperationContract]
        void Update(int customerId, string name, string country);

        [OperationContract]
        void Delete(int customerId);
    }

    [DataContract]
    public class CustomerData
    {
        public CustomerData()
        {
            this.CustomersTable = new DataTable("CustomersData");
        }

        [DataMember]
        public DataTable CustomersTable { get; set; }
    }
}
